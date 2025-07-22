using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Dominio.Entities
{
    [Table("perso")]
    public class Perso
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("bin_id")]
        public int bin_id { get; set; }
        [Column("cliente")]
        public string? cliente { get; set; }
        [Column("fecha")]
        public DateTime? fecha { get; set; }
    }
}
