using PetshopExercicio.Utility;
using System.ComponentModel.Design;

namespace PetshopExercicio.Menu;

internal class Menu
{
    public virtual void ExibirMenu(Dictionary <string, object> db)
    {
        Dictionary<string, Menu> menus = new();
        menus.Add("1", new MenuMarcarDesmarcar());
        menus.Add("2", new MenuConsultarAgenda());
        menus.Add("3", new MenuCadastrarTutor());
        menus.Add("4", new MenuCadastrarPet());
        menus.Add("5", new MenuExibirTutores());
        menus.Add("6", new MenuExibirPets());
        menus.Add("0", new MenuSair());

        Console.Clear();
        ExibirTitulo("Petshop Class One");
        Console.WriteLine("\n");
        Console.WriteLine("1 - Marcar ou desmarcar consulta");
        Console.WriteLine("2 - Consultar agenda");
        Console.WriteLine("3 - Cadastrar tutor");
        Console.WriteLine("4 - Cadastrar pet");
        Console.WriteLine("5 - Exibir tutores cadastrados");
        Console.WriteLine("6 - Exibir pets cadastrados");
        Console.WriteLine("0 - Sair");
        Console.Write("\nDigite o menu desejado: ");
        string opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);

        if (!menus.ContainsKey(opcao))
        {
            Console.WriteLine("Opção inválida");
            Thread.Sleep(600);
            ExibirMenu(db);
        }
        else
        { 
            Menu menu = menus[opcao]; 
            menu.ExibirMenu(db);
        }
        ExibirMenu(db);
    }
    internal static void ExibirTitulo(string titulo)
    {
        titulo = "********* " + titulo + " *********";
        int tamanho = titulo.Length;
        string asteriscos = string.Empty.PadLeft(tamanho, '*');

        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos);
    }
}
