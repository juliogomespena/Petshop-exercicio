using PetshopExercicio.Utility;

namespace PetshopExercicio.Menu;

internal class MenuMarcarDesmarcar : Menu
{
    public override void ExibirMenu(Dictionary<string, object> db)
    {
        string opcao;

        while (true)
        {
            Console.Clear();
            ExibirTitulo("Consultas");
            Console.WriteLine("\nDeseja marcar ou desmarcar uma consulta?");
            opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);
            if (StringCheck.IsSimilar(opcao, "marcar"))
            {
                Menu menu = new MenuMarcarConsulta();
                menu.ExibirMenu(db);
                break;
            }
            else if (StringCheck.IsSimilar(opcao, "desmarcar"))
            {
                Menu menu = new MenuDesmarcarConsulta();
                menu.ExibirMenu(db);
                break;
            }
            else Console.WriteLine("Opção inválida!");
            Thread.Sleep(600);
        }
    }
}
