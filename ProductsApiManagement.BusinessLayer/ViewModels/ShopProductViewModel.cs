using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApiManagement.BusinessLayer.ViewModels
{
    public class ShopProductViewModel
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }        
        public DateTime StartOfPrice { get; set; }
        public string Image { get; set; }        
    }
}
