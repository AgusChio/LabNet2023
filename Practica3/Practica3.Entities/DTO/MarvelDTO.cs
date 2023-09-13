using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.Entities.DTO
{
    public class MarvelDTO
    {
        public class MarvelApiResponse
        {
            public DataContainer Data { get; set; }
        }

        public class DataContainer
        {
            public List<Character> Results { get; set; }
        }

        public class Character
        {
            public string Name { get; set; }
            public Thumbnail Thumbnail { get; set; }
            public Comics Comics { get; set; }
            public Series Series { get; set; }
            public Stories Stories { get; set; }


            public string ThumbnailUrl => $"{Thumbnail.Path}.{Thumbnail.Extension}";
        }

        public class Thumbnail
        {
            public string Path { get; set; }
            public string Extension { get; set; }
        }

        public class Comics
        {
            public List<Item> Items { get; set; }
        }

        public class Series
        {
            public List<Item> Items { get; set; }
        }

        public class Stories
        {
            public List<Item> Items { get; set; }
        }

        public class Item
        {
            public string Name { get; set; }
        }


    }
}
