using DatabaseConnectivity.models;

namespace DatabaseConnectivity.views
{
    class LinqView
    {
        public static void Task()
        {
            Console.WriteLine("*** Tugas Linq ***");
            Console.WriteLine("Soal : ");
            Console.WriteLine("1. Buatlah **Method LINQ** untuk menampilkan data dengan kriteria berikut :");
            Console.WriteLine("\t1. Data employee\r\n\t2. Tambahkan informasi nama department\r\n\t3. Tambahkan informasi lokasi\r\n\t4. Tambahkan informasi country\r\n\t5. Tambahkan informasi region\r\n\t6. Limit data yang tampil hanya 5\n\tcolumn yang tampil : id, full_name, email, phone, salary, department_name, street_address, country_name, region_name.\n");

            Console.WriteLine("2. Buatlah **Method LINQ** untuk menampilkan data dengan kriteria berikut :");
            Console.WriteLine("\t1. Jumlah employeee pada tiap department\r\n\t2. gaji terkecil, gaji terbesar, gaji rata rata pada tiap department\r\n\t3. tampilkan data yang hanya jumlah employee lebih dari 3\r\n\tcolumn yang tampil : department_name, total_employee, min_salary, max_salary, average_salary");

            Console.WriteLine("\n*******************");
            Console.Write("Tampilkan hasil soal nomor : ");
            int nomor = default;

            try
            {
                nomor = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input!!!");
                Console.ReadKey();
                GeneralView.HomePage();
            }

            switch (nomor)
            {
                case 1:
                    Soal1();
                    break;
                case 2:
                    Soal2();
                    break;
                default:
                    Console.WriteLine("Invalid input!!!");
                    Console.ReadKey();
                    GeneralView.HomePage();
                    break;

            }

        }

        public static void Soal1()
        {
            Console.Clear();
            // column yang tampil : id, full_name, email, phone, salary, department_name, street_address, country_name, region_name
            //var employees = (from e in EmployeeModel.FindAllEmployee()
            //                 join j in JobModel.FindAllJob() on e.JobId equals j.Id
            //                 join d in DepartmentModel.FindAllDepartment() on e.DepartmentId equals d.Id
            //                 join l in LocationModel.FindAllLocation() on d.LocationId equals l.Id 
            //                 join c in CountryModel.FindAllCountry() on l.CountryId equals c.Id
            //                 join r in RegionModel.FindAllRegion() on c.RegionId equals r.Id
            //                 select new
            //                 {
            //                     Id = e.Id,
            //                     Fullname = e.last_name,
            //                     Job = j.title,
            //                     Department = d.name
            //                 });

            // column yang tampil : id, full_name, email, phone, salary, department_name, street_address, country_name, region_name
            var employees = EmployeeModel.FindAllEmployee()
                                .Join(DepartmentModel.FindAllDepartment(),
                                      e => e.DepartmentId,
                                      d => d.Id,
                                      (e, d) => new
                                      {
                                          Id = e.Id,
                                          Fullname = e.FirstName + " " + e.LastName,
                                          Email = e.Email,
                                          Phone = e.PhoneNumber,
                                          Salary = e.Salary,
                                          DepartmentName = d.Name,
                                          LocationId = d.LocationId,
                                      }).Join(LocationModel.FindAllLocation(),
                                      d => d.LocationId,
                                      l => l.Id,
                                      (d, l) => new
                                      {
                                          Id = d.Id,
                                          Fullname = d.Fullname,
                                          Email = d.Email,
                                          Phone = d.Phone,
                                          Salary = d.Salary,
                                          DepartmentName = d.DepartmentName,
                                          StreetAddress = l.StreetAddress,
                                          CountryId = l.CountryId,
                                      }).Join(CountryModel.FindAllCountry(),
                                      l => l.CountryId,
                                      c => c.Id,
                                      (l, c) => new
                                      {
                                          Id = l.Id,
                                          Fullname = l.Fullname,
                                          Email = l.Email,
                                          Phone = l.Phone,
                                          Salary = l.Salary,
                                          DepartmentName = l.DepartmentName,
                                          StreetAddress = l.StreetAddress,
                                          CountryName = c.Name,
                                          RegionId = c.RegionId
                                      }).Join(RegionModel.FindAllRegion(),
                                      c => c.RegionId,
                                      r => r.Id,
                                      (c, r) => new
                                      {
                                          Id = c.Id,
                                          Fullname = c.Fullname,
                                          Email = c.Email,
                                          Phone = c.Phone,
                                          Salary = c.Salary,
                                          DepartmentName = c.DepartmentName,
                                          StreetAddress = c.StreetAddress,
                                          CountryName = c.CountryName,
                                          RegionName = r.Name
                                      }).Take(5);

            Console.WriteLine("Result : \n");
            foreach (var e in employees)
            {

                Console.WriteLine($"ID Employee : {e.Id}");
                Console.WriteLine($"Fullname : {e.Fullname}");
                Console.WriteLine($"Email : {e.Email}");
                Console.WriteLine($"Phone : {e.Phone}");
                Console.WriteLine($"Salary : {e.Salary}");
                Console.WriteLine($"Department : {e.DepartmentName}");
                Console.WriteLine($"Street Address : {e.StreetAddress}");
                Console.WriteLine($"Country : {e.CountryName}");
                Console.WriteLine($"Region : {e.RegionName}");
                Console.WriteLine("======================\n");
            }

            Console.ReadKey();
            GeneralView.HomePage();
        }

        public static void Soal2()
        {
            Console.Clear();

            //1.Jumlah employeee pada tiap department
            //2.gaji terkecil, gaji terbesar, gaji rata rata pada tiap department
            //3.tampilkan data yang hanya jumlah employee lebih dari 3
            // department_name, total_employee, min_salary, max_salary, average_salary
            var departments = EmployeeModel.FindAllEmployee()
                                .Join(DepartmentModel.FindAllDepartment(),
                                      e => e.DepartmentId,
                                      d => d.Id,
                                      (e, d) => new
                                      {
                                          Id = e.Id,
                                          Salary = e.Salary,
                                          DepartmentName = d.Name,
                                      }).GroupBy(e => e.DepartmentName).Where(e => e.Count() > 3).ToList();
            Console.WriteLine("Result : \n");

            foreach (var d in departments)
            {

                Console.WriteLine("Department name : {0}", d.Key);
                Console.WriteLine("Total Employee : {0}", d.Count());
                Console.WriteLine("Min salary : {0}", d.Min(e => e.Salary));
                Console.WriteLine("Max salary : {0}", d.Max(e => e.Salary));
                Console.WriteLine("Average salary : {0}", d.Average(e => e.Salary));
                Console.WriteLine("======================\n");
                //foreach (var x in d)
                //{
                //    Console.WriteLine(x.Id);
                //    Console.WriteLine(x.Salary);
                //}
            }

            Console.ReadKey();
            GeneralView.HomePage();
        }
    }
}
