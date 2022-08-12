﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace QuizModels;

public class User : IdentityUser
{


    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }


}