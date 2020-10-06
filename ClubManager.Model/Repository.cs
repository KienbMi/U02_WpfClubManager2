using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Utils;

namespace ClubManager.Model
{
    public class Repository
    {
        private const string FileName = "ClubMember.csv";
        private static Repository _instance;

        private List<Member> members;

        private const int Idx_Firstname = 0;
        private const int Idx_Lastname = 1;
        private const int Idx_Birthdate = 2;

        private Repository()
        {
            members = new List<Member>();
            LoadMembersFromCsv();
        }

        public static Repository GetInstance() 
        {            
            if (_instance == null)
            {
                _instance = new Repository();
            }
            return _instance;
        }

        private void LoadMembersFromCsv()
        {
            members = FileName.ReadStringMatrixFromCsv(true)
                .Select(member => new Member {
                    Firstname = member[0],
                    Lastname = member[1],
                    BirthDate = DateTime.Parse(member[2])
                    })
                .ToList();
        }

        public void Add(Member member)
        {
            members.Add(member);
        }

        public void RemoveMember(Member member)
        {
            members.Remove(member);
        }

        public List<Member> GetAllMembers()
        {
            return members
                .OrderBy(_ => _.Lastname)
                .ThenBy(_ => _.Firstname)
                .ToList();
        }
    }
}
