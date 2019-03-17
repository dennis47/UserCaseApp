using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userCase.Models
{
    public static class CityDistrictDefaultAdd
    {
        public static void CityDistrictList(IApplicationBuilder app)
        {
            UserContext context = app.ApplicationServices.GetRequiredService<UserContext>();
            //migration çalıştırmak için
            context.Database.Migrate();
            if (!context.Cities.Any())
            {
                context.Cities.AddRange(
                        new City() { cityCode = 01, cityName = "Adana" },
                        new City() { cityCode = 02, cityName = "Adıyaman" },
                        new City() { cityCode = 03, cityName = "Afyon" },
                        new City() { cityCode = 04, cityName = "Ağrı" },
                        new City() { cityCode = 05, cityName = "Amasya" },
                        new City() { cityCode = 34, cityName = "İstanbul" },
                        new City() { cityCode = 35, cityName = "İzmir" }
                    );
            }
            if (!context.Districts.Any())
            {
                context.Districts.AddRange(
                        new District() { districtCode = 1104, districtName = "SEYHAN"   , cityID = 1 },
                        new District() { districtCode = 1219, districtName = "CEYHAN"   , cityID = 1 },
                        new District() { districtCode = 1329, districtName = "FEKE"     , cityID = 1 },
                        new District() { districtCode = 1105, districtName = "MERKEZ"   , cityID = 2 },
                        new District() { districtCode = 1182, districtName = "BESNİ"    , cityID = 2 },
                        new District() { districtCode = 1246, districtName = "ÇELİKHAN" , cityID = 2 },
                        new District() { districtCode = 1103, districtName = "ADALAR"   , cityID = 3 },
                        new District() { districtCode = 1166, districtName = "BAKIRKÖY" , cityID = 3 },
                        new District() { districtCode = 1183, districtName = "BEŞİKTAŞ" , cityID = 3 },
                        new District() { districtCode = 1203, districtName = "BORNOVA"  , cityID = 3 },
                        new District() { districtCode = 1251, districtName = "ÇEŞME"    , cityID = 3 }                    );
            }
            context.SaveChanges();
        }
    }
}
