namespace escuela.Domain;
public class Escuela
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}