using System;
using MadWorld.Business.Mapper;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Web.Models.Admin.IPFS;
using MadWorld.Shared.Web.Models.IPFS;

namespace MadWorld.Tests.Business.Mapper
{
	public class IpfsMapperManagerTests
	{
		[Theory]
		[AutoDomainData]
		public void Translate_IpfsFile_IpfsDTO(
			IpfsMapperManager ipfsMapperManager,
			IpfsFile file
			)
        {
			// No Test data

			// No Setup

			// Act
			IpfsDTO dto = ipfsMapperManager.Translate<IpfsFile, IpfsDTO>(file);

			// Assert
			IpfsDTO expectedDTO = new()
			{
				FileType = file.ContentType,
				Hash = file.Hash,
				Name = file.Name,
			};

			expectedDTO.Should().BeEquivalentTo(dto);

			// No Teardown
		}

		[Theory]
		[AutoDomainData]
		public void Translate_IpfsFile_IpfsAdminDTO(
			IpfsMapperManager ipfsMapperManager,
			IpfsFile file
			)
		{
			// No Test data

			// No Setup

			// Act
			IpfsAdminDTO dto = ipfsMapperManager.Translate<IpfsFile, IpfsAdminDTO>(file);

			// Assert
			IpfsAdminDTO expectedDTO = new()
			{
				ID = file.ID,
				FileType = file.ContentType,
				Hash = file.Hash,
				Name = file.Name,
			};

			expectedDTO.Should().BeEquivalentTo(dto);

			// No Teardown
		}

		[Theory]
		[AutoDomainData]
		public void Translate_IpfsAdminDTO_IpfsFile(
			IpfsMapperManager ipfsMapperManager,
			IpfsAdminDTO dto
			)
		{
			// No Test data

			// No Setup

			// Act
			IpfsFile file = ipfsMapperManager.Translate<IpfsAdminDTO, IpfsFile>(dto);

			// Assert
			IpfsFile expectedFile = new()
			{
				ID = dto.ID.Value,
				ContentType = dto.FileType,
				Hash = dto.Hash,
				Name = dto.Name,
			};

			expectedFile.Should().BeEquivalentTo(file);

			// No Teardown
		}
	}
}

