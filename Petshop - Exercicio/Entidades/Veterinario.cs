namespace PetshopExercicio.Entidades;

internal class Veterinario
{
    public Veterinario(string nome, string especialidade)
    {
        Nome = nome;
        Especialidade = especialidade;
    }

    public string Nome { get; }
    public string Especialidade { get; }
    public string Informacoes => $"Nome: Dr. {Nome}\nEspecialidade: {Especialidade}";
}
