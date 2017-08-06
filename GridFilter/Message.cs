namespace GridFilter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message.Message")]
    public partial class Message
    {
        public int MessageID { get; set; }

        [Required]
        [StringLength(20)]
        public string TitleM { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DateM { get; set; }

        public int Destination { get; set; }

        public int Sender { get; set; }

        [Required]
        [StringLength(250)]
        public string Content { get; set; }
    }
}
