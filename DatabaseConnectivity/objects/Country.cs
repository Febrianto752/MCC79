namespace DatabaseConnectivity.objects
{
    class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public int RegionId { get; set; }

        public Region Region { get; set; }

        //public string RegionName { get; set; }

        public Country() { }
        public Country(string id, string name, Region region)
        {
            this.Id = id;
            this.Name = name;
            this.Region = region;
        }
    }
}
