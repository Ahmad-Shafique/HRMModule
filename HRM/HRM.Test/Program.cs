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
            IDomainService<AdvertiserList> service = new ServiceFactory().Create<AdvertiserList>();




            // Test Delete
            //AdvertiserList temp = service.Get(8).Result;
            bool x = service.RemoveByKey(7).Result;
            
            

            // Test GetAll
            List<AdvertiserList> list = service.GetAll().Result.ToList();
            Console.WriteLine("List is now : ");
            foreach(AdvertiserList item in list)
            {
                Console.WriteLine(item.AdvertiserName + "   " + item.ContactInfo + "    " + item.Description);
            }





            Console.ReadKey();




        }
    }
}
