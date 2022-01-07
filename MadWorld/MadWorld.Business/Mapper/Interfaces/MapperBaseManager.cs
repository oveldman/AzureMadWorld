using System;
using AutoMapper;

namespace MadWorld.Business.Mapper.Interfaces
{
    public abstract class MapperBaseManager : IMapperManager
    {
        private IMapper _mapper;

        public MapperBaseManager()
        {
            MapperConfiguration config = LoadConfigMapper();
            _mapper = config.CreateMapper();
        }

        public abstract MapperConfiguration LoadConfigMapper();

        public Y Translate<T, Y>(T request)
        {
            return _mapper.Map<Y>(request);
        }
    }
}

