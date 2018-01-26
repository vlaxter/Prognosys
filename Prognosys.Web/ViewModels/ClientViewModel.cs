using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prognosys.Web.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}