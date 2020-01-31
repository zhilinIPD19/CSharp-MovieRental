﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_MovieRental
{
    public class Movie
    {
        private readonly ObservableListSource<BorrowHistory> borrowHistory = new ObservableListSource<BorrowHistory>();
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public decimal Rating { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Synopsis { get; set; }
        public string ImageURL { get; set; }
        public int GenreId { get; set; } // we have a var with this name in Genre class
        public virtual Genre Genre { get; set; }
        public virtual ObservableListSource<BorrowHistory> BorrowHistory { get { return borrowHistory; } }
        //validation
        public bool IsValid()
        {
            return (this.Validate().Count() == 0);
        }

        public IEnumerable<string> Validate()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                yield return "First Name is Mandatory.";
            }
            if (string.IsNullOrEmpty(this.Director))
            {
                yield return "Director Name is Mandatory.";
            }
            if (this.Rating > 5)
            {
                yield return "Rating must between 0 - 10.";
            }
            if (this.Rating <= 0)
            {
                yield return "Rating must between 0 - 10.";
            }
            if (this.Year > 2020)
            {
                yield return "Year is over 2020.";
            }
            if (this.Year < 1900)
            {
                yield return "Year is less than 1800.";
            }
            if (string.IsNullOrEmpty(this.Synopsis))
            {
                yield return "Synopsis is Mandatory.";
            }
        }
    }
}