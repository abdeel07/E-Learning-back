using System;
using System.Collections.Generic;

namespace E_learning_Back.Models;

public partial class SkillCour
{
    public int IdCours { get; set; }

    public int IdSkill { get; set; }

    public int? Id { get; set; }

    public virtual Cour IdCoursNavigation { get; set; } = null!;

    public virtual Skill IdSkillNavigation { get; set; } = null!;
}
