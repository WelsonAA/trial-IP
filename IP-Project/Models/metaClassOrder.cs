using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //b3ml add leh deh

namespace WebApplication1.Models
{


    [MetadataType(typeof(metadata_Order))]
    public partial class Order
    {
        //add new property
    }
    public class metadata_Order
    {

        public int Order_ID { get; set; }
        [Display(Name = "User ID")]
        
        public Nullable<int> User_ID { get; set; }
        [Display(Name = "Order Date")]

        public Nullable<System.DateTime> Order_Date { get; set; }
        [Display(Name = "Order Total Amount")]

        public Nullable<double> Total_Amount { get; set; }
        [Display(Name = "Order Payment method")]

        public string Payment_Method { get; set; }

    }
}