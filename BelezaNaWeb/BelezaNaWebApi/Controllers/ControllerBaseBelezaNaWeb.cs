using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BelezaNaWebApi.Controllers
{
    public abstract class ControllerBaseBelezaNaWeb<T> : ControllerBase
    {
        protected readonly ILogger<T> Logger;

        public ControllerBaseBelezaNaWeb(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}