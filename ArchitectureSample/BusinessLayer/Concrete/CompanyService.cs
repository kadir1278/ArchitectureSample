﻿using AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors;
using BusinessLayer.Abstract;
using CoreLayer.DataAccess.Enums;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.Company.Request;
using EntityLayer.Dto.Company.Response;
using EntityLayer.Entity;
using Mapster;

namespace BusinessLayer.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly IWorker _worker;
        private readonly ICompanyDal _companyDal;
        private readonly CancellationToken _ct;

        public CompanyService(IWorker worker, ICompanyDal companyDal)
        {
            _worker = worker;
            _companyDal = companyDal;
        }


        public IDataResult<CompanyAddResponseDto> AddCompany(CompanyAddRequestDto companyAddDto)
        {
            _ct.ThrowIfCancellationRequested();
            _worker.StartTransaction();

            Company company = companyAddDto.Adapt<Company>();
            var addedCompany = _companyDal.Add(company, _ct).Result;
            if (!addedCompany.IsSuccess)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<CompanyAddResponseDto>("Firma eklenemedi");
            }
            _worker.CommitAndSaveChangesAsync();
            return new SuccessDataResult<CompanyAddResponseDto>(addedCompany.Data.Adapt<CompanyAddResponseDto>(), "Firma Eklendi");
        }

        [IpCheckOperationAspect]
        [SecuredOperation(PermissionEnum.Ekle)]
        public IDataResult<ICollection<CompanyListResponseDto>> GetCompanyCollection()
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getCompany = _companyDal.Queryable().OrderByDescending(x => x.CreatedDate);

                if (getCompany is null) return new ErrorDataResult<ICollection<CompanyListResponseDto>>(String.Join("-", "Firma bulunamadı"));
                return new SuccessDataResult<ICollection<CompanyListResponseDto>>(getCompany.Adapt<ICollection<CompanyListResponseDto>>());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDataResult<CompanyGetByIdResponseDto> GetCompanyById(Guid id)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getCompany = _companyDal.GetById(id).Result;
                if (!getCompany.IsSuccess || getCompany.Data is null)
                    return new ErrorDataResult<CompanyGetByIdResponseDto>(getCompany.Messages);

                return new SuccessDataResult<CompanyGetByIdResponseDto>(getCompany.Data.Adapt<CompanyGetByIdResponseDto>());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
