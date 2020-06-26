using GameLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model.Game
{
    public class GameDetail
    {
        public int GameID { get; set; }

        [Required]
        public string GameName { get; set; }
        [Required]
        public GameGenre GameGenre { get; set; }
        [Required]
        public bool GameMultiplayer { get; set; }
        [Required]
        public bool GameOnline { get; set; }
        [Required]
        public GameAdvisoryRating GameAdvisoryRating { get; set; }
        [Required]
        public int GameRating { get; set; }
        [Required]
        public DateTime GameReleaseDate { get; set; }
        [Required]
        public decimal GameGameStop { get; set; }
    }
}
