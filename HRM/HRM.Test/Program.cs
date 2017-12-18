using HRM.Data;
using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Test
{
    class Program
    {
        class Test
        {
            public static async Task<dynamic> TestMethod()
            {
                ICommonViewService Service = ServiceFactory.GetCommonViewService();
                return await Service.CalculateAllEmployeeTotalSalary(); 
            }
        }

        static void Main(string[] args)
        {

            var result = Test.TestMethod().Result;

            Console.WriteLine("Printing result now: ");

            foreach (var item in result)
            {
                Console.WriteLine(item.EmployeeName + " : " + item.TotalSalary);
            }
            Console.WriteLine("Printing result finished");


            Console.ReadKey();




        }
    }
}
