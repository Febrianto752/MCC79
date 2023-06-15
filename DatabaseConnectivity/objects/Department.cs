namespace DatabaseConnectivity.objects
{
    class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? LocationId { get; set; }
        public int? ManagerId { get; set; }

        public Department() { }
    }
}
