using System;
using System.IO;
using System.Threading.Tasks;
using MadWorld.Business.Services.Models;

namespace MadWorld.Business.Services.Interfaces
{
	public interface IVpsWebServices
	{
		Task<WebResult<Stream>> Get(string hash);
	}
}

