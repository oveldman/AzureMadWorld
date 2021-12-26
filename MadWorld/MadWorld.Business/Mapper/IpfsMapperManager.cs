using System;
using AutoMapper;
using MadWorld.Business.Mapper.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Models.IPFS;

namespace MadWorld.Business.Mapper
{
	public class IpfsMapperManager : IMapperManager
	{
        private readonly IMapper _mapper;

        public IpfsMapperManager()
		{

			var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<IpfsFile, IpfsDTO>().
                ForMember(d => d.FileType, s => s.MapFrom(f => f.ContentType));
			});

			_mapper = config.CreateMapper();
		}

        public Y Translate<T, Y>(T request)
        {
            return _mapper.Map<Y>(request);
        }
    }
}

