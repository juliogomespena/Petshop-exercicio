namespace PetshopExercicio.Entidades;

internal class Consulta
{
    public Consulta(Pet pet, Veterinario veterinario, DateTime data, TimeSpan hora, string observacoes)
    {
        Pet = pet;
        Veterinario = veterinario;
        Data = data;
        Observacoes = observacoes;
        Hora = hora;
    }

    public Pet Pet { get; set; }
    public Veterinario Veterinario { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan Hora { get; set; }
    public string Observacoes { get; set; }
    public string Informacoes => $"Pet: {Pet.Nome}\nTutor: {Pet.Tutor.Nome}\nVeterinário: {Veterinario.Nome}\nData: {Data.ToString(@"dd/MM/yy")} - {Hora.ToString(@"hh\:mm")}\nObservações: {Observacoes}";
}
