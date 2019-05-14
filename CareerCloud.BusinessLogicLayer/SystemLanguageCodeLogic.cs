using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic : SystemLanguageCodePoco
    {
        protected IDataRepository<SystemLanguageCodePoco> _repository; 
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
        {
            _repository = repository;
        }
        public void Add(SystemLanguageCodePoco[] pocos)
        {
            verify(pocos);
            _repository.Add(pocos);
        }
        public void Update(SystemLanguageCodePoco[] pocos)
        {
            verify(pocos);
            _repository.Update(pocos);
        }
        public SystemLanguageCodePoco Get(string id)
        {
            return _repository.GetSingle(c => c.LanguageID == id);
        }
        public List<SystemLanguageCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }
        public void Delete(SystemLanguageCodePoco[] pocos)
        {
            _repository.Remove(pocos);
        }


        public void verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(SystemLanguageCodePoco item in pocos)
            {
                if (string.IsNullOrEmpty(item.LanguageID))
                {
                    exceptions.Add(new ValidationException(1000, $"LanguageID for {item.LanguageID} Cannot be empty"));
                }
                if (string.IsNullOrEmpty(item.Name))
                {
                    exceptions.Add(new ValidationException(1001,$"Name for SystemLanguageCodePoco {item.LanguageID} can not be empty"));
                }
                if (string.IsNullOrEmpty(item.NativeName))
                {
                    exceptions.Add(new ValidationException(1002, $"NativeName for SystemLanguageCodePoco {item.LanguageID} can not be empty"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
