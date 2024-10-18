namespace PetshopExercicio.Entidades;

internal class Pet
{
    public Pet(string nome, string especie, string raca, int idade, Tutor tutor)
    {
        Nome = nome;
        Especie = especie;
        Raca = raca;
        Idade = idade;
        Tutor = tutor;

        if (!tutor.Pets.Any(p => p == this))
            tutor.AdicionarPet(this);
    }

    public string Nome { get; }
    public string Especie { get; }
    public string Raca { get; }
    public int Idade { get; }
    public Tutor Tutor { get; set; }
    public string Informacoes => $"Nome: {Nome}\nEspécie: {Especie}\nRaça: {Raca}\nIdade: {Idade}\nTutor: {Tutor.Nome}";
}
