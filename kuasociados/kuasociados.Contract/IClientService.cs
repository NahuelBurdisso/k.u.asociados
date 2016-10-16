using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface IClientService
    {
        int getLastestId();
        Client getClientById(int? id);
        List<Client> getClients();
        void saveClient(RegisterModel client);
        void deleteClient(int id);
    }
}
