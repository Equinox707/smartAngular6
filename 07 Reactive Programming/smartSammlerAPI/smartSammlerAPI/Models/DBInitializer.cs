using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartSammlerAPI
{
    public static class DBInitializer
    {
        public static void Initialize(SammlerDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.MarkerTypes.FirstOrDefault() == null)
            {
                var mt1 = new MarkerType { label = "Beeren" };
                var mt2 = new MarkerType { label = "Schwammerl" };
                var mt3 = new MarkerType { label = "Holunderblüten" };

                context.MarkerTypes.AddRange(mt1, mt2, mt3);

                var m1 = new Marker
                {                    
                    imgURL = "/assets/images/beeren.png",
                    lable = "Beerenplatz Waldviertel",
                    type = 1,
                    lat = 48.5839237,
                    lng = 15.4276355,
                    remark = "Als Beere gilt in der Botanik eine aus einem einzigen Fruchtknoten hervorgegangene Schließfrucht, bei der die komplette Fruchtwand (Perikarp) auch noch bei der Reife saftig oder mindestens fleischig ist"
                };

                var m2 = new Marker
                {
                    imgURL = "/assets/images/schwammerl.png",
                    lable = "Schwammerlplatz Stmk",
                    type = 1,
                    lat = 47.5308866,
                    lng = 15.9476211,
                    remark = "Als Beere gilt in der Botanik eine aus einem einzigen Fruchtknoten hervorgegangene Schließfrucht, bei der die komplette Fruchtwand (Perikarp) auch noch bei der Reife saftig oder mindestens fleischig ist"
                };

                var m3 = new Marker
                {
                    imgURL = "/assets/images/holler.png",
                    lable = "Holler in Neuwaldegg",
                    type = 1,
                    lat = 48.234201,
                    lng = 16.277753,
                    remark = "Als Beere gilt in der Botanik eine aus einem einzigen Fruchtknoten hervorgegangene Schließfrucht, bei der die komplette Fruchtwand (Perikarp) auch noch bei der Reife saftig oder mindestens fleischig ist"
                };

                context.Markers.AddRange(m1, m2, m3);
                context.SaveChanges();
            }

        }
    }
}
