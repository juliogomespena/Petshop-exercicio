using PetshopExercicio.Entidades;
using PetshopExercicio.Utility;

namespace PetshopExercicio.Menu;

internal class MenuDesmarcarConsulta : Menu
{
    public override void ExibirMenu(Dictionary<string, object> db)
    {
        Console.Clear();
        ExibirTitulo("Desmarcar consulta");
        Console.WriteLine();

        bool petLocalizado = false;
        while (!petLocalizado)
        {
            Console.Write("Para qual pet é a consulta: ");
            string pet = StringCheck.NullOrEmpty(Console.ReadLine()!);
            Console.Write("Nome do tutor: ");
            string tutor = StringCheck.NullOrEmpty(Console.ReadLine()!);

            List<Pet> petsCadastrados = (List<Pet>)db["pets"];
            Pet petEncontrado = petsCadastrados.Find(p => StringCheck.IsSimilar(p.Nome, pet) && StringCheck.IsSimilar(p.Tutor.Nome, tutor));

            if (petEncontrado != null)
            {
                Console.WriteLine($"Pet: {petEncontrado.Nome} - Tutor: {petEncontrado.Tutor.Nome}\n");
                Console.WriteLine("Pet encontrado é o correto?");
                string opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);

                if (StringCheck.IsSimilar(opcao, "sim"))
                {
                    petLocalizado = true;

                    Console.Write("Digite a data da consulta (formato xx/xx/xx): ");
                    DateTime Data = DateTime.Parse(StringCheck.NullOrEmpty(Console.ReadLine()!));

                    Console.Write("Digite a hora da consulta (formato xx:xx): ");
                    TimeSpan Hora = TimeSpan.Parse(StringCheck.NullOrEmpty(Console.ReadLine()!));

                    Agenda agenda = (Agenda)db["agenda"];
                    Consulta consulta = agenda.Consultas.Find(c => c.Pet == petEncontrado && c.Data == DateTime.Parse(Data.ToString(@"dd/MM/yy")) && c.Hora == TimeSpan.Parse(Hora.ToString(@"hh\:mm")));

                    if (consulta != null)
                    {
                        agenda.Consultas.Remove(consulta);
                        Console.WriteLine("\nConsulta desmarcada com sucesso!");
                    }
                    else
                        Console.WriteLine("\nConsulta não encontrada. Verifique os dados e tente novamente.");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Pet não encontrado.\n\nPara exibir lista de Pets, digite 'lista'.\nPara voltar, digite 'voltar'.\nPara tentar novamente, digite 'tentar'.");
                string opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);

                if (StringCheck.IsSimilar(opcao, "voltar"))
                {
                    break;
                }
                else if (StringCheck.IsSimilar(opcao, "lista"))
                {
                    Menu menu = new MenuExibirPets();
                    menu.ExibirMenu(db);
                    Console.Clear();
                    ExibirTitulo("Marcar consulta");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}
