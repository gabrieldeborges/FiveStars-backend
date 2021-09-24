using FIVESTARS.Domain.Interfaces;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Handlers
{
    public abstract class BaseHandler : Notifiable, IHandler
    {
        //protected BaseHandler();

        IReadOnlyCollection<Notification> IHandler.Notifications()
        {
            return base.Notifications;
        }
    }
}
