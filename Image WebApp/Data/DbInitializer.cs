using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Image_WebApp.Models;

namespace Image_WebApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(ImageContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Images.
            if (context.ImageUrls.Any())
            {
                return;   // DB has been seeded
            }

            var ImageUrls = new ImageUrl[]
            {
                new ImageUrl { ImageName = "Tiger", Url = "https://cdn.mos.cms.futurecdn.net/YB6aQqKZBVjtt3PuDSkJKe.jpg" },
                new ImageUrl { ImageName = "Lion", Url = "https://i.natgeofe.com/n/80b97fe3-c0fb-40a6-a6a6-88b5c3bb9d30/01-lion-populations-nationalgeographic_1777804.jpg" },
                new ImageUrl { ImageName = "Elephant", Url = "https://c402277.ssl.cf1.rackcdn.com/photos/14206/images/hero_small/WW187785.jpg?1576774644"}
            };
            foreach (ImageUrl i in ImageUrls)
            {
                context.ImageUrls.Add(i);
            }
            context.SaveChanges();
        }
    }
}
