﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineElection.DAL;





namespace OnlineElection.BLL.Repository
{
    public class PersonRepository : IPersonRepository
    {
        OnlineElectionEntities _dbContext = new OnlineElectionEntities();

        public object Crypto { get; private set; }

        public bool registerPerson(person _objPerson)
        {
            _dbContext.people.Add(_objPerson);
            _dbContext.SaveChanges();
            Guid id = _objPerson.Person_ID;

            if (id == null) return false;

            return true;

        }


        public person LoggedUser(person User)
        {

            //person _user = new person();
            //_user.SID = User.SID;
            //_user.password

            var querySID = (from u in _dbContext.people
                         where u.SID == User.SID
                         select u.SID);


            if (querySID != null)
            {
                //return (from u in _dbContext.people
                //                where u.SID == User.SID
                //                select u).ToList();

                //return _dbContext.people.Find(User.password);

                return (from u in _dbContext.people
                        where u.SID == User.SID
                        select u).FirstOrDefault();

                //return queryPass;

            }

            return null;
           

        }
    }
}
