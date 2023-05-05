using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IEmployeeRep
    {

        IEnumerable<Employee> Get();

        Employee GetById(int id);
        IEnumerable<Employee> SearchByName(string Name);
        Employee Create(Employee obj);
        Employee Edit(Employee obj);
        void Delete(Employee obj);


    }
}
