﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;


namespace kuasociados.Contract
{
    public interface IUserService
    {
        int getLastestPersonId();
        void saveUser(RegisterModel user);
    }
}
