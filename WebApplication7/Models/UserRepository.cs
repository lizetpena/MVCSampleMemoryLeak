//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

//
// UserRepository.cs
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleLeak.Models;

namespace SampleLeak.Data
{
    public static class UserRepository
    {
        //Store a local copy of recent users in memory to prevent extra database queries
        static private List<User> m_userCache = new List<User>();
        public static List<User> UserCache { get { return m_userCache; } }

        public static User GetUser(string userID) 
        {

            #region MemLeakFix
            //Fix memory leak by retrieving from cache
            //note the code below doesn't consider a cache eviction scenario if the User object is updated.

            //if (m_userCache.Count > 0)
            //{
            //    var u = from User s in m_userCache
            //            where s.Id == userID
            //            select s;
            //    if ((u != null)&&(u.Count()>0))
            //    {
            //        return u.First<User>();
            //    }

            //}
            #endregion


            //Retrieve the user’s database record 
            User user = MockDatabase.SelectOrCreateUser(
                "select * from Users where Id = @p1",
                userID);

            //Add the user to cache before returning 
            m_userCache.Add(user);
            return user; 
        }

    }
}