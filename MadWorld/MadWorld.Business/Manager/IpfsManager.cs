using System;
using System.IO;
using System.Threading.Tasks;
using MadWorld.Business.Mapper.Interfaces;
using MadWorld.Business.Models;
using MadWorld.Business.Services.Models;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Helper;
using MadWorld.Shared.Models.IPFS;

namespace MadWorld.Business.Manager
{
	public class IpfsManager : IIpfsManager
	{
        private readonly string vpsMadWorldUrl;

        private IIpfsQueries _ipfsQueries;
        private IMapperManager _mapperManager;
        private IVpsWebServices _webServices;

        public IpfsManager(IIpfsQueries ipfsQueries, IMapperManager mapperManager, IVpsWebServices services, ApplicationUrls applicationUrls)
		{
            _ipfsQueries = ipfsQueries;
            _mapperManager = mapperManager;
            _webServices = services;
            vpsMadWorldUrl = applicationUrls.MadWorldVpsIpfs;
		}

        public async Task<IpfsDetailResponse> GetDetails(string hash)
        {
            IpfsFile file = _ipfsQueries.Find(hash);

            if (file == null)
            {
                return new IpfsDetailResponse
                {
                    Error = true,
                    ErrorMessage = "File not found"
                };
            }

            WebResult<Stream> result = await _webServices.Get(hash);

            IpfsDTO dto = _mapperManager.Translate<IpfsFile, IpfsDTO>(file);
            dto.Url = GetVpsUrl(file.Hash);

            return new IpfsDetailResponse
            {
                Details = dto,
                Body = SimpleConverter.ConvertToBase64(result.Body)
            };
        }

        public IpfsSearchResponse Search()
        {
            List<IpfsFile> files = _ipfsQueries.GetAll();
            List<IpfsDTO> fileDtos = _mapperManager.Translate<List<IpfsFile>, List<IpfsDTO>>(files);

            fileDtos.ForEach(f => f.Url = GetVpsUrl(f.Hash));

            return new IpfsSearchResponse
            {
                Result = fileDtos
            };
        }

        private string GetVpsUrl(string hash)
        {
            return $"{vpsMadWorldUrl}/{hash}";
        }
    }
}

