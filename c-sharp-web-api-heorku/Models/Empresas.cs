using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_web_api_heorku.Models
{
    [Table("empresas")]
    public class Empresas
    {
        [Key]
        public int cod { get; set; }
        public string nome { get; set; }
        public string razao_social { get; set; }
    }
}
