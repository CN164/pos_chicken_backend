using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pos_chicken_backend.Models
{
    [Table("order_data", Schema = "pos_chicken_backend")]
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]

        [Column("id")]
        public int id { get; set; }

        [Column("queue")]
        public int queueOrder { get; set; }

        [Column("stock_id")]
        public int stockId { get; set; }

        [Column("total_promotion")]
        public int totalPromotion { get; set; }

        [Column("quantity")]
        public int quantityOrder { get; set; }

        [Column("state_id")]
        public int stateId { get; set; }

        [Column("type_id")]
        public int typeId { get; set; }

        [Column("create_at")]
        public DateTime createAt { get; set; }

        [ForeignKey("stateId")]
        public StateEntity stateEntity { get; set; }

    }
}
