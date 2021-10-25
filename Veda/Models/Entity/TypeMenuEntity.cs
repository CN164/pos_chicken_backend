using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    [Table("type_data", Schema = "pos_chicken_backend")]
    public class TypeMenuEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]

        [Column("id")]
        public int id { get; set; }

        [Column("type_id")]
        public string typeMenu { get; set; }

    }
}
