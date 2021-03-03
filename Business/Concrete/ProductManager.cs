using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;  // manuel ekledim
using Business.CCS;
using System.Linq;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;


        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;

        }

        //Claim
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            //business Codes


            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                               CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                               CheckIfCategoryLimitExceeded());

            if (result != null)
            {

                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }


        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 24)  // saat  22 ise hata döndür (denemek icin)
            {
                Console.WriteLine("bakim zamani döngüsü calisti");
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed); //10.02.2021 
        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id) //dikkat 02.03.2021
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }


        [CacheAspect]
        public IDataResult<Product> GetById(int productId)  //  Tanimladik 10.02..2021
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }


        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }



        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsDetailed);
        }


        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult  Update(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                               CheckIfProductCountOfCategoryCorrect(product.CategoryId),                     
                               CheckIfCategoryLimitExceeded());
            if (result != null)
            {

                return result;
            }
            _productDal.Update(product);
             return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckIfProductCountOfCategoryCorrect (int categoryId)
        { 
        var result = _productDal.GetAll(p => p.CategoryId ==categoryId).Count;
            if (result >= 10)                       // Bu kural degistignde sadece buraya islem yapariz
            {
                return new ErrorResult(Messages.ProductCountCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();  // varmi yokmu nun kontrolu icin Any yeterli
            if (result)                       // Bu kural degistignde sadece buraya islem yapariz
            {

                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }



        private IResult CheckIfCategoryLimitExceeded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
            return new ErrorResult(Messages.CategoryLimitExceeded);
            }
            return new SuccessResult();
        }



        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {

            Add(product);
            if (product.UnitPrice < 10)
            {
                throw new Exception("");
            }

            Add(product);

            return null;
        }




    }
}
