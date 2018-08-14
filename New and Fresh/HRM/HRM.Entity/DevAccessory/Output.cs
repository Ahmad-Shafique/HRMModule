using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity.DevAccessory
{
    public class Output
    {
        public static void Write(Object message)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(message.ToString());
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        public static void WriteLine(Object message)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(message.ToString());
                System.Diagnostics.Debug.WriteLine("\n");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            
        }
    }
}
