using PetshopExercicio.Entidades;

internal class Program
{
    static void Main(string[] args)
    {
        List<Tutor> tutoresCadastrados = new();
        List<Pet> petsCadastrados = new();
        List<Veterinario> veterinariosCadastrados = new();

        Agenda agenda = new Agenda();

        Tutor tutor01 = new Tutor("João", "11 99999-9999", "Rua A, 123");
        Tutor tutor02 = new Tutor("Maria", "11 99999-9999", "Rua B, 456");
        Tutor tutor03 = new Tutor("José", "11 99999-9999", "Rua C, 789");
        Tutor tutor04 = new Tutor("Ana", "11 99999-9999", "Rua D, 012");

        Veterinario vet01 = new Veterinario("Carlos", "Clínico Geral");
        Veterinario vet02 = new Veterinario("Cláudia", "Cirurgião");

        Pet pet01 = new Pet("Rex", "Cachorro", "Vira-lata", 3, tutor01);
        Pet pet02 = new Pet("Mingau", "Gato", "Siames", 2, tutor01);
        Pet pet03 = new Pet("Chines", "Cachorro", "Pastor Alemão", 5, tutor02);
        Pet pet04 = new Pet("Nina", "Gato", "Persa", 1, tutor03);
        Pet pet05 = new Pet("Toddle", "Cachorro", "Poodle", 4, tutor04);
        Pet pet06 = new Pet("Tigre", "Gato", "Sphynx", 9, tutor04);

        veterinariosCadastrados.Add(vet01);
        veterinariosCadastrados.Add(vet02);
        tutoresCadastrados.Add(tutor01);
        tutoresCadastrados.Add(tutor02);
        tutoresCadastrados.Add(tutor03);
        tutoresCadastrados.Add(tutor04);
        petsCadastrados.Add(pet01);
        petsCadastrados.Add(pet02);
        petsCadastrados.Add(pet03);
        petsCadastrados.Add(pet04);
        petsCadastrados.Add(pet05);
        petsCadastrados.Add(pet06);


        ExibirMenu();

        void ExibirMenu()
        {
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
            string opcao = ChecarInputString(Console.ReadLine()!);

            switch (opcao)
            {
                case "1":
                    while (true)
                    {
                        Console.Clear();
                        ExibirTitulo("Consultas");
                        Console.WriteLine("\nDeseja marcar ou desmarcar uma consulta?");
                        opcao = ChecarInputString(Console.ReadLine()!);
                        if (opcao.ToUpper() == "MARCAR")
                        {
                            MarcarConsulta();
                            break;
                        }
                        else if (opcao.ToUpper() == "DESMARCAR")
                        {
                            DesmarcarConsuta();
                            break;
                        }
                        else Console.WriteLine("Opção inválida!");
                        Thread.Sleep(600);
                    }
                    break;
                case "2":
                    Console.Clear();
                    ConsultarAgenda();
                    break;
                case "3":
                    Console.Clear();
                    CadastrarTutor();
                    break;
                case "4":
                    Console.Clear();
                    CadastrarPet();
                    break;
                case "5":
                    Console.Clear();
                    ExibirTutores();
                    break;
                case "6":
                    Console.Clear();
                    ExibirPets();
                    break;
                case "0":
                    Console.WriteLine("Encerrando!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Thread.Sleep(600);
                    break;
            }
            ExibirMenu();
        }

        void ExibirTitulo(string titulo)
        {
            titulo = "********* " + titulo + " *********";
            int tamanho = titulo.Length;
            string asteriscos = string.Empty.PadLeft(tamanho, '*');

            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos);
        }

        void MarcarConsulta()
        {
            Console.Clear();
            ExibirTitulo("Marcar consulta");
            Console.WriteLine();

            bool petLocalizado = false;
            while (!petLocalizado)
            {
                Console.Write("Para qual pet é a consulta: ");
                string pet = ChecarInputString(Console.ReadLine()!);

                Pet petEncontrado = petsCadastrados.Find(p => p.Nome.ToUpper() == pet.ToUpper());

                if (petEncontrado != null)
                {
                    Console.WriteLine("Pet localizado!\n");
                    petLocalizado = true;

                    bool veterinarioLocalizado = false;
                    while(!veterinarioLocalizado)
                    {
                        Console.Write("Qual veterinário fará a consulta: ");
                        string veterinario = ChecarInputString(Console.ReadLine()!);

                        Veterinario vetEncontrado = veterinariosCadastrados.Find(v => v.Nome.ToUpper() == veterinario.ToUpper());

                        if(vetEncontrado != null)
                        {
                            Console.WriteLine("Veterinário localizado!\n");
                            veterinarioLocalizado = true;

                            Console.Write("Digite a data da consulta (formato xx/xx/xx): ");
                            DateTime Data = DateTime.Parse(ChecarInputString(Console.ReadLine()!));

                            Console.Write("Digite a hora da consulta (formato xx:xx): ");
                            TimeSpan Hora = TimeSpan.Parse(ChecarInputString(Console.ReadLine()!));

                            Console.Write("Digite mais informações da consulta: ");
                            string observacoes = ChecarInputString(Console.ReadLine()!);
 
                            agenda.Agendar(new Consulta(petEncontrado, vetEncontrado, Data, Hora, observacoes));
                            Console.WriteLine("Consulta agendada com sucesso!");
                        }
                        else 
                            Console.WriteLine("Veterinário não encontrado. Tem certeza que está cadastrado?");
                    }

                    break;
                }
                else
                    Console.WriteLine("Pet não encontrado. Tem certeza que está cadastrado?");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        void DesmarcarConsuta()
        {
            Console.Clear();
            ExibirTitulo("Desmarcar consulta");
            Console.WriteLine();

            bool petLocalizado = false;
            while (!petLocalizado)
            {
                Console.Write("Para qual pet é a consulta: ");
                string pet = ChecarInputString(Console.ReadLine()!);

                Pet petEncontrado = petsCadastrados.Find(p => p.Nome.ToUpper() == pet.ToUpper());

                if (petEncontrado != null)
                {
                    Console.WriteLine("Pet localizado!\n");
                    petLocalizado = true;

                    Console.Write("Digite a data da consulta (formato xx/xx/xx): ");
                    DateTime Data = DateTime.Parse(ChecarInputString(Console.ReadLine()!));

                    Console.Write("Digite a hora da consulta (formato xx:xx): ");
                    TimeSpan Hora = TimeSpan.Parse(ChecarInputString(Console.ReadLine()!));
                    Console.WriteLine(Hora);
                    
                    Consulta consulta = agenda.Consultas.Find(c => c.Pet == petEncontrado && c.Data == DateTime.Parse(Data.ToString(@"dd/MM/yy")) && c.Hora == TimeSpan.Parse(Hora.ToString(@"hh\:mm")));

                    if (consulta != null)
                    {
                        agenda.Consultas.Remove(consulta);
                        Console.WriteLine("Consulta desmarcada com sucesso!");
                    }
                    else
                        Console.WriteLine("Consulta não encontrada. Verifique os dados e tente novamente.");
                }
                else
                    Console.WriteLine("Pet não encontrado. Digite novamente!");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        void ConsultarAgenda()
        {
            Console.Clear();
            ExibirTitulo("Agenda de consultas");
            Console.WriteLine();

            foreach (Consulta consulta in agenda.Consultas.OrderBy(c => c.Data))
            {
                Console.WriteLine(consulta.Informacoes);
                Console.WriteLine();
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        void CadastrarTutor()
        {
            Console.Clear();
            ExibirTitulo("Cadastro de tutor");
            Console.WriteLine();

            Console.Write("Digite o nome do tutor: ");
            string nome = ChecarInputString(Console.ReadLine()!);

            Console.Write("Digite o endereço do tutor: ");
            string endereco = ChecarInputString(Console.ReadLine()!);

            Console.Write("Digite o telefone do tutor: ");
            string telefone = ChecarInputString(Console.ReadLine()!);

            tutoresCadastrados.Add(new Tutor(nome, telefone, endereco));
            Console.WriteLine($"\nTutor {nome} cadastrado com sucesso!");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        void CadastrarPet()
        {
            Console.Clear();
            ExibirTitulo("Cadastro de pet");
            Console.WriteLine();

            Console.Write("\nDigite o nome do pet: ");
            string nome = ChecarInputString(Console.ReadLine()!);

            while (true)
            {
                Console.Write("\nDigite a espécie(cachorro/gato) do pet: ");
                string especie = ChecarInputString(Console.ReadLine()!);

                if (especie.ToUpper() == "CACHORRO" || especie.ToUpper() == "GATO")
                {
                    Console.Write("\nDigite a raça do pet: ");
                    string raca = ChecarInputString(Console.ReadLine()!);

                    Console.Write("\nDigite a idade do pet: ");
                    string strIdade = ChecarInputString(Console.ReadLine()!);
                    int idade = int.Parse(strIdade);

                    bool tutorLocalizado = false;

                    while (!tutorLocalizado)
                    {
                        Console.Write("\nDigite o nome do tutor: ");
                        string tutor = ChecarInputString(Console.ReadLine()!);

                        Tutor tutorEncontrado = tutoresCadastrados.Find(t => t.Nome.ToUpper() == tutor.ToUpper());

                        if (tutorEncontrado != null)
                        {
                            if(tutorEncontrado.Pets.Any(p => p.Nome.ToUpper() == nome.ToUpper() && p.Especie.ToUpper() == especie.ToUpper()))
                            {
                                Console.WriteLine("Pet já cadastrado para esse tutor.");
                                break;
                            }
                            tutorLocalizado = true;

                            petsCadastrados.Add(new Pet(nome, especie, raca, idade, tutorEncontrado));
                            Console.WriteLine("Pet cadastrado com sucesso!");
                        }
                        else
                            Console.WriteLine("Tutor não encontrado. Tem certeza que está cadastrado?");
                    }
                    break;
                }
                else
                    Console.WriteLine("Espécie não reconhecida. Digite 'cachorro' ou 'gato'");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        void ExibirPets()
        {
            Console.Clear();
            ExibirTitulo("Pets cadastrados");
            Console.WriteLine();

            foreach (Pet pet in petsCadastrados)
            {
                Console.WriteLine(pet.Informacoes);
                Console.WriteLine();
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        void ExibirTutores()
        {
            Console.Clear();
            ExibirTitulo("Tutores cadastrados");
            Console.WriteLine();

            foreach (Tutor tutor in tutoresCadastrados)
            {
                Console.WriteLine(tutor.Informacoes);
                Console.WriteLine();
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        string ChecarInputString(string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Valor inválido! Digite novamente");
                input = Console.ReadLine()!;
            }
            return input;
        }
    }
}