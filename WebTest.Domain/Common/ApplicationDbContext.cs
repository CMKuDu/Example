using Microsoft.EntityFrameworkCore;
using WebTest.Domain.Model;

namespace WebTest.Domain.Common
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> ops)
            : base(ops) { }
        public DbSet<Product> Produt { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Customer> Customers { get; set; }
        // Hotel
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<AddressHotel> AddressHotels {  get; set; }
        public DbSet<Service> Services { get; set; }
        //public DbSet<SubService> SubServices {  get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms {  get; set; }
        //public DbSet<RoomTypeBedType> RoomTypeBedTypes {  get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<SubService>()
            //    .HasOne(ss => ss.Service)
            //    .WithMany(s => s.SubServices)
            //    .HasForeignKey(ss => ss.ServiceId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Rooms)
                .WithMany(bb => bb.Bookings)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<RoomTypeBedType>()
            //    .HasKey(rtbt => new { rtbt.RoomTypeId, rtbt.BedTypeId });

            //modelBuilder.Entity<RoomTypeBedType>()
            //    .HasOne(rtbt => rtbt.RoomType)
            //    .WithMany(bt => bt.RoomTypeBedTypes)
            //    .HasForeignKey(rtbt => rtbt.RoomTypeId);

            //modelBuilder.Entity<RoomTypeBedType>()
            //    .HasOne(rtbt => rtbt.BedType)
            //    .WithMany(bt => bt.RoomTypeBedTypes)
            //    .HasForeignKey(rtbt => rtbt.BedTypeId);

            modelBuilder.Entity<RoomType>()
                .HasOne(rt => rt.PriceTypes)
                .WithOne(pt => pt.RoomType)
                .HasForeignKey<PriceType>(rp => rp.RoomTypeId);

        }
    }
}
