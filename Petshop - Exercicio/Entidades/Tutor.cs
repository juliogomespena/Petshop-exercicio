namespace PetshopExercicio.Entidades;

internal class Tutor
{
    public Tutor(string nome, string telefone, string endereco)
    {
        Nome = nome;
        Telefone = telefone;
        Endereco = endereco;
        if(Pets == null)
            Pets = new List<Pet>();
    }

    public string Nome { get; }
    public string Telefone { get; }
    public string Endereco { get; }
    public List<Pet> Pets { get; set; }
    public string Informacoes => $"Nome: {Nome}\nTelefone: {Telefone}\nEndereço: {Endereco}\nPets: {string.Join(", ", Pets.Select(a => a.Nome))}";

    public void AdicionarPet(Pet pet)
    {
        Pets.Add(pet);
        if(pet.Tutor != this)
            pet.Tutor = this;
    }
    public void RemoverPet(Pet pet)
    {
        Pets.Remove(pet);
        if (pet.Tutor == this)
            pet.Tutor = null;
    }
}
