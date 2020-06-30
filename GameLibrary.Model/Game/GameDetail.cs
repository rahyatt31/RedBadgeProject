using GameLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model.Game
{
    public class GameDetail
    {
        public int GameID { get; set; }

        [DisplayName("Name")]
        public string GameName { get; set; }

        [DisplayName("Game Type")]
        public GameGenre GameGenre { get; set; }

        [DisplayName("Is this game Mulitplayer?")]
        public bool GameMultiplayer { get; set; }

        [DisplayName("Can this be played Online?")]
        public bool GameOnline { get; set; }

        [DisplayName("Advisory Rating")]
        public GameAdvisoryRating GameAdvisoryRating { get; set; }

        [DisplayName("Rating")]
        public int GameRating { get; set; }

        [DisplayName("Available on which Consoles?")]
        public int ConsoleID { get; set; }

        [DisplayName("Published by?")]
        public int PublisherID { get; set; }

        [DisplayName("Year released?")]
        public DateTime GameReleaseDate { get; set; }

        [DisplayName("GameStop will pay")]
        public decimal GameGameStop { get; set; }
    }
}
