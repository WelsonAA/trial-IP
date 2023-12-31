using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //b3ml add leh deh

namespace WebApplication1.Models
{

    [MetadataType(typeof(metadata_product))] //bzwd deh kman // btsht8l only fel run time
    public partial class product
    {
       // public int MyProperty { get; set; }
        //add new property
    }

    public class metadata_product
    {
        //edit property
        public int product_id { get; set; }
        /***************************************************/
        [Display(Name = "Product Brand name")]
        public string product_brand_name { get; set; }
        /***************************************************/
        [Display(Name = "Product name")]
        public string product_name { get; set; }
        /***************************************************/
        [Display(Name = "Product price")]
        public Nullable<int> product_price { get; set; }
        /***************************************************/

        [Display(Name = "Product description")]
        public string product_desc { get; set; }
        /***************************************************/

        [Display(Name = "Product quantity")]
        public Nullable<int> product_qty { get; set; }
        /***************************************************/

        [Display(Name = "Product type")]

        public string product_type { get; set; }
        /***************************************************/

        [Display(Name = "Product size")]
        public string product_size { get; set; }
        /***************************************************/

        [Display(Name = "Product rating")]
        [Range(0,5,ErrorMessage = "Rating must be from 0 to 5")]

        public Nullable<int> product_rating { get; set; }
        
        /***************************************************/
        [Display(Name = "Product image")]

        public string product_image { get; set; }

        /***************************************************/

    }

}