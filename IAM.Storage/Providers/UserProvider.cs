﻿using IAM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IAM.Storage.Providers
{
    public class UserProvider : IUserProvider
    {
        IDbContext Context;

        public UserProvider(IDbContext context)
        {
            Context = context;
        }
        public void AddUser(string userEmail, string firstName, string lastName, 
            string password, DateTime? dob, string country, string status)
        {
            Context.AddUser(new User
            {
                Country = country,
                DOB = dob,
                Password = password,
                Status = status,
                User_Email = userEmail,
                User_fristName = firstName,
                User_lastName = lastName
            });
        }
        public void AddUser(User user)
        {
            Context.AddUser(user);
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userEmail)
        {
            var user = Context.GetUsers().FirstOrDefault(x => x.User_Email == userEmail);
            //var user = DatabaseData.Users.Where(x => x.Name == username).FirstOrDefault();
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = Context.GetUsers();
            return users;
        }
    }
}
