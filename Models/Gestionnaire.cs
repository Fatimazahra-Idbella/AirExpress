using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Gestionnaire
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(50)]
    public string Nom { get; set; }

    [Required(ErrorMessage = "Le prénom est obligatoire")]
    [StringLength(50)]
    public string Prenom { get; set; }

    [NotMapped]
    public string NomComplet => $"{Prenom} {Nom}";

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string Telephone { get; set; }

    [Required]
    public string Secteur { get; set; } // National, International, Cargo

    [DataType(DataType.Date)]
    public DateTime DateEmbauche { get; set; } = DateTime.Now;

    // Relations
    public ICollection<Vol> Vols { get; set; } = new List<Vol>();
}