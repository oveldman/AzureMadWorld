using System;
using System.IO;
using System.Threading.Tasks;
using MadWorld.Business.Models;
using MadWorld.Business.Services.Models;

namespace MadWorld.Business.Services
{
	public class VpsWebServices : WebServices, IVpsWebServices
	{
        public VpsWebServices(ApplicationUrls applicationUrls) : base(applicationUrls.MadWorldVpsIpfs)
        {
        }

        public async Task<WebResult<Stream>> Get(string hash)
        {
            List<WebParameter> parameters = new()
            {
                new WebParameter
                {
                    Name = "id",
                    Value = hash
                }
            };

            return await GetRequest(parameters);
        }
    }
}

