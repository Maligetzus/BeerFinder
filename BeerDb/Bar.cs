using System;
using System.Collections.Generic;

namespace BeerDB
{
    public enum Day
    {
        Monday=0,Tuesday=1,Wednesday=2,Thursday=3,Friday=4,Saturday=5,Sunday=6
    };

    public class Bar
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BarTag> BarTags { get; set; }
        public List<Day> DaysOpen { get; set; }
        public int OpeningTime { get; set; }
        public int ClosingTime { get; set; }
        public String Picture { get; set; }
        public Guid UserId { get; set; }

        public Bar(string name
            ,List<BarTag> barTags
            ,int openingTime
            ,int closingTime
            ,string picture
            ,Guid userId)
        {
            Id = Guid.NewGuid();
            Name = name;
            BarTags = barTags;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            Picture = picture;
            UserId = userId;
        }

        public Bar()
        {
        }

        public override bool Equals(Object item)
        {
            if ((Bar)item == this) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode()*4 + Name.GetHashCode()*5;
        }
    }
}