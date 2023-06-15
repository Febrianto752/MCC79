namespace DatabaseConnectivity.objects
{
    class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Region() { }
        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
