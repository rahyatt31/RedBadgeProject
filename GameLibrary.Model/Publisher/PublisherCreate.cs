using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model.Publisher
{
    public class PublisherCreate
    {
        [Required, DisplayName("Name of Publisher")]
        public string PublisherName { get; set; }

        [Required, DisplayName("Founder of Company")]
        public string PublisherFounder { get; set; }

        [Required, DisplayName("Publisher Location")]
        public string PublisherLocation { get; set; }

        [Required, DisplayName("Year Publisher was Founded")]
        public int PublisherYearEstablished { get; set; }

        [Required, DisplayName("Publisher's most popular game")]
        public int PublisherMostPopularGame { get; set; }
    }
}
