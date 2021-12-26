using System;
using System.Collections.Generic;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries
{
	public class IpfsQueries : IIpfsQueries
	{
        private MadWorldContext _context;

        public IpfsQueries(MadWorldContext context)
        {
            _context = context;
        }

        public IpfsFile Find(string hash)
        {
            return _context.IpfsFiles.FirstOrDefault(f => f.Hash.Equals(hash));
        }

        public List<IpfsFile> GetAll()
        {
            return _context.IpfsFiles.ToList();
        }
    }
}

