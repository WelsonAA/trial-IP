//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart_item
    {
        public int cartItem_id { get; set; }
        public int product_id { get; set; }
        public Nullable<int> cartItem_product_qty { get; set; }
        public Nullable<System.DateTime> cartItem_date { get; set; }
        public Nullable<double> cart_total { get; set; }
        public Nullable<int> User_id { get; set; }
    
        public virtual person person { get; set; }
        public virtual product product { get; set; }
    }
}
