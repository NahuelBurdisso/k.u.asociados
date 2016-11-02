﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface INotificationService
    {
        int getLatestId();
        List<Notification> getActiveNotificationsbyLawyer(int? idlawyer);

        void deactivateNotification(int idnotification);
        void saveNotification(Notification notification);

    }
}