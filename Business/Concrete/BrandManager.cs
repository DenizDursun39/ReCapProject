﻿using Business.Abstract;
using Business.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        BrandBusinessRules _brandBusinessRules;
        public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules)
        {
            _brandDal = brandDal;
            _brandBusinessRules = brandBusinessRules;
        }
        public IResult Add(Brands brand)
        {
            IResult result = BusinessRules.Run(_brandBusinessRules.CheckIfBrandAlreadyExists(brand)
                , _brandBusinessRules.CheckIfBrandNameIsUsed(brand));
            if (result != null) { return result; }
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brands brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brands>> GetAll()
        {
            return new SuccessDataResult<List<Brands>>(_brandDal.GetAll());
        }

        public IDataResult<Brands> GetById(int id)
        {
            return new SuccessDataResult<Brands>(_brandDal.Get(b=>b.Id==id));
        }

        public IResult Update(Brands brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
