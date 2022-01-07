using System;
using AutoMapper;

namespace MadWorld.Business.Mapper.Interfaces
{
    public abstract class MapperBaseManager : IMapperManager
    {
        private IMapper _mapper;

        public MapperBaseManager()
        {
            _mapper = LoadMapper();
        }

        public abstract IMapper LoadMapper();

        public Y Translate<T, Y>(T request)
        {
            return _mapper.Map<Y>(request);
        }
    }
}

