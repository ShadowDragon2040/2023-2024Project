﻿using AdatKarbantarto.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class AuthenticatedUser
    {
        public User User { get; set; }
        public string Token { get; set; }
    }

}
