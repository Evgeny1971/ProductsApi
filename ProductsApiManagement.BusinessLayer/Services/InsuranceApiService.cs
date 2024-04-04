using InsuranceApiManagement.BusinessLayer.Interfaces;
using InsuranceApiManagement.BusinessLayer.Services.Repository;
using InsuranceApiManagement.BusinessLayer.ViewModels;
using InsuranceApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApiManagement.BusinessLayer.Services
{
    public class InsuranceApiService : IInsuranceApiService
    {
        private readonly IInsuranceApiRepository _InsuranceApiRepository;

        public InsuranceApiService(IInsuranceApiRepository InsuranceApiRepository)
        {
            _InsuranceApiRepository = InsuranceApiRepository;
        }

        public async Task<InsurancePolicy> CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            return await _InsuranceApiRepository.CreateInsurancePolicy(insurancePolicy);
        }

        public async Task<bool> DeleteInsurancePolicyById(long id)
        {
            return await _InsuranceApiRepository.DeleteInsurancePolicyById(id);
        }

        public List<InsurancePolicy> GetAllInsurancePolicies()
        {
            return _InsuranceApiRepository.GetAllInsurancePolicies();
        }

        public async Task<InsurancePolicy> GetInsurancePolicyById(long id)
        {
            return await _InsuranceApiRepository.GetInsurancePolicyById(id);
        }

        public async Task<InsurancePolicy> UpdateInsurancePolicy(InsurancePolicyViewModel model)
        {
            return await _InsuranceApiRepository.UpdateInsurancePolicy(model);
        }
    }
}