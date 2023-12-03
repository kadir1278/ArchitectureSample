using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.Company.Request;
using EntityLayer.Dto.Company.Response;

namespace BusinessLayer.Abstract
{
    public interface ICompanyService
    {
        public IDataResult<CompanyAddResponseDto> AddCompany(CompanyAddRequestDto userAddDto);
        public IDataResult<ICollection<CompanyListResponseDto>> GetCompanyCollection();
        public IDataResult<CompanyGetByIdResponseDto> GetCompanyById(Guid id);
    }
}
