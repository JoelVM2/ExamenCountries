using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExamenCountries.Model
{
    public class Country
    {
        public NameInfo Name { get; set; }
        public List<string>? Capital { get; set; }
        public string Region { get; set; }
        public long Population { get; set; }   
    }


    public class NameInfo
    {
        public string Common { get; set; }
        public string Official { get; set; }
    }
}
