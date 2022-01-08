using System;
using System.Threading.Tasks;
using MadWorld.API.Attribute;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database.Enum;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Admin;
using MadWorld.Shared.Models.Admin.IPFS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Controllers.Admin
{
    [ApiController]
    [AuthorizeMW(Roles.Adminstrator)]
    [Route("Admin/Ipfs")]
    public class IpfsAdminController : ControllerBase
    {
        private const string IdNotCorrect = "ID is not in the correct format.";

        private readonly ILogger<IpfsAdminController> _logger;
        private IIpfsManager _ipfsManager;

        public IpfsAdminController(ILogger<IpfsAdminController> logger, IIpfsManager ipfsManager)
        {
            _logger = logger;
            _ipfsManager = Guard.Against.Null(ipfsManager, nameof(ipfsManager));
        }
        [HttpDelete]
        [Route("Delete")]
        public BaseResponse Delete(string id)
        {
            if (Guid.TryParse(id, out Guid guidID))
            {
                return _ipfsManager.Delete(guidID);
            }

            return new IpfsAdminDetailResponse
            {
                Error = true,
                ErrorMessage = IdNotCorrect
            };
        }

        [HttpGet]
        [Route("GetDetails")]
        public IpfsAdminDetailResponse GetDetails(string id)
        {
            if (Guid.TryParse(id, out Guid guidID))
            {
                return _ipfsManager.GetDetails(guidID);
            }

            return new IpfsAdminDetailResponse
            {
                Error = true,
                ErrorMessage = IdNotCorrect
            };
        }

        [HttpGet]
        [Route("Search")]
        public IpfsAdminSearchResponse Search()
        {
            return _ipfsManager.SearchWithID();
        }

        [HttpPut]
        [Route("Update")]
        public BaseResponse Update(IpfsAdminDTO file)
        {
            return _ipfsManager.Save(file);
        }
    }
}

