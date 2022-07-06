using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC_Study.Models
{
    public class TipoContrato
    {
        [Key]
        public int Id { get; set; }
        public string NomeContrato { get; set; }
        public int IdContrato { get; set; }
    }
}
