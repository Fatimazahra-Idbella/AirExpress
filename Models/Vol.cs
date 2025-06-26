

using VotreApplication.Models;

public class Vol
#pragma warning restore CA1050 // Declare types in namespaces
{
    public int Id { get; set; }
    public string Destination { get; set; } = string.Empty;
    public string Depart { get; set; } = string.Empty;
    public DateTime DateDepart { get; set; }
    public decimal Prix { get; set; }
    public int PlacesDisponibles { get; set; }
    public int PlacesMax { get; internal set; }

    public virtual ICollection<Reservation> Reservations { get; set; }


}