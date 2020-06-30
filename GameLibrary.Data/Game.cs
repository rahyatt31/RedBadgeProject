using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Data
{
    public enum GameAdvisoryRating
    {
        [Display(Name = "Everyone")] E,
        [Display(Name = "Everyone 10+")] E10,
        [Display(Name = "Teen")] T,
        [Display(Name = "Mature")] M,
        [Display(Name = "Adult")] A,
        [Display(Name = "Rating Pending")] RP
    }

    public enum GameGenre
    {
        Action,
        Adventure,
        Arcade,
        Educational,
        Fighting,
        Horror,
        Platformer,
        Puzzle,
        Racing,
        Rhythm,
        RPG,
        Shooter,
        Simulation,
        Sports,
        Stealth,
        Strategy,
        Survival
    }

    public class Game
    {
        [Key]
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

        [ForeignKey("Console")]
        public int ConsoleID { get; set; }
        public virtual Console Console { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }

        [Required]
        public decimal GameGameStop { get; set; }

        public ICollection<Console> Consoles { get; set; }                
        public ICollection<Publisher> Publishers { get; set; }             
    }
}