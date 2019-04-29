using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();
            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetPreconfiguredEventCategories());
                context.SaveChanges();
            }
            if (!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(GetPreconfiguredEventLocations());
                context.SaveChanges();
            }
            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetPreconfiguredEventItems());
                context.SaveChanges();
            }
        }

        private static IEnumerable<EventItem> GetPreconfiguredEventItems()
        {
            return new List<EventItem>()
            {
                new EventItem()
                { Name="Capital Hill Block Party",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/20/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =10,EventCategoryId=1,EventLocationId=2,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem()
                { Name="Sports Events",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/25/2019"),CreatedDate=Convert.ToDateTime("3/12/2019"),UpdatedDate=Convert.ToDateTime("3/24/2019"),
                    Price =8,EventCategoryId=2,EventLocationId=3,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/15" },
                new EventItem()
                 { Name="Sports Events",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("5/20/2019"),CreatedDate=Convert.ToDateTime("3/21/2019"),UpdatedDate=Convert.ToDateTime("3/30/2019"),
                    Price =15,EventCategoryId=2,EventLocationId=1,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/16" },
                new EventItem()
                 { Name="Event Management Software",Description="Exchange your ticket for one Pendrive at box office",
                    EventDate =Convert.ToDateTime("4/28/2019"),CreatedDate=Convert.ToDateTime("3/15/2019"),UpdatedDate=Convert.ToDateTime("3/24/2019"),
                    Price =10,EventCategoryId=5,EventLocationId=5,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventItem()
                 { Name="Festival Events",Description="Exchange your ticket for one SweetBox at box office",
                    EventDate =Convert.ToDateTime("4/25/2019"),CreatedDate=Convert.ToDateTime("3/11/2019"),UpdatedDate=Convert.ToDateTime("3/27/2019"),
                    Price =20,EventCategoryId=4,EventLocationId=6,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventItem()
                 { Name="Educational Event",Description="Exchange your ticket for one book at box office",
                    EventDate =Convert.ToDateTime("4/23/2019"),CreatedDate=Convert.ToDateTime("3/11/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =10,EventCategoryId=3,EventLocationId=7,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/4" },

                new EventItem()
                 { Name="Party Events",Description="Its Fun Event ",
                    EventDate =Convert.ToDateTime("5/20/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =10,EventCategoryId=7,EventLocationId=1,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem()
                 { Name="Successful Networking Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/23/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =10,EventCategoryId=6,EventLocationId=4,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                 new EventItem()
                 { Name="Successful Networking Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/23/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =15,EventCategoryId=6,EventLocationId=3,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/7" },

                  new EventItem()
                 { Name="Party Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/26/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =10,EventCategoryId=7,EventLocationId=4,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/8" },

                  new EventItem()
                 { Name="Party Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/23/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =12,EventCategoryId=7,EventLocationId=2,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/9" },

                   new EventItem()
                 { Name="Successful Networking Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("5/23/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =15,EventCategoryId=6,EventLocationId=1,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/10" },

                  new EventItem()
                 { Name="Festival Fun Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("5/23/2019"),CreatedDate=Convert.ToDateTime("3/11/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =10,EventCategoryId=4,EventLocationId=4,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/11" },

                 new EventItem()
                 { Name="Festival Fun Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/30/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =18,EventCategoryId=4,EventLocationId=6,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                  new EventItem()
                 { Name="Event Management Software",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/23/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =20,EventCategoryId=5,EventLocationId=6,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                   new EventItem()
                 { Name="Successful Networking Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/25/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =15,EventCategoryId=6,EventLocationId=4,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/14" },

                    new EventItem()
                 { Name="Party Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("4/26/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =10,EventCategoryId=7,EventLocationId=3,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/17" },
                 new EventItem()
                 { Name="Successful Networking Event",Description="Exchange your ticket for one wristband at box office",
                    EventDate =Convert.ToDateTime("5/23/2019"),CreatedDate=Convert.ToDateTime("3/1/2019"),UpdatedDate=Convert.ToDateTime("3/14/2019"),
                    Price =20,EventCategoryId=6,EventLocationId=3,EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/pic/18" },
            };
        }

        private static IEnumerable<EventCategory> GetPreconfiguredEventCategories()
        {
            return new List<EventCategory>()
            {
                new EventCategory()
                {CategoryName="Capital Hill Block Party"},
                new EventCategory()
                {CategoryName="Sports Events" },
                new EventCategory()
                {CategoryName="Educational Events" },
                new EventCategory()
                {CategoryName="Festivals Events" },
                new EventCategory()
                {CategoryName= "Event Management Software"},
                new EventCategory()
                {CategoryName="Successful Networking Event" },
                new EventCategory()
                {CategoryName="Party Events"}
            };
        }
        private static IEnumerable<EventLocation> GetPreconfiguredEventLocations()
        {
            return new List<EventLocation>()
            {
                new EventLocation()
                {LocationName="Mill Creek East"},
                new EventLocation()
                {LocationName="San Francisco California" },
                new EventLocation()
                {LocationName="London City of Westminster" },
                new EventLocation()
                {LocationName="NewYork UnitedStates" },
                new EventLocation()
                {LocationName= "Los Angeles California"},
                new EventLocation()
                {LocationName="Redmond Seattle" },
                new EventLocation()
                {LocationName="Illinois Chicago"}
            };
        }


    }
}
