﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class HeroiBatalha
    {
        public Heroi Heroi { get; set; }
        public int HeroiId { get; set; }
        public Batalha Batalha { get; set; }
        public int BatalhaId { get; set; }
    }
}
