﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALLocalDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AzureEntities : DbContext
    {
        public AzureEntities()
            : base("name=AzureEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<Basket_items> Basket_items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Category_type> Category_type { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<News_image> News_image { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_items> Order_items { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitInfo> UnitInfoes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Slider_images> Slider_images { get; set; }
    }
}
