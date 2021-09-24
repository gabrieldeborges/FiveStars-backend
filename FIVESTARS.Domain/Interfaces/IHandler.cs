using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Interfaces
{
    public interface IHandler
    {
        IReadOnlyCollection<Notification> Notifications();
    }
}
