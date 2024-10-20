using PetshopExercicio.Entidades;
using PetshopExercicio.Utility;

namespace PetshopExercicio.Menu;

internal class MenuCadastrarPet : Menu
{
    public override void ExibirMenu(Dictionary<string, object> db)
    {
        Console.Clear();
        ExibirTitulo("Cadastro de pet");
        Console.WriteLine();

        Console.Write("\nDigite o nome do pet: ");
        string nome = StringCheck.NullOrEmpty(Console.ReadLine()!);

        while (true)
        {
            Console.Write("\nDigite a espécie(cachorro/gato) do pet: ");
            string especie = StringCheck.NullOrEmpty(Console.ReadLine()!);

            if (StringCheck.IsSimilar(especie, "cachorro") || StringCheck.IsSimilar(especie, "gato"))
            {
                Console.Write("\nDigite a raça do pet: ");
                string raca = StringCheck.NullOrEmpty(Console.ReadLine()!);

                Console.Write("\nDigite a idade do pet: ");
                string strIdade = StringCheck.NullOrEmpty(Console.ReadLine()!);
                int idade = int.Parse(strIdade);

                bool tutorLocalizado = false;

                while (!tutorLocalizado)
                {
                    Console.Write("\nDigite o nome do tutor: ");
                    string tutor = StringCheck.NullOrEmpty(Console.ReadLine()!);

                    List<Tutor> tutoresCadastrados = (List<Tutor>)db["tutores"];
                    Tutor tutorEncontrado = tutoresCadastrados.Find(t => StringCheck.IsSimilar(t.Nome, tutor));

                    if (tutorEncontrado != null)
                    {
                        Console.WriteLine($"Tutor: {tutorEncontrado.Nome}\n");
                        Console.WriteLine("Tutor encontrado é o correto?");
                        string opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);

                        if (StringCheck.IsSimilar(opcao, "sim"))
                        {
                            if (tutorEncontrado.Pets.Any(p => StringCheck.IsSimilar(p.Nome, nome) && StringCheck.IsSimilar(p.Especie, especie)))
                            {
                                Console.WriteLine("\nPet já cadastrado para esse tutor.");
                                break;
                            }
                            tutorLocalizado = true;

                            List<Pet> petsCadastrados = (List<Pet>)db["pets"];
                            petsCadastrados.Add(new Pet(nome, especie, raca, idade, tutorEncontrado));
                            Console.WriteLine("\nPet cadastrado com sucesso!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tutor não encontrado. Deseja cadastrar novo tutor?");
                        string opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);

                        if (StringCheck.IsSimilar(opcao, "sim"))
                        {
                            Menu menu = new MenuCadastrarTutor();
                            menu.ExibirMenu(db);
                            Console.Clear();
                            ExibirTitulo("Cadastro de pet");
                            Console.WriteLine();
                        }
                    }
                }
                break;
            }
            else
                Console.WriteLine("Espécie não reconhecida. Digite 'cachorro' ou 'gato'");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}
