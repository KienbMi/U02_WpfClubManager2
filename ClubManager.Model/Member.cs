using System;
using System.Collections.Generic;
using System.Text;

namespace ClubManager.Model
{
    public class Member
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get => $"{ Firstname} {Lastname}"; }

        public DateTime BirthDate { get; set; }
    }
}
