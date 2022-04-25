﻿using System.ComponentModel.DataAnnotations;

namespace Seznami.API.Models;

public class Uporabnik
{
    [Key][Required] public int Id { get; set; }

    public string Guid { get; set; } = string.Empty;
}