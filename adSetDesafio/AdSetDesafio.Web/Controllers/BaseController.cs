using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdSetDesafio.Domain.Common.DTOs;
using System.Threading.Tasks;

namespace AdSetDesafio.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly string remoteServer;
        protected readonly IConfiguration configuration;
        protected readonly IHttpContextAccessor httpContextAccessor;

        public BaseController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base()
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            remoteServer = configuration["ServerInfo:Url"];
        }
    }
}