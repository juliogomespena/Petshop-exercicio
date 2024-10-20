using PetshopExercicio.Entidades;

namespace PetshopExercicio.Menu;

internal class MenuExibirTutores : Menu
{
    public override void ExibirMenu(Dictionary<string, object> db)
    {
        Console.Clear();
        ExibirTitulo("Tutores cadastrados");
        Console.WriteLine();

        List<Tutor> tutoresCadastrados = (List<Tutor>)db["tutores"];

        foreach (Tutor tutor in tutoresCadastrados)
        {
            Console.WriteLine(tutor.Informacoes);
            Console.WriteLine();
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}
