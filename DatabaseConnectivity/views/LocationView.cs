﻿using DatabaseConnectivity.models;
using DatabaseConnectivity.objects;

namespace DatabaseConnectivity.views
{
    class LocationView
    {

        public static void LocationList()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<Location> locations = LocationModel.FindAllLocation();
            Console.Clear();

            Console.WriteLine("*** Country List ***\n");

            foreach (var location in locations)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("ID location      : {0}", location.Id);
                Console.WriteLine("Street Address   : {0}", location.StreetAddress);
                Console.WriteLine("Postal Code      : {0}", location.PostalCode);
                Console.WriteLine("City             : {0}", location.City);
                Console.WriteLine("State Province   : {0}", location.StateProvince);
                Console.WriteLine("Country          : {0}", location.Country.Name);
                Console.WriteLine("Region           : {0}", location.Country.Region.Name);
                Console.WriteLine("===========================");
            }


            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            GeneralView.HomePage();


        }
    }
}
