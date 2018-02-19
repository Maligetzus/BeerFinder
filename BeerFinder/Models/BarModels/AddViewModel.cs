using System;
using System.ComponentModel.DataAnnotations;

namespace BeerFinder.Models.BarModels
{
    public class AddViewModel
    {
        [Required, MinLength(1)]
        [Display(Name = "Bar Name:")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Tags (seperate with ';'):")]
        public String BarTagString { get; set; }
        [Required]
        [Display(Name = "Opening time:")]
        public int OpeningTime { get; set; }
        [Required]
        [Display(Name = "Closing time:")]
        public int ClosingTime { get; set; }
        [Required]
        [Display(Name ="Picture location:")]
        public String Picture { get; set; }

        public AddViewModel(string name
            , String barTagString
            , int openingTime
            , int closingTime
            , string picture)
        {
            Name = name;
            BarTagString = barTagString;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            Picture = picture;
        }

        public AddViewModel()
        {
        }
    }
}