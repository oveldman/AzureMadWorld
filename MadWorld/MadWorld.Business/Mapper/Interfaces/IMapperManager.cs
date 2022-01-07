using System;
using AutoMapper;

namespace MadWorld.Business.Mapper.Interfaces
{
	public interface IMapperManager
	{
		IMapper LoadMapper();
		Y Translate<T, Y>(T request);
	}
}

