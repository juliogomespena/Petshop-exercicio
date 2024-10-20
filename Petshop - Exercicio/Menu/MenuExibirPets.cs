using PetshopExercicio.Entidades;

namespace PetshopExercicio.Menu;

internal class MenuExibirPets : Menu
{
    public override void ExibirMenu(Dictionary<string, object> db)
    {
        Console.Clear();
        ExibirTitulo("Pets cadastrados");
        Console.WriteLine();

        List<Pet> petsCadastrados = (List<Pet>)db["pets"];

        foreach (Pet pet in petsCadastrados)
        {
            Console.WriteLine(pet.Informacoes);
            Console.WriteLine();
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}
