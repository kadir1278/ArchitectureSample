using AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.User;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.User;
using EntityLayer.Dto.ValidationRule;
using EntityLayer.Entity;
using System.Security;

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


        public IDataResult<ValidationRule> AddValidationRules(ValidationRuleAddDto validationRuleAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                var addedUser = _validationRuleDal.Add(validationRuleAddDto, _ct);
                if (!addedUser.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<ValidationRule>("Kullanıcı eklenemedi");
                }
                _worker.CommitAndSaveChanges();
                return addedUser;
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<ValidationRule>(ex);
            }
        }

        public IDataResult<ICollection<ValidationRule>> GetValidationRuleCollection()
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getUser = _validationRuleDal.QueryableGlobalFilter().ToList();

                if (getUser is null) return new ErrorDataResult<ICollection<ValidationRule>>(String.Join("-", "Validasyon kuralı bulunamadı"));
                return new SuccessDataResult<ICollection<ValidationRule>>(getUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
