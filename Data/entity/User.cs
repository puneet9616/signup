using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace dotproject.Data
{
  public class User
  {

    [Key]
    public int id { get; set; }
    [Required, StringLength(100)]
    public string Username { get; set; }
    [Required, StringLength(100)]
    public string Email { get; set; }
    [Required, StringLength(100)]
    public string Password { get; set; }
    [Required, StringLength(100)]
    public string ConfirmPassword { get; set; }


    public int Isactive { get; set; } = 1;

    public int contact { get; set; }

    [Required, StringLength(100)]
    public string gender { get; set; }

    [Required]
    public string Profileimage { get; set; }

  }
}