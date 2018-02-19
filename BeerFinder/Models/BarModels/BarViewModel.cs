using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeerDB;

namespace BeerFinder.Models.BarModels
{
    public class BarViewModel
    {
        [Required, MinLength(1)]
        public string Name { get; set; }
        [Required]
        public List<BarTag> BarTags { get; set; }
        [Required]
        public int OpeningTime { get; set; }
        [Required]
        public int ClosingTime { get; set; }
        [Required]
        public String Picture { get; set; }

        public BarViewModel(string name
            , List<BarTag> barTags
            , int openingTime
            , int closingTime
            , string picture)
        {
            Name = name;
            BarTags = barTags;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            Picture = picture;
        }

        public BarViewModel()
        {
        }
    }
}
