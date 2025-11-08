namespace escuela.Domain;

public class Alumno
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int PadreId { get; set; }
    public Padre Padre { get; set; }
    public int MadreId { get; set; }
    public Padre Madre { get; set; }
    public int EscuelaId { get; set; }
    public Escuela Escuela { get; set; }
}