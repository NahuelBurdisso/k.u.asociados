using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;
using kuasociados.Contract;
using kuasociados.Data;

namespace kuasociados.Services
{
    public class UserService: IUserService
    {
        public KuasociadosEntities db { get; set; }

        public LawyerService lawyerservice { get; set; }
        public ClientService clientservice { get; set; }
        public EmployeeService employeeservice { get; set; }

        public UserService()
        {

            this.db = new KuasociadosEntities();
        }

      
        
        public int getLastestPersonId()
        {
            var result = db.Persons.ToList().LastOrDefault();
            if (result != null)
            {
                int id = result.Id;
                return id;
            }
            else
            {
                return 0;
            }
        }

        public Lawyer getLawyerbyUserId(int userid)
        {
            Users user = db.Users.Where(x => (x.UserId == userid)).SingleOrDefault();
            int personid = db.Persons.Where(x => (x.Id == user.IdPerson)).SingleOrDefault().Id;
            int lawyerid = db.Lawyers.Where(x => (x.IdPerson == personid)).SingleOrDefault().Id;
            this.lawyerservice = new LawyerService();
            Lawyer lawyer = this.lawyerservice.getLawyerById(lawyerid);
            return lawyer;
        }

        public Client getClientbyUserId(int userid)
        {
            Users user = db.Users.Where(x => (x.UserId == userid)).SingleOrDefault();
            int personid = db.Persons.Where(x => (x.Id == user.IdPerson)).SingleOrDefault().Id;
            int clientid = db.Clients.Where(x => (x.IdPerson == personid)).SingleOrDefault().Id;
            this.clientservice = new ClientService();
            Client client = this.clientservice.getClientById(clientid);
            return client;
        }

        public Employee getEmployeebyUserId(int userid)
        {
            Users user = db.Users.Where(x => (x.UserId == userid)).SingleOrDefault();
            int personid = db.Persons.Where(x => (x.Id == user.IdPerson)).SingleOrDefault().Id;
            int employeeid = db.Employees.Where(x => (x.IdPerson == personid)).SingleOrDefault().Id;
            this.employeeservice = new EmployeeService();
            Employee employee = this.employeeservice.getEmployeeById(employeeid);
            return employee;
        }
    }
}
