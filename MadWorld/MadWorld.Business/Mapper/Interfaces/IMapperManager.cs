using System;
namespace MadWorld.Business.Mapper.Interfaces
{
	public interface IMapperManager
	{
		Y Translate<T, Y>(T request);
	}
}

