﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Admin.Skill
{
    public class EditSkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
