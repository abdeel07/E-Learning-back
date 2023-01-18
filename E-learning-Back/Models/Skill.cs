using System;
using System.Collections.Generic;

namespace E_learning_Back.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<SkillCour> SkillCours { get; } = new List<SkillCour>();
}
