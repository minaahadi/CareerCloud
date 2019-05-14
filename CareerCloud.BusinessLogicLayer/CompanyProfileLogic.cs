using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository):base(repository)
        {

        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyProfilePoco item in pocos)
            {
                if(!string.IsNullOrEmpty(item.CompanyWebsite))
                {
                    if (!(new[] { ".ca", ".com", ".biz" }.Any(x => item.CompanyWebsite.EndsWith(x))))
                    {
                        exceptions.Add(new ValidationException(600, $"Valid websites for CompanyProfile {item.Id} must end with the following extensions – '.ca', '.com', '.biz'"));
                    }
                }
               
              
                if (string.IsNullOrEmpty(item.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, $"PhoneNumber for CompanyProfile {item.Id} is required"));
                }
                else
                {
                    string[] phoneComponent = item.ContactPhone.Split('-');
                    if (phoneComponent.Length < 3)
                    {
                        exceptions.Add(new ValidationException(601, $"PhoneNumber for CompanyProfile {item.Id} is not in the required format."));
                    }
                    else
                    {

                        if (phoneComponent[0].Length < 3)
                        {
                            exceptions.Add(new ValidationException(601, $"PhoneNumber for CompanyProfile {item.Id} is not in the required format."));
                        }
                        if (phoneComponent[1].Length < 3)
                        {
                            exceptions.Add(new ValidationException(601, $"PhoneNumber for CompanyProfile {item.Id} is not in the required format."));
                        }
                        if (phoneComponent[2].Length < 4)
                        {
                            exceptions.Add(new ValidationException(601, $"PhoneNumber for CompanyProfile {item.Id} is not in the required format."));
                        }
                    }
                }
            }
            if(exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
