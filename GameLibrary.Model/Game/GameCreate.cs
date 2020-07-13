using GameLibrary.Data;
using GameLibrary.Model.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model.Game
{
    public class GameCreate
    {
        [Required, DisplayName("Name")]
        public string GameName { get; set; }
        
        [Required, DisplayName("Game Type")]
        public GameGenre GameGenre { get; set; }
        
        [Required, DisplayName("Is this game Mulitplayer?")]
        public bool GameMultiplayer { get; set; }
        
        [Required, DisplayName("Can this be played Online?")]
        public bool GameOnline { get; set; }
        
        [Required, DisplayName("Advisory Rating")]
        public GameAdvisoryRating GameAdvisoryRating { get; set; }
        
        [Range (0,5, ErrorMessage = "Rating is on a scale rating between 0-5")]
        [Required, DisplayName("Rating")]
        public int GameRating { get; set; }

        [DisplayName("Available on which Consoles?")]
        public int ConsoleID { get; set; }

        [DisplayName("Published by?")]
        public int PublisherID { get; set; }

        [DataType(DataType.Date)]
        [Required, DisplayName("Release Date?")]
        public DateTime GameReleaseDate { get; set; }
    }
}
