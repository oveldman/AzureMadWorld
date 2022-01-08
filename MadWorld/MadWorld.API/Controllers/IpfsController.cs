using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.Shared.Models.IPFS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadWorld.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class IpfsController : ControllerBase
    {
        private readonly ILogger<IpfsController> _logger;
        private IIpfsManager _ipfsManager;

        public IpfsController(ILogger<IpfsController> logger, IIpfsManager ipfsManager)
        {
            _logger = logger;
            _ipfsManager = Guard.Against.Null(ipfsManager, nameof(ipfsManager));
        }

        [HttpGet]
        [Route("Search")]
        public IpfsSearchResponse Search()
        {
            return _ipfsManager.Search();
        }

        [HttpGet]
        [Route("GetDetails")]
        public async Task<IpfsDetailResponse> GetDetails(string Hash)
        {
            return await _ipfsManager.GetDetails(Hash);
        }
    }
}

