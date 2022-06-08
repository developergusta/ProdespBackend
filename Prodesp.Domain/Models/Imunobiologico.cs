﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Domain.Models
{
    [Table("Imunobiologico")]
    public class Imunobiologico
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required]
        public int AnoLote { get; set; }

        public DateTime? DataCadastro { get; set; }

        [Required]
        public Fabricante Fabricante { get; set; }

        private static int maxDate { get; set; }
    }
}
