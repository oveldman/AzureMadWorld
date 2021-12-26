using System;
using System.Collections.Generic;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries.Interfaces
{
	public interface IIpfsQueries
	{
		List<IpfsFile> GetAll();
		IpfsFile Find(string hash);
	}
}

