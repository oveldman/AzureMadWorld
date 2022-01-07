using System;
using AutoMapper;
using MadWorld.Business.Mapper.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Models.Admin.IPFS;
using MadWorld.Shared.Models.IPFS;

namespace MadWorld.Business.Mapper
{
	public class IpfsMapperManager : MapperBaseManager, IIpfsMapperManager
    {
        public override IMapper LoadMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<IpfsFile, IpfsDTO>()
                .ForMember(d => d.FileType, s => s.MapFrom(f => f.ContentType));
                cfg.CreateMap<IpfsFile, IpfsAdminDTO>()
                .ForMember(d => d.FileType, s => s.MapFrom(f => f.ContentType))
                .ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}

