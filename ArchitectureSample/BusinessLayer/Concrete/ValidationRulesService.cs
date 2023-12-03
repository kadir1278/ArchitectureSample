using BusinessLayer.Abstract;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.ValidationRule.Request;
using EntityLayer.Dto.ValidationRule.Response;
using EntityLayer.Entity;
using Mapster;

namespace BusinessLayer.Concrete
{
    public class ValidationRulesService : IValidationRulesService
    {
        private readonly IWorker _worker;
        private readonly IValidationRuleDal _validationRuleDal;
        private readonly CancellationToken _ct;

        public ValidationRulesService(IWorker worker, IValidationRuleDal validationRuleDal)
        {
            _worker = worker;
            _validationRuleDal = validationRuleDal;
        }


        public IDataResult<ValidationRuleAddResponseDto> AddValidationRules(ValidationRuleAddRequestDto validationRuleAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                ValidationRule validationRule = validationRuleAddDto.Adapt<ValidationRule>();
                var addedUser = _validationRuleDal.Add(validationRule, _ct);
                if (!addedUser.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<ValidationRuleAddResponseDto>("Validasyon kuralı eklenemedi");
                }
                _worker.CommitAndSaveChanges();
                return new SuccessDataResult<ValidationRuleAddResponseDto>(addedUser.Data.Adapt<ValidationRuleAddResponseDto>());
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<ValidationRuleAddResponseDto>(ex);
            }
        }

        public IDataResult<ICollection<ValidationRuleListResponseDto>> GetValidationRuleByValidatorName(Type validatorType)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();

                var getUser = _validationRuleDal.Queryable()
                                                .Where(x => x.ValidatorName == validatorType.Name && x.IsActive)
                                                .ToList();

                if (getUser is null) return new ErrorDataResult<ICollection<ValidationRuleListResponseDto>>(String.Join("-", "Validasyon kuralı bulunamadı"));
                return new SuccessDataResult<ICollection<ValidationRuleListResponseDto>>(getUser.Adapt<ICollection<ValidationRuleListResponseDto>>());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDataResult<ICollection<ValidationRuleListResponseDto>> GetValidationRuleCollection()
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getUser = _validationRuleDal.Queryable().ToList();

                if (getUser is null) return new ErrorDataResult<ICollection<ValidationRuleListResponseDto>>(String.Join("-", "Validasyon kuralı bulunamadı"));
                return new SuccessDataResult<ICollection<ValidationRuleListResponseDto>>(getUser.Adapt<ICollection<ValidationRuleListResponseDto>>());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
