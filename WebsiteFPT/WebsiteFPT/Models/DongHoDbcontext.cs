using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebsiteFPT.Models
{
    public partial class DongHoDbcontext : DbContext
    {
        public DongHoDbcontext()
            : base("name=DongHoDbcontext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<attr_order> Attr_Orders { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
       
        public virtual DbSet<FeedBack> Feedbacks { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        
        public virtual DbSet<Order> Orders { get; set; }
        
        public virtual DbSet<Product> Products { get; set; }
        
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
   
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Values_product> Values_products { get; set; }
        public virtual DbSet<altribute> altributes { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
        
        public virtual DbSet<Values> Values { get; set; }
        public virtual DbSet<VariantValue> VariantValues { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Variant>()
                .Property(e => e.ID_Variant);
            modelBuilder.Entity<Values>()
                .Property(e => e.ID_Values);
            modelBuilder.Entity<VariantValue>()
                .Property(e => e.ID_VariantValue);
        }
    }
}
