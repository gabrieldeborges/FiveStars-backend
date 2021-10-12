using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Commands
{
    public abstract class BaseCommand : Notifiable
    {
        public virtual bool isvalid()
        {
            if (Notifications?.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
