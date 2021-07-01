using System.Collections.Generic;
using ZadanieTestoweComAtCom.Model.Employee;
using ZadanieTestoweComAtCom.Model.Firm;

namespace ZadanieTestoweComAtCom.Repository
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll(Firm firm);
    }
}