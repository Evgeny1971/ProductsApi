using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceApiManagement.BusinessLayer.ViewModels
{
    public class InsurancePolicyViewModel
    {
        public long ID { get; set; }
        public string PolicyNumber { get; set; }
        public decimal InsuranceAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int UserID { get; set; }
    }
}
