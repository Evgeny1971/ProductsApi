using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductsApiManagement.Entities
{
    public class ShopProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }        
        public DateTime StartOfPrice { get; set; }
        public string Image { get; set; }        

    }

}
