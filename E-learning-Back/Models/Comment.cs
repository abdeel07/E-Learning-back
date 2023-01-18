using System;
using System.Collections.Generic;

namespace E_learning_Back.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public int? Score { get; set; }

    public int? IdCours { get; set; }

    public virtual Cour? IdCoursNavigation { get; set; }
}
