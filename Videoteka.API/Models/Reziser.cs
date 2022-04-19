﻿using System.ComponentModel.DataAnnotations;

namespace Videoteka.API.Models;

public class Reziser
{
    [Key][Required] public int Id { get; set; }

    public string Ime { get; set; }
    public string Priimek { get; set; }
}