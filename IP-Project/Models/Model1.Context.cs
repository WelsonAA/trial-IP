﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TopG_clothingEntities2 : DbContext
    {
        public TopG_clothingEntities2()
            : base("name=TopG_clothingEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<Cart_item> Cart_item { get; set; }
        public virtual DbSet<cartItem> cartItems { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<productSold> productSolds { get; set; }
        public virtual DbSet<store> stores { get; set; }
        public virtual DbSet<voucherCustomer> voucherCustomers { get; set; }
        public virtual DbSet<voucher> vouchers { get; set; }
        public virtual DbSet<wishlist> wishlists { get; set; }
    }
}
