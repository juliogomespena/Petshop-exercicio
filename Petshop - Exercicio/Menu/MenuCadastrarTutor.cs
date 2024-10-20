using PetshopExercicio.Entidades;
using PetshopExercicio.Utility;

namespace PetshopExercicio.Menu;

internal class MenuCadastrarTutor : Menu
{
    public override void ExibirMenu(Dictionary<string, object> db)
    {
        Console.Clear();
        ExibirTitulo("Cadastro de tutor");
        Console.WriteLine();

        Console.Write("Digite o nome do tutor: ");
        string nome = StringCheck.NullOrEmpty(Console.ReadLine()!);

        Console.Write("Digite o endereço do tutor: ");
        string endereco = StringCheck.NullOrEmpty(Console.ReadLine()!);

        Console.Write("Digite o telefone do tutor: ");
        string telefone = StringCheck.NullOrEmpty(Console.ReadLine()!);

        List<Tutor> tutoresCadastrados = (List<Tutor>)db["tutores"];

        tutoresCadastrados.Add(new Tutor(nome, telefone, endereco));
        Console.WriteLine($"\nTutor {nome} cadastrado com sucesso!");

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}
