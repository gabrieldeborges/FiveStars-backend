using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Commands
{
    public abstract class BaseCommand : Notifiable
    {
        public abstract bool isvalid();
    }
}
