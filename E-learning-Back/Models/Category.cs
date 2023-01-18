using System;
using System.Collections.Generic;

namespace E_learning_Back.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Img { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Cour> Cours { get; } = new List<Cour>();
}
