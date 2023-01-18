using System;
using System.Collections.Generic;

namespace E_learning_Back.Models;

public partial class Cour
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? CategoryId { get; set; }

    public string? Img { get; set; }

    public string? Description { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<SkillCour> SkillCours { get; } = new List<SkillCour>();
}
