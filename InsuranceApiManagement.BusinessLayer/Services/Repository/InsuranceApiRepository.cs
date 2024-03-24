using InsuranceApiManagement.BusinessLayer.ViewModels;
using InsuranceApiManagement.DataLayer;
using InsuranceApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApiManagement.BusinessLayer.Services.Repository
{
    public class InsuranceApiRepository : IInsuranceApiRepository
    {
        private readonly InsuranceDbContext _dbContext;
        public InsuranceApiRepository(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<InsurancePolicy> CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            try
            {
                var result = await _dbContext.InsurancePolicies.AddAsync(insurancePolicy);
                await _dbContext.SaveChangesAsync();
                return insurancePolicy;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteInsurancePolicyById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.InsurancePolicies.Single(a => a.PolicyId == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<InsurancePolicy> GetAllInsurancePolicies()
        {
            try
            {
                var result = _dbContext.InsurancePolicies.
                OrderByDescending(x => x.PolicyId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<InsurancePolicy> GetInsurancePolicyById(long id)
        {
            try
            {
                return await _dbContext.InsurancePolicies.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<InsurancePolicy> UpdateInsurancePolicy(InsurancePolicyViewModel model)
        {
            var policy = await _dbContext.InsurancePolicies.FindAsync(model.PolicyId);
            try
            {
                policy.StartDate = model.StartDate;
                policy.PolicyNumber = model.PolicyNumber;
                policy.PolicyId = model.PolicyId;
                policy.CustomerId = model.CustomerId;
                policy.EndDate = model.EndDate;
                policy.IsActive = model.IsActive;
                policy.PolicyType = model.PolicyType;

                _dbContext.InsurancePolicies.Update(policy);
                await _dbContext.SaveChangesAsync();
                return policy;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}