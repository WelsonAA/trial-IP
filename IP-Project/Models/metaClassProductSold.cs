using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //b3ml add leh deh

namespace WebApplication1.Models
{


    [MetadataType(typeof(metadata_productsold))] //bzwd deh kman // btsht8l only fel run time
    public partial class productSold
    {
        
    }

    public class metadata_productsold
    {
        //edit property
        public int product_id { get; set; }
        [Display(Name = "Product Quantity")]

        public Nullable<int> product_quantity { get; set; }
        [Display(Name = "Product Price")]

        public Nullable<int> product_price { get; set; }
        [Display(Name = "Product Date")]

        public Nullable<System.DateTime> product_date { get; set; }
        /***************************************************/

    }
}