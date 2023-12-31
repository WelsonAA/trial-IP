using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //b3ml add leh deh

namespace WebApplication1.Models
{
    [MetadataType(typeof(metadadata_vouchers))] //bzwd deh kman // btsht8l only fel run time
    public partial class voucher
    {
        // public int MyProperty { get; set; }
        //add new property
    }

    public class metadadata_vouchers
    {
        public int voucher_id { get; set; }
        [Display(Name = "Voucher Code")]
        public string voucher_code { get; set; }
        [Display(Name = "Voucher Value")]
        public Nullable<double> voucher_value { get; set; }
        [Display(Name = "Voucher Quantity")]
        public Nullable<int> voucher_qty { get; set; }
    }
}