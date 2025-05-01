using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("t_adopcion")]
public class Adopcion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int MascotaId { get; set; }

    [ForeignKey("MascotaId")]
    public Mascota? Mascota { get; set; }

    [Required]
    public int AdoptanteId { get; set; }

    [ForeignKey("AdoptanteId")]
    public Adoptante? Adoptante { get; set; }

    public DateTime FechaAdopcion { get; set; } = DateTime.Now;
}
