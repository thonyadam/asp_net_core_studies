using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC_Study.Models
{
    public class Contrato
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [DisplayName("Numero Contrato")]
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Valor tem que ser maior que 0")]
        public int Numero { get; set; }
        public string Sexo { get; set; }
        public List<TipoContrato> Tipos { get; set; }
    }
}
