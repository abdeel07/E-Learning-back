using System;
using System.Collections.Generic;

namespace E_learning_Back.Models;

public partial class Admin
{
    public int IdAdmin { get; set; }

    public string? AdminName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
