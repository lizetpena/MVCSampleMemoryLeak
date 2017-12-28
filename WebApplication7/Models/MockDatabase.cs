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
// MockDatabase.cs
//


using SampleLeak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleLeak.Data
{
    static public class MockDatabase
    {

        //This method simulates a database for the sample app, it creates a new user object and returns it
        public static User SelectOrCreateUser(string query, string id)
        {
            //check to see if the user already has an id
            if (String.IsNullOrEmpty(id))
            {
                //If not, create a new GUID as the id
                id = Guid.NewGuid().ToString();
            }

            bool addBinaryData = query.Contains("*");
            User newUser = new User(new Guid(id), addBinaryData);
            return newUser;
        }

    }
}