using HRM.Entity;
using HRM.Service;
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
            AdvertiserList adl = new AdvertiserList();
            adl.AdvertiserName = "New Test Advertiser List name";
            adl.ContactInfo = "???@advertiser.com";
            adl.Description = "weird guy with proper reach";

            AdvertiserListService service = new AdvertiserListService();

            service.Insert(adl);

            Console.WriteLine("Commands have been executed. Press any key to exit");
            Console.ReadKey();
        }
    }
}
