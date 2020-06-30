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

        [Required]
        public string ConsoleName { get; set; }
        
        [Required]
        public decimal ConsoleCost { get; set; }

        public ICollection<Game> Games { get; set; }

        //I want to create a console without saying what games are on it, but in the detail, I will want to see what games are
        //attatched to that console(GetGamesByConsoleID). When creating a game, I want to be able to select which consoles 
        //(that are created) the game can be played on.
    }
}
