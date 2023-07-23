using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
    
        var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json") 
                        .Build();

        string connString = config.GetConnectionString("DefaultConnection");

        IDbConnection conn = new MySqlConnection(connString);
        var repo = new DapperDepartmentRepository(conn);

        Console.WriteLine("Type a new Department name");

        var newDepartment = Console.ReadLine();

        repo.InsertDepartment(newDepartment);

        var departmentRepo = new DapperDepartmentRepository(conn);

        //var departments = departmentRepo.GetALLDepartments();

        var departments = repo.GetALLDepartments();

        foreach (var department in departments) 
        {
        
            Console.WriteLine(department.DepartmentID);
            Console.WriteLine(department.Name);
            Console.WriteLine();
            Console.WriteLine();
        
        }
    }
}