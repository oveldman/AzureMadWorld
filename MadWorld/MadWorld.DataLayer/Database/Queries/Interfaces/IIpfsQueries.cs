using System;
using System.Collections.Generic;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries.Interfaces
{
	public interface IIpfsQueries
	{
		List<IpfsFile> GetAll();
		DataResult Delete(Guid id);
		IpfsFile Find(string hash);
		IpfsFile Find(Guid id);
		DataResult Save(IpfsFile file);
	}
}

