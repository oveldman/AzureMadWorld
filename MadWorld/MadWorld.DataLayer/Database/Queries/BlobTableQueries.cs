using System;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries
{
    public class BlobTableQueries : IBlobTableQueries
    {
        MadWorldContext _context;

        public BlobTableQueries(MadWorldContext context)
        {
            _context = context;
        }

        public DataResult SaveFile(BlobFile file)
        {
            _context.Files.Add(file);
            _context.SaveChanges();

            return new DataResult
            {
                RowID = file.ID
            };
        }
    }
}
