﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model.Publisher
{
    public class PublisherListItem
    {
        public int PublisherID { get; set; }

        [DisplayName("Name of Publisher")]
        public string PublisherName { get; set; }

        [DisplayName("Name of Founder")]
        public string PublisherFounder { get; set; }

        [DisplayName("Publisher Location")]
        public string PublisherLocation { get; set; }

        [DisplayName("Year Publisher was Founded")]
        public int PublisherYearEstablished { get; set; }

        [DisplayName("Publisher's most popular game")]
        public string PublisherMostPopularGame { get; set; }
    }
}
