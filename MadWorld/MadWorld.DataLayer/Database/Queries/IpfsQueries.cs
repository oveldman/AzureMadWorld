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

        public DataResult Delete(Guid id)
        {
            IpfsFile file = Find(id);

            if (file != null)
            {
                _context.IpfsFiles.Remove(file);
                _context.SaveChanges();
            }

            return new DataResult();
        }

        public IpfsFile Find(string hash)
        {
            return _context.IpfsFiles.FirstOrDefault(f => f.Hash.Equals(hash));
        }

        public IpfsFile Find(Guid id)
        {
            return _context.IpfsFiles.FirstOrDefault(f => f.ID.Equals(id));
        }

        public List<IpfsFile> GetAll()
        {
            return _context.IpfsFiles.ToList();
        }

        public DataResult Save(IpfsFile file)
        {
            _context.IpfsFiles.Add(file);
            
            _context.SaveChanges();

            return new DataResult
            {
                RowID = file.ID
            };
        }
    }
}

