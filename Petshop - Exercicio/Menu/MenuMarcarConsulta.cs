using PetshopExercicio.Entidades;
using PetshopExercicio.Utility;

namespace PetshopExercicio.Menu;

internal class MenuMarcarConsulta : Menu
{
    public override void ExibirMenu(Dictionary<string, object> db)
    {
        Console.Clear();
        ExibirTitulo("Marcar consulta");
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

                    bool veterinarioLocalizado = false;
                    while (!veterinarioLocalizado)
                    {
                        Console.Write("\nQual veterinário fará a consulta: ");
                        string veterinario = StringCheck.NullOrEmpty(Console.ReadLine()!);

                        List<Veterinario> veterinariosCadastrados = (List<Veterinario>)db["veterinarios"];
                        Veterinario vetEncontrado = veterinariosCadastrados.Find(v => StringCheck.IsSimilar(v.Nome, veterinario));

                        if (vetEncontrado != null)
                        {
                            Console.WriteLine($"\nVeterinário Dr.{vetEncontrado.Nome} é o correto?");
                            opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);
                            if (StringCheck.IsSimilar(opcao, "sim"))
                            {
                                veterinarioLocalizado = true;

                                Console.Write("\nDigite a data da consulta (formato xx/xx/xx): ");
                                DateTime Data = DateTime.Parse(StringCheck.NullOrEmpty(Console.ReadLine()!));

                                Console.Write("Digite a hora da consulta (formato xx:xx): ");
                                TimeSpan Hora = TimeSpan.Parse(StringCheck.NullOrEmpty(Console.ReadLine()!));

                                Console.Write("Digite mais informações da consulta: ");
                                string observacoes = StringCheck.NullOrEmpty(Console.ReadLine()!);

                                Agenda agenda = (Agenda)db["agenda"];
                                agenda.Agendar(new Consulta(petEncontrado, vetEncontrado, Data, Hora, observacoes));
                                Console.WriteLine("\nConsulta agendada com sucesso!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veterinário não encontrado. Tem certeza que está cadastrado?");
                        }
                    }

                    break;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Pet não encontrado.\n\nPara exibir lista de Pets, digite 'lista'.\nPara cadastrar, digite 'cadastro'.\nPara voltar, digite 'voltar'.\nPara tentar novamente, digite 'tentar'.");
                string opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);

                if (StringCheck.IsSimilar(opcao, "cadastro"))
                {
                    Menu menu = new MenuCadastrarPet();
                    menu.ExibirMenu(db);
                    Console.Clear();
                    ExibirTitulo("Marcar consulta");
                    Console.WriteLine();
                }
                else if (StringCheck.IsSimilar(opcao, "voltar"))
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
