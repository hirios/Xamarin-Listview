using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace primeiroAPP
{

    public class NewItem
    {
        public string NewsName { get; set; }
        public string ArticleText { get; set; }
        public bool isVisible { get; set; }
    }

    public class ParseItem
    {
        public List<Info> Items { get; set; }
    }

    public class Info
    {
        private string _slug;
        private string _title;
        private string _id;
        public string content_type { set; get; }


        public string slug
        {
            get => _slug;
            set => _slug = value + " teste";
        }

        public string title
        {
            get => _title;
            set => _title = value;
        }

        public string id
        {
            get
            {
                if (content_type == "m") { return @"https://img.reelgood.com/content/movie/" + _id + @"/poster-342.jpg"; }
                else { return @"https://img.reelgood.com/content/show/" + _id + @"/poster-342.jpg"; }
            }

            set
            {
                this._id = value;
            }
        }
    }
}
