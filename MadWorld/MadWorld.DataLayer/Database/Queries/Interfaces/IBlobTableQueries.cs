using System;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries.Interfaces
{
    public interface IBlobTableQueries
    {
        DataResult SaveFile(BlobFile file);
    }
}
