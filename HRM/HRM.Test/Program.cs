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

        static void Main(string[] args)
        {
            /*
             * Salary calulation starts here
             */

            //IEnumerable<SalaryComponents> salCList = new ServiceFactory().Create<SalaryComponents>().GetAll().Result;

            //IEnumerable<EmployeeSalary> empSalList = new ServiceFactory().Create<EmployeeSalary>().GetAll().Result;

            //List<EmployeeSalary> newEmpSalList = new List<EmployeeSalary>();
            //foreach (EmployeeSalary empSalItem in empSalList)
            //{
            //    foreach (SalaryComponents sC in salCList)
            //    {
            //        if (sC.Type.Trim() == "credit")
            //        {
            //            empSalItem.TotalSalary -= (empSalItem.BasicSalary * sC.ComponentValue);
            //        }
            //        else if (sC.Type.Trim() == "debit")
            //        {
            //            empSalItem.TotalSalary += (empSalItem.BasicSalary * sC.ComponentValue);
            //        }


            //    }

            //    newEmpSalList.Add(empSalItem);
            //}
            //IEnumerable<EmployeeSalary> ienumerableEmpSal = (IEnumerable<EmployeeSalary>)newEmpSalList;

            //var resultList = from emp in new ServiceFactory().Create<Employee>().GetAll().Result
            //                 join empSal in ienumerableEmpSal on emp.EmployeeId equals empSal.EmployeeId
            //                 join salBonus in new ServiceFactory().Create<Bonus>().GetAll().Result on empSal.BonusId equals salBonus.BonusId
            //                 select new
            //                 {
            //                     EmployeeId = emp.EmployeeId,
            //                     EmployeeName = emp.EmployeeName,
            //                     TotalSalary = empSal.TotalSalary + salBonus.BonusValue,
            //                     BonusSalary = salBonus.BonusValue
            //                 };

            //Console.WriteLine("finished joining employee, salary and bonus");
            //Console.WriteLine("printing Final result now: ");
            //foreach (var item in resultList)
            //{
            //    Console.WriteLine("Employee: " + item.EmployeeName);
            //    Console.WriteLine("Total Salary: " + item.TotalSalary);
            //    Console.WriteLine("Bonus  Salary : " + item.BonusSalary);

            //}
            //Console.WriteLine("finished printing result: ");
            /*
             * Salary calulation ends here
             */








            ICommonViewService service = ServiceFactory.GetCommonViewService();
            var result = service.CalculateAllEmployeeTotalSalary().Result;
            Console.WriteLine("Request made to facade for calculated employee salary");
            //Console.WriteLine("Reply was: " + result);

            Console.WriteLine("Printing result now: ");

            int i = 0;
            foreach (var item in result)
            {
                Console.WriteLine("Data printing: "  +  i++);
                //Console.WriteLine(item.EmployeeName);
                Console.WriteLine(item.GetType());
            }
            Console.WriteLine("Printing result finished");


            Console.ReadKey();




        }
    }
}
