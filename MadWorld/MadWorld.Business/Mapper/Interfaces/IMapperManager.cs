using System;
using AutoMapper;

namespace MadWorld.Business.Mapper.Interfaces
{
	public interface IMapperManager
	{
		MapperConfiguration LoadConfigMapper();
		Y Translate<T, Y>(T request);
	}
}

