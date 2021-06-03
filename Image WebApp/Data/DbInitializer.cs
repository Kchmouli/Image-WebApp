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
                new ImageUrl { ImageId = 1, ImageName = "Tiger", Url = "https://cdn.mos.cms.futurecdn.net/YB6aQqKZBVjtt3PuDSkJKe.jpg" },
                new ImageUrl { ImageId = 1, ImageName = "Lion", Url = "https://i.natgeofe.com/n/80b97fe3-c0fb-40a6-a6a6-88b5c3bb9d30/01-lion-populations-nationalgeographic_1777804.jpg" },
            };
            foreach (ImageUrl i in ImageUrls)
            {
                context.ImageUrls.Add(i);
            }
            context.SaveChanges();
        }
    }
}
