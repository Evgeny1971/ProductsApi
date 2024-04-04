using InsuranceApiManagement.BusinessLayer.ViewModels;
using InsuranceApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApiManagement.BusinessLayer.Interfaces
{
    public interface IInsuranceApiService
    {
        List<InsurancePolicy> GetAllInsurancePolicies();
        Task<InsurancePolicy> CreateInsurancePolicy(InsurancePolicy insurancePolicy);
        Task<InsurancePolicy> GetInsurancePolicyById(long id);
        Task<bool> DeleteInsurancePolicyById(long id);
        Task<InsurancePolicy> UpdateInsurancePolicy(InsurancePolicyViewModel model);
    }
}
