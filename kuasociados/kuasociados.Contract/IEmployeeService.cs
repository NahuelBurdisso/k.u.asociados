using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface IEmployeeService
    {
        int getLastestId();
        Employee getEmployeeById(int? id);
        List<Employee> getEmployees();
        void saveEmployee(People employee);

        void deleteEmployee(int id);

        void editEmployee(Employee Employee);
    }
}
