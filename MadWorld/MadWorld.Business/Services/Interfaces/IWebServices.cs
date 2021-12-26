using System;
using System.IO;
using System.Threading.Tasks;
using MadWorld.Business.Services.Models;

namespace MadWorld.Business.Services.Interfaces
{
	public interface IWebServices
	{
		Task<WebResult<Stream>> GetRequest(List<WebParameter> parameters);
	}
}

