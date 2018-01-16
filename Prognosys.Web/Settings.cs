using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Prognosys.Web
{
    public static class Settings
    {
        public static string PrognosysApiBaseUri = ConfigurationManager.AppSettings["PrognosysApiBaseUri"];
    }
}