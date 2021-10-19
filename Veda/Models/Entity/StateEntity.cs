using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    [Table("state_data", Schema = "pos_chicken_backend")]
    public class StateEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]

        [Column("id")]
        public int id { get; set; }

        [Column("state_name")]
        public string stateOrder { get; set; }
    }
}
