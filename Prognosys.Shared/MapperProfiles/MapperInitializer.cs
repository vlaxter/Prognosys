using AutoMapper;
using Prognosys.Shared.DTOs;
using Prognosys.Shared.Models;

namespace Prognosys.Shared.MapperProfiles
{
    public static class MapperInitializer
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientDto, ClientModel>();
                cfg.CreateMap<ClientModel, ClientDto>();
            });

            return config.CreateMapper();
        }
    }
}
