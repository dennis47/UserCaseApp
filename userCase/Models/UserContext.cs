using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userCase.Models
{ 
    public class UserContext : DbContext
    {
       public UserContext(DbContextOptions<UserContext> options) : base(options)
     //    public UserContext()
        {
            //Database.SetInitializer(new MyInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                        new City() { cityID = 1, cityCode = 01, cityName = "Adana" },
                        new City() { cityID = 2, cityCode = 02, cityName = "Adıyaman" },
                        new City() { cityID = 3, cityCode = 03, cityName = "Afyon" },
                        new City() { cityID = 4, cityCode = 04, cityName = "Ağrı" },
                        new City() { cityID = 5, cityCode = 05, cityName = "Amasya" },
                        new City() { cityID = 6, cityCode = 34, cityName = "İstanbul" },
                        new City() { cityID = 7, cityCode = 35, cityName = "İzmir" }
            );
            modelBuilder.Entity<District>().HasData(
                        new District() { districtID=1 , districtCode = 1104, districtName = "SEYHAN", cityID = 1 },
                        new District() { districtID=2 , districtCode = 1219, districtName = "CEYHAN", cityID = 1 },
                        new District() { districtID=3 , districtCode = 1329, districtName = "FEKE", cityID = 1 },
                        new District() { districtID=4 , districtCode = 1105, districtName = "MERKEZ", cityID = 2 },
                        new District() { districtID=5 , districtCode = 1182, districtName = "BESNİ", cityID = 2 },
                        new District() { districtID=6 , districtCode = 1246, districtName = "ÇELİKHAN", cityID = 2 },
                        new District() { districtID=7 , districtCode = 1103, districtName = "ADALAR", cityID = 3 },
                        new District() { districtID=8 , districtCode = 1166, districtName = "BAKIRKÖY", cityID = 3 },
                        new District() { districtID=9 , districtCode = 1183, districtName = "BEŞİKTAŞ", cityID = 3 },
                        new District() { districtID=10, districtCode = 1203, districtName = "BORNOVA", cityID = 3 },
                        new District() { districtID=11, districtCode = 1251, districtName = "ÇEŞME", cityID = 3 }
           );

            //modelBuilder.Entity<User>()
            //        .HasOne(p => p.City)
            //        .WithMany(b => b.Users)
            //        .IsRequired()
            //        .HasForeignKey(x => x.cityID)
            //        .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<User>()
            //       .HasOne(p => p.District)
            //       .WithMany(b => b.Users)
            //       .IsRequired()
            //       .HasForeignKey(x => x.districtID)
            //       .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<District>()
            //    .HasOne(p => p.City)
            //    .WithMany(b => b.Districts)
            //    .HasForeignKey(x => x.cityID)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.SetNull);

            /*
             * 
                      modelBuilder.Entity<User>()
                          .HasOne(p => p.City)
                          .WithMany(b => b.Users).HasForeignKey(x => x.cityID)
                          .OnDelete(DeleteBehavior.Cascade);

                         modelBuilder.Entity<User>()
                             .HasMany(p => p.City)
                             .WithOne(t => t.City)
                             .OnDelete(DeleteBehavior.SetNull);

                     modelBuilder.Entity<District>()
                             .HasMany(p => p.User)
                             .WithOne(t => t.District)
                             .OnDelete(DeleteBehavior.SetNull);

                         modelBuilder.Entity<City>()
                             .HasMany(p => p.District)
                             .WithOne(t => t.City)
                             .IsRequired()
                             .OnDelete(DeleteBehavior.SetNull);
                             */


            //modelBuilder.Entity<User>()
            //             .HasKey(x => x.userID);

            // modelBuilder.Entity<City>()
            //     .HasKey(x => x.cityID);

            // modelBuilder.Entity<District>()
            //            .HasKey(x => x.districtID);

            //modelBuilder.Entity<User>()
            //            .HasKey(x => new { x.cityID,x.districtID });


            //modelBuilder.Entity<Instructor>()
            //    .HasRequired(t => t.OfficeAssignment)
            //    .WithRequiredPrincipal(t => t.Instructor);


            //   modelBuilder.Entity<User>()
            //       .HasOne(x => x.District)
            //       .WithMany(e => e.Users)
            //       .HasForeignKey(y => y.districtID).OnDelete(DeleteBehavior.SetNull);

            //   modelBuilder.Entity<User>()
            //       .HasOne(x => x.City)
            //       .WithMany(e => e.Users)
            //       .HasForeignKey(y => y.cityID).OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<District>()
            //    .HasOne(x => x.City)
            //    .WithMany(e => e.Districts)
            //    .HasForeignKey(y => y.cityID).OnDelete(DeleteBehavior.SetNull);

        }

    }
    
}
