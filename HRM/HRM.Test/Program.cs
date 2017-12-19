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
            public static  dynamic TestMethod()
            {
                ICommonViewService Service = ServiceFactory.GetCommonViewService();
                return  Service.CalculateAllEmployeeTotalSalary(); 
            }
        }

        static void Main(string[] args)
        {

            //var result = Test.TestMethod();

            //Console.WriteLine("Printing result now: ");

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.EmployeeName + " : " + item.TotalSalary);
            //}
            //Console.WriteLine("Printing result finished");





            //var result = new ServiceFactory().Create<Department>().GetAll();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.DepartmentName);
            //}

            //var result = new ServiceFactory().Create<Equipment>().GetAll();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.BuyPrice);
            //}

            //var result = ServiceFactory.GetCommonViewService().GetAllEmployeePerformance();
            //foreach(var item in result)
            //{
            //    Console.WriteLine(item.EmployeeName + " " + item.ProjectScore + " " + item.TrainingScore + " " + item.AggregateScore);
            //}

            //var result = new ServiceFactory().Create<Interview>().GetAll();
            //var result2 = new ServiceFactory().Create<Interviewee>().GetAll();
            //Console.WriteLine(result.Count());
            //Console.WriteLine(result2.Count());



            var result = ServiceFactory.GetCommonViewService().CalculateAllEmployeeTotalSalary();
            Console.WriteLine("In program");
            foreach(var item in result)
            {
                Console.WriteLine(item.EmployeeName + " : " + item.TotalSalary);
            }











            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n Press any key to exit");
            Console.ReadKey();
        }
    }
}
