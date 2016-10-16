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
    public class ClientService : IClientService
    {
        public KuasociadosEntities db { get; set; }

        public ClientService()
        {
            this.db = new KuasociadosEntities();
        }

        public int getLastestId()
        {
            var result = db.Clients.ToList();
            if (result != null)
            {
                int id = db.Clients.Last().Id;
                return id;
            }
            else
            {
                return 0;
            }

        }

        public Client getClientById(int? id)
        {
            var client = db.Clients.Where(x => (x.Id == id)).SingleOrDefault();
            Client client1 = new Client()
            {
                Id = client.Id,
                FirstName = client.Persons.FirstName,
                LastName = client.Persons.LastName,
                Email = client.Persons.Email,
                Dni = client.Persons.Dni,
                Gender = client.Persons.Gender,
                BornDate = client.Persons.BornDate,
                City = client.Persons.City,
                ProfileImg = client.Persons.ProfileImg,
                Province = client.Persons.Province,
                Codep = client.Persons.Codep,
                Tel = client.Persons.Tel,
            };

            return client1;
        }
        public List<Client> getClients()
        {
            List<Client> clientsl = new List<Client>();
            var clientlist = db.Clients.ToList();
            foreach (Clients client in clientlist)
            {
                Client clientitem = new Client()
                {
                    Id = client.Id,
                    FirstName = client.Persons.FirstName,
                    LastName = client.Persons.LastName,
                    Email = client.Persons.Email,
                    Dni = client.Persons.Dni,
                    Gender = client.Persons.Gender,
                    BornDate = client.Persons.BornDate,
                    City = client.Persons.City,
                    ProfileImg = client.Persons.ProfileImg,
                    Province = client.Persons.Province,
                    Codep = client.Persons.Codep,
                    Tel = client.Persons.Tel,
                };

                clientsl.Add(clientitem);
            }
            return clientsl;
        }
        public void saveClient(RegisterModel client)
        {
            Persons person1 = new Persons();
            person1.LastName = client.LastName;
            person1.Email = client.Email;
            person1.Dni = client.Dni;
            person1.Gender = client.Gender;
            person1.BornDate = client.BornDate;
            person1.City = client.City;
            person1.ProfileImg = client.ProfileImg;
            person1.Province = client.Province;
            person1.Codep = client.Codep;
            person1.Tel = client.Tel;

            db.Persons.Add(person1);
            db.SaveChanges();

            var person = db.Persons.Where(x => (x.Dni == person1.Dni)).SingleOrDefault();

            Clients client1 = new Clients();
            client1.IdPerson = person.Id;

            db.Clients.Add(client1);
            db.SaveChanges();
        }

        public void deleteClient(int id)
        {
            Clients client = db.Clients.Where(x => (x.Id == id)).SingleOrDefault();
            db.Clients.Remove(client);
            db.SaveChanges();
        }

    }
}
