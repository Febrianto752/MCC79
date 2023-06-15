namespace DatabaseConnectivity.objects
{
    class Location
    {
        public int Id { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? StateProvince { get; set; }
        //public string? CountryId { get; set; }
        //public string? CountryName { get; set; }
        //public string? RegionName { get; set; }

        public Country Country { get; set; }

        public Location() { }

        public Location(int id, string sreetAddress, string postalCode, string city, string stateProvince, Country country)
        {
            Id = id;
            StreetAddress = sreetAddress;
            PostalCode = postalCode;
            City = city;
            StateProvince = stateProvince;
            this.Country = country;
        }
    }
}
