using AutoMapper;
using Prognosys.Shared.Models;
using Prognosys.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prognosys.Web.Mapper
{
    public class ViewModelMapper
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientViewModel, ClientModel>();
                cfg.CreateMap<ClientModel, ClientViewModel>();
            });

            return config.CreateMapper();
        }
    }
}