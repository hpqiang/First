namespace LNDL.EFDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Sample : DbContext
    {
        public Sample()
            : base("name=SampleConnection")
        {
            Console.Write("Contructing user sample...\n");
        }

        //public virtual DbSet<Employees> Employees { get; set; }
        //public virtual DbSet<tblCarrier> tblCarrier { get; set; }
        //public virtual DbSet<tblCategory> tblCategory { get; set; }
        //public virtual DbSet<tblClientProduct> tblClientProduct { get; set; }
        //public virtual DbSet<tblColor> tblColor { get; set; }
        //public virtual DbSet<tblColorCode> tblColorCode { get; set; }
        //public virtual DbSet<tblCompany> tblCompany { get; set; }
        //public virtual DbSet<tblCompanyType> tblCompanyType { get; set; }
        //public virtual DbSet<tblCurtain> tblCurtain { get; set; }
        //public virtual DbSet<tblCurtainColorMapping> tblCurtainColorMapping { get; set; }
        //public virtual DbSet<tblCurtainInsertCard> tblCurtainInsertCard { get; set; }
        //public virtual DbSet<tblCurtainSize> tblCurtainSize { get; set; }
        //public virtual DbSet<tblCurtainSizeMapping> tblCurtainSizeMapping { get; set; }
        //public virtual DbSet<tblCurtainUPC> tblCurtainUPC { get; set; }
        //public virtual DbSet<tblDrapery> tblDrapery { get; set; }
        //public virtual DbSet<tblFabric> tblFabric { get; set; }
        //public virtual DbSet<tblFabricSize> tblFabricSize { get; set; }
        //public virtual DbSet<tblManufacturing> tblManufacturing { get; set; }
        //public virtual DbSet<tblOrder> tblOrder { get; set; }
        //public virtual DbSet<tblOrderClientVendorMapping> tblOrderClientVendorMapping { get; set; }
        //public virtual DbSet<tblOrderFromClient> tblOrderFromClient { get; set; }
        //public virtual DbSet<tblOrderHistory> tblOrderHistory { get; set; }
        //public virtual DbSet<tblOrderToVendor> tblOrderToVendor { get; set; }
        //public virtual DbSet<tblPattern> tblPattern { get; set; }
        //public virtual DbSet<tblPerson> tblPerson { get; set; }
        //public virtual DbSet<tblProduct> tblProduct { get; set; }
        //public virtual DbSet<tblProductType> tblProductType { get; set; }
        //public virtual DbSet<tblRawTextile> tblRawTextile { get; set; }
        //public virtual DbSet<tblResetPasswordRequests> tblResetPasswordRequests { get; set; }
        //public virtual DbSet<tblSale> tblSale { get; set; }
        //public virtual DbSet<tblShipping> tblShipping { get; set; }
        //public virtual DbSet<tblShippingMarkBase> tblShippingMarkBase { get; set; }
        //public virtual DbSet<tblShippingMarkCurtain> tblShippingMarkCurtain { get; set; }
        //public virtual DbSet<tblShippingMarkFabric> tblShippingMarkFabric { get; set; }
        //public virtual DbSet<tblStock> tblStock { get; set; }
        public virtual DbSet<tblUsers> tblUsers { get; set; }
        //public virtual DbSet<tblVendorProduct> tblVendorProduct { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<tblCategory>()
            //    .HasMany(e => e.tblClientProduct)
            //    .WithRequired(e => e.tblCategory)
            //    .HasForeignKey(e => e.categoryID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblColor>()
            //    .HasMany(e => e.tblFabric)
            //    .WithRequired(e => e.tblColor)
            //    .HasForeignKey(e => e.colorID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblColor>()
            //    .HasMany(e => e.tblRawTextile)
            //    .WithRequired(e => e.tblColor)
            //    .HasForeignKey(e => e.colorID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblCompany>()
            //    .HasMany(e => e.tblClientProduct)
            //    .WithRequired(e => e.tblCompany)
            //    .HasForeignKey(e => e.companyID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblCompany>()
            //    .HasMany(e => e.tblOrderClientVendorMapping)
            //    .WithOptional(e => e.tblCompany)
            //    .HasForeignKey(e => e.clientId);

            //modelBuilder.Entity<tblCompany>()
            //    .HasMany(e => e.tblOrderClientVendorMapping1)
            //    .WithOptional(e => e.tblCompany1)
            //    .HasForeignKey(e => e.vendorId);

            //modelBuilder.Entity<tblCompany>()
            //    .HasMany(e => e.tblVendorProduct)
            //    .WithRequired(e => e.tblCompany)
            //    .HasForeignKey(e => e.companyID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblCurtain>()
            //    .HasMany(e => e.tblClientProduct)
            //    .WithRequired(e => e.tblCurtain)
            //    .HasForeignKey(e => e.productID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblCurtain>()
            //    .HasMany(e => e.tblVendorProduct)
            //    .WithRequired(e => e.tblCurtain)
            //    .HasForeignKey(e => e.productID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblDrapery>()
            //    .HasMany(e => e.tblClientProduct)
            //    .WithRequired(e => e.tblDrapery)
            //    .HasForeignKey(e => e.productID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblDrapery>()
            //    .HasMany(e => e.tblVendorProduct)
            //    .WithRequired(e => e.tblDrapery)
            //    .HasForeignKey(e => e.productID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblFabricSize>()
            //    .HasMany(e => e.tblFabric)
            //    .WithOptional(e => e.tblFabricSize)
            //    .HasForeignKey(e => e.widthID);

            //modelBuilder.Entity<tblManufacturing>()
            //    .HasMany(e => e.tblShipping)
            //    .WithOptional(e => e.tblManufacturing)
            //    .HasForeignKey(e => e.manufacturingID);

            //modelBuilder.Entity<tblOrderFromClient>()
            //    .Property(e => e.unitPrice)
            //    .HasPrecision(19, 4);

            //modelBuilder.Entity<tblOrderToVendor>()
            //    .Property(e => e.unitPrice)
            //    .HasPrecision(19, 4);

            //modelBuilder.Entity<tblPattern>()
            //    .HasMany(e => e.tblRawTextile)
            //    .WithOptional(e => e.tblPattern)
            //    .HasForeignKey(e => e.patternID);

            //modelBuilder.Entity<tblRawTextile>()
            //    .Property(e => e.description)
            //    .IsUnicode(false);

            //modelBuilder.Entity<tblRawTextile>()
            //    .HasMany(e => e.tblDrapery)
            //    .WithRequired(e => e.tblRawTextile)
            //    .HasForeignKey(e => e.rawTextileID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblRawTextile>()
            //    .HasMany(e => e.tblFabric)
            //    .WithRequired(e => e.tblRawTextile)
            //    .HasForeignKey(e => e.rawTextileID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<tblSale>()
            //    .Property(e => e.UnitPrice)
            //    .HasPrecision(19, 4);

            //modelBuilder.Entity<tblShippingMarkBase>()
            //    .Property(e => e.POnumber)
            //    .IsUnicode(false);

            //modelBuilder.Entity<tblShippingMarkBase>()
            //    .Property(e => e.itemName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<tblUsers>()
            //    .HasMany(e => e.tblResetPasswordRequests)
            //    .WithOptional(e => e.tblUsers)
            //    .HasForeignKey(e => e.userID);
        }
    }
}
