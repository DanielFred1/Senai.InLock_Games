﻿using System;
using System.Collections.Generic;

namespace Senai.InLock.DataBaseFirst.Domains
{
    public partial class Usuarios
    {
        public int Usuarioid { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipousuario { get; set; }
    }
}
