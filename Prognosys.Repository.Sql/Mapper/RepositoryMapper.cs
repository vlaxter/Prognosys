using AutoMapper;
using Prognosys.Repository.Sql.Entities;
using Prognosys.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosys.Repository.Sql.Mapper
{
     public static class RepositoryMapper
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientDto, Client>().ForMember(dest => dest.Id, src => src.Ignore());
                cfg.CreateMap<Client, ClientDto>();
            });

            return config.CreateMapper();
        }
    }
}
