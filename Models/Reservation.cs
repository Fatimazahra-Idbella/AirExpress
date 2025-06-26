using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotreApplication.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date de réservation")]
        public DateTime DateReservation { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Statut")]
        public bool Confirmee { get; set; } = true;

        // Clé étrangère pour Client
        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        // Relation many-to-one avec Client
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        // Clé étrangère pour Vol
        [Required]
        [Display(Name = "Vol")]
        public int VolId { get; set; }

        // Relation many-to-one avec Vol
        [ForeignKey("VolId")]
        public virtual Vol Vol { get; set; }

        // Propriétés supplémentaires (optionnelles)
        [Display(Name = "Classe")]
        public string? Classe { get; set; }  // Economique, Affaire, Première

        [Display(Name = "Numéro de siège")]
        public string? NumeroSiege { get; set; }

        [Display(Name = "Prix payé")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrixPaye { get; set; }
    }
}