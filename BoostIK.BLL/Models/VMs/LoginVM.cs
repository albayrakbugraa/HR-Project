﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.BLL.Models.VMs
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
        public bool isPasswordChanged { get; set; }
    }
}
