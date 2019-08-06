using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultorioMedERP.Common.Utilerias
{
    public class VersionControl:Info
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}
