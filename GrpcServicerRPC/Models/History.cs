using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServerRPS.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public int Games { get; set; } = 0;
        public int lost { get; set; } = 0;
        public int draw { get; set; } = 0;
        public int win { get; set; } = 0;


        [ForeignKey(nameof(userId))]
        [InverseProperty("History")]
        public virtual User User { get; set; }


    }
}
