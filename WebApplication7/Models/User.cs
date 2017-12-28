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
// User.cs
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleLeak.Models
{
    public class User
    {
        public User()
            : this(String.Empty)
        {
        }

        public User(string userName)
        {
            UserName = userName;
            Id = Guid.NewGuid().ToString();
        }

        public User(Guid id, bool addBinaryData)
        {
            UserName = String.Empty;
            Id = id.ToString();
            if (addBinaryData)
            {
                //approx 10MB of an empty byte array allocated in memory when User object is constructed with addBinaryData flag set to true
                BinaryData = new byte[10 *1024 * 1024];
            }
        }

        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public byte[] BinaryData { get; set; }
    }
}