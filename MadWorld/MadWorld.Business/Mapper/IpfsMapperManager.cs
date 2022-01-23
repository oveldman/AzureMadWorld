using System;
using AutoMapper;
using MadWorld.Business.Mapper.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Web.Models.Admin.IPFS;
using MadWorld.Shared.Web.Models.IPFS;

namespace MadWorld.Business.Mapper
{
	public class IpfsMapperManager : MapperBaseManager, IIpfsMapperManager
    {
        public override MapperConfiguration LoadConfigMapper()
        {
            return new MapperConfiguration(config => {
                CreateMapIpfsFileAndIpfsDTO(ref config);
                CreateMapIpfsFileAndIpfsAdminDTO(ref config);
            });
        }

        private static void CreateMapIpfsFileAndIpfsDTO(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<IpfsFile, IpfsDTO>()
                .ForMember(d => d.FileType, s => s.MapFrom(f => f.ContentType));
        }

        private static void CreateMapIpfsFileAndIpfsAdminDTO(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<IpfsFile, IpfsAdminDTO>()
                .ForMember(d => d.FileType, s => s.MapFrom(f => f.ContentType))
                .ReverseMap();
        }
    }
}

