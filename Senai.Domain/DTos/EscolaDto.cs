using Senai.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Domain.DTos
{
    public class EscolaDto
    {
        public string Id { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }
        public EnderecoDto Endereco { get; set; }

    }
}
