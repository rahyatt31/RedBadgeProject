using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model.Console
{
    public class ConsoleEdit
    {
        public int ConsoleID { get; set; }

        [DisplayName("Console Name")]
        public string ConsoleName { get; set; }

        [DisplayName("Cost of Console")]
        public decimal ConsoleCost { get; set; }
    }
}
