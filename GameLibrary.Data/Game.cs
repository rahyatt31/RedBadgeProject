using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Data
{
    public enum GameAdvisoryRating {E, E10, T, M, A, RP }
    public enum GameGenre { Action, Adventure, Educational, Fighting, Horror, Platformer, Puzzle, Racing, Rhythm, RPG, Shooter, Simulation, Sports, Stealth, Strategy, Survival }
    public class Game
    {
        [Key]
        public int GameID { get; set; }

        [Required]
        public string GameName { get; set; }
        [Required]
        public GameGenre GameGenre { get; set; }
        [Required]
        public bool Multiplayer { get; set; }
        [Required]
        public bool Online { get; set; }
        [Required]
        public GameAdvisoryRating GameAdvisoryRating { get; set; }
        [Required]
        public int GameRating { get; set; }
        [Required]
        public DateTime GameReleaseDate { get; set; }
        [Required]
        public decimal GameGameStop { get; set; }

        public ICollection<Console> Consoles { get; set; }                
        public ICollection<Publisher> Publishers { get; set; }             
    }
}