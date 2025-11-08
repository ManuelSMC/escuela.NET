namespace escuela.Domain;


public class Padre
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Alumno> HijosComoPadre { get; set; } = new List<Alumno>();
    public ICollection<Alumno> HijosComoMadre { get; set; } = new List<Alumno>();
}