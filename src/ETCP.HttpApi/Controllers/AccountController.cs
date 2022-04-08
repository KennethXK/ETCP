using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using static ETCP.Domain.Shared.ETCPConsts;

namespace ETCP.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v1)]
    public class AccountController : AbpController
    {
        [HttpPost]
        [Route("Login")]
        public async Task Login() { }
    }
}
