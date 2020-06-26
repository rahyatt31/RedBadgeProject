using GameLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model.Game
{
    public class GameEdit
    {
        public int GameID { get; set; }

        public string GameName { get; set; }
        public GameGenre GameGenre { get; set; }
        public bool GameMultiplayer { get; set; }
        public bool GameOnline { get; set; }
        public GameAdvisoryRating GameAdvisoryRating { get; set; }
        public int GameRating { get; set; }
        public DateTime GameReleaseDate { get; set; }
        public decimal GameGameStop { get; set; }
    }
}
