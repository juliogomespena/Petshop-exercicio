namespace PetshopExercicio.Entidades;

internal class Agenda
{
    public Agenda()
    {
        if (Consultas == null)
            Consultas = new List<Consulta>();
    }
    public List<Consulta> Consultas { get; set; }
    public void Agendar(Consulta consulta)
    {
        Consultas.Add(consulta);
    }
}
