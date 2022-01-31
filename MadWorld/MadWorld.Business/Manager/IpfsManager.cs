using System;
using System.IO;
using System.Threading.Tasks;
using MadWorld.Business.Mapper.Interfaces;
using MadWorld.Business.Models;
using MadWorld.Business.Services.Models;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Web.Creators;
using MadWorld.Shared.Web.Helper;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Admin.IPFS;
using MadWorld.Shared.Web.Models.IPFS;

namespace MadWorld.Business.Manager
{
	public class IpfsManager : IIpfsManager
	{
        private readonly string vpsMadWorldUrl;

        private IIpfsQueries _ipfsQueries;
        private IIpfsMapperManager _mapperManager;
        private IVpsWebServices _webServices;

        public IpfsManager(IIpfsQueries ipfsQueries, IIpfsMapperManager mapperManager, IVpsWebServices services, ApplicationUrls applicationUrls)
		{
            _ipfsQueries = Guard.Against.Null(ipfsQueries);
            _mapperManager = Guard.Against.Null(mapperManager);
            _webServices = Guard.Against.Null(services);
            vpsMadWorldUrl = applicationUrls.MadWorldVpsIpfs;
		}

        public BaseResponse Delete(Guid id)
        { 
            DataResult result = _ipfsQueries.Delete(id);

            return new BaseResponse
            {
                Error = result.Error,
                ErrorMessage = result.Error ? "Something went wrong." : string.Empty
            };
        }

        public async Task<IpfsDetailResponse> GetDetails(string hash)
        {
            IpfsFile file = _ipfsQueries.Find(hash);

            if (file == null)
            {
                ResponseCreators.CreateErrorResponse<IpfsDetailResponse>("File not found");
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

        public IpfsAdminDetailResponse GetDetails(Guid id)
        {
            IpfsFile file = _ipfsQueries.Find(id);

            if (file == null)
            {
                ResponseCreators.CreateErrorResponse<IpfsAdminDetailResponse>("File not found");
            }

            IpfsAdminDTO dto = _mapperManager.Translate<IpfsFile, IpfsAdminDTO>(file);

            return new IpfsAdminDetailResponse
            {
                Details = dto
            };
        }

        public BaseResponse Save(IpfsAdminDTO fileDTO)
        {
            IpfsFile file = _mapperManager.Translate<IpfsAdminDTO, IpfsFile>(fileDTO);

            DataResult result = _ipfsQueries.Save(file);

            return new BaseResponse
            {
                Error = result.Error,
                ErrorMessage = result.Error ? "Something went wrong." : string.Empty
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

        public IpfsAdminSearchResponse SearchWithID()
        {
            List<IpfsFile> files = _ipfsQueries.GetAll();
            List<IpfsAdminDTO> fileDtos = _mapperManager.Translate<List<IpfsFile>, List<IpfsAdminDTO>>(files);

            return new IpfsAdminSearchResponse
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

