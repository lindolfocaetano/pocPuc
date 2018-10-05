using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogWeb.Areas.Map.Models
{
    public class JsonDTO
    {
        public string Result { get; set; }
        public IEnumerable<String> Rotas { get; set; }
    }
}
