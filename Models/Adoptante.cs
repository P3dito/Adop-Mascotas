using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("t_adoptante")]
public class Adoptante
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string? Nombre { get; set; }

    public ICollection<Adopcion> Adopciones { get; set; } = new List<Adopcion>();
}
