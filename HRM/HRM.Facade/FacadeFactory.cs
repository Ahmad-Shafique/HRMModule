using HRM.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Facade
{
    public class FacadeFactory
    {
        public static ICommonView GetCommonView()
        {
            return new CommonView();
        }
    }
}
