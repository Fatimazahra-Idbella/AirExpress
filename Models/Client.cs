using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using VotreApplication.Models;
public class Client
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string CIN { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; }
}