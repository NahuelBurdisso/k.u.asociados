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
    public class EmployeeService : IEmployeeService
    {
        public KuasociadosEntities db { get; set; }
        public UserService userservice { get; set; }
        public EmployeeService()
        {
            this.db = new KuasociadosEntities();
        }

        public int getLastestId()
        {
            var result = db.Employees.ToList();
            if (result != null)
            {
                int id = db.Employees.Last().Id;
                return id;
            }
            else
            {
                return 0;
            }

        }

        public Employee getEmployeeById(int? id)
        {
            var employee = db.Employees.Where(x => (x.Id == id)).SingleOrDefault();


            Employee employee1 = new Employee()
            {
                Id = employee.Id,
                IdPerson = employee.IdPerson,
                FirstName = employee.Persons.FirstName,
                LastName = employee.Persons.LastName,
                Email = employee.Persons.Email,
                Dni = employee.Persons.Dni,
                Gender = employee.Persons.Gender,
                BornDate = employee.Persons.BornDate,
                City = employee.Persons.City,
                ProfileImg = employee.Persons.ProfileImg,
                Province = employee.Persons.Province,
                Codep = employee.Persons.Codep,
                Tel = employee.Persons.Tel,
                Job = employee.Job,
            };
            return employee1;
        }
        public List<Employee> getEmployees()
        {
            List<Employee> employees1 = new List<Employee>();
            var employeelist = db.Employees.ToList();
            foreach (Employees employee in employeelist)
            {
                Employee employeeitem = new Employee()
                {
                    Id = employee.Id,
                    FirstName = employee.Persons.FirstName,
                    LastName = employee.Persons.LastName,
                    Email = employee.Persons.Email,
                    Dni = employee.Persons.Dni,
                    Gender = employee.Persons.Gender,
                    BornDate = employee.Persons.BornDate,
                    City = employee.Persons.City,
                    ProfileImg = employee.Persons.ProfileImg,
                    Province = employee.Persons.Province,
                    Codep = employee.Persons.Codep,
                    Tel = employee.Persons.Tel,
                    Job = employee.Job,
                };

                employees1.Add(employeeitem);
            }
            return employees1;
        }
        public void saveEmployee(RegisterModel employee)
        {
            Persons person1 = new Persons();
            person1.FirstName = employee.FirstName;
            person1.LastName = employee.LastName;
            person1.Email = employee.Email;
            person1.Dni = employee.Dni;
            person1.Gender = employee.Gender;
            person1.BornDate = employee.BornDate;
            person1.City = employee.City;
            person1.ProfileImg = employee.ProfileImg;
            person1.Province = employee.Province;
            person1.Codep = employee.Codep;
            person1.Tel = employee.Tel;

            try
            {
                db.Persons.Add(person1);
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }



            int newid = this.userservice.getLastestPersonId();


            Employees employee1 = new Employees();
            employee1.IdPerson = newid;

            db.Employees.Add(employee1);
            db.SaveChanges();
        }

        public void deleteEmployee(int id)
        {
            Employees employee = db.Employees.Where(x => (x.Id == id)).SingleOrDefault();
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public void editEmployee(Employee employee)
        {
            var result = db.Employees.SingleOrDefault(x => x.Id == employee.Id);
            if (result != null)
            {
                result.Id = employee.Id;
                result.Job = employee.Job;
                result.Persons.LastName = employee.LastName;
                result.Persons.Email = employee.Email;
                result.Persons.Dni = employee.Dni;
                result.Persons.Gender = employee.Gender;
                result.Persons.BornDate = employee.BornDate;
                result.Persons.City = employee.City;
                result.Persons.ProfileImg = employee.ProfileImg;
                result.Persons.Province = employee.Province;
                result.Persons.Codep = employee.Codep;
                result.Persons.Tel = employee.Tel;
                db.SaveChanges();
            }
        }

    
    }
}
