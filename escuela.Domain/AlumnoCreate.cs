namespace escuela.Domain;
public class AlumnoCreate
{
    public string Nombre { get; set; }
    public int PadreId { get; set; }
    public int MadreId { get; set; }
    public int EscuelaId { get; set; }
}