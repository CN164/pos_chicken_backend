using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    [Table("stock_data", Schema = "pos_chicken_backend")]
    public class StockEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]

        [Column("id")]
        public int id { get; set; }

        [Column("stock_name")]
        public string stockName { get; set; }

        [Column("stock_total")]
        public int stockTotal { get; set; }

        [Column("stock_unit_price")]
        public int stockunitPrice { get; set; }

        [Column("point_to_buy")]
        public int pointtoBuy { get; set; }

        [Column("additional_unit")]
        public int additionalUnit { get; set; }

        [Column("parth_url")]
        public string parthUrl { get; set; }
    }
}
