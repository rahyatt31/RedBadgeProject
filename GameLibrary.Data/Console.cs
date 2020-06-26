using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Data
{
    public class Console
    {
        [Key]
        public int ConsoleID { get; set; }

        [ForeignKey("Game")]
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        [Required]
        public string ConsoleName { get; set; }
        [Required]
        public decimal ConsoleCost { get; set; }
    }
}
