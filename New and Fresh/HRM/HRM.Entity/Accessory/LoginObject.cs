using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity.Accessory
{
    public class LoginObject
    {
        public LoginObject(int id, string name, string image, Token token ,int accessCode, DateTime hireDate, int departmentId, int employeeBioId)
        {
            this.Id = id;
            this.Name = name;
            this.Image = image;
            this.Token = token;
            this.ViewAccessCode = accessCode;
            this.HireDate = hireDate;
            this.DepartmentId = departmentId;
            this.EmployeeBioId = employeeBioId;
        }

        public int Id { get; }
        public string Name { get; }
        public string Image { get; }
        public Token Token { get; }
        public int ViewAccessCode { get; }
        public DateTime HireDate { get; }
        public int DepartmentId { get; }
        public int EmployeeBioId { get; }
    }
}
