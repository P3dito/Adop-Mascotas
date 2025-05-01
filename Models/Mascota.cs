using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("t_mascota")]
public class Mascota
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Range(0, 100)]
    public int Edad { get; set; }

    [Required]
    public string? Tipo { get; set; }

    public bool EstaAdoptada { get; set; } = false;

    public Adopcion? Adopcion { get; set; }
}
