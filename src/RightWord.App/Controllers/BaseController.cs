using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RightWord.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RightWord.App.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        private readonly INotificator _notificator;

        protected BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool IsValidOperation()
        {
            return !_notificator.HasNotification();
        }
    }
}
