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
            string opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);

            switch (opcao)
            {
                case "1":
                    while (true)
                    {
                        Console.Clear();
                        ExibirTitulo("Consultas");
                        Console.WriteLine("\nDeseja marcar ou desmarcar uma consulta?");
                        opcao = StringCheck.NullOrEmpty(Console.ReadLine()!);
                        if (StringCheck.IsSimilar(opcao, "marcar"))
                        {
                            MarcarConsulta();
                            break;
                        }
                        else if (StringCheck.IsSimilar(opcao, "desmarcar"))
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
                string pet = StringCheck.NullOrEmpty(Console.ReadLine()!);
                Console.Write("Nome do tutor: ");
                string tutor = StringCheck.NullOrEmpty(Console.ReadLine()!);

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
                        CadastrarPet();
                        Console.Clear();
                        ExibirTitulo("Marcar consulta");
                        Console.WriteLine();
                    }
                    else if (StringCheck.IsSimilar(opcao, "voltar"))
                    {
                        break;
                    }
                    else if(StringCheck.IsSimilar(opcao, "lista"))
                    {
                        ExibirPets();
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

        void DesmarcarConsuta()
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
                        ExibirPets();
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

        void ConsultarAgenda()
        {
            Console.Clear();
            ExibirTitulo("Agenda de consultas");
            Console.WriteLine();

            if (agenda.Consultas.Count == 0)
            {
                Console.WriteLine("Nenhuma consulta agendada.");
            }
            else
            {
                foreach (Consulta consulta in agenda.Consultas.OrderBy(c => c.Data))
                {
                    Console.WriteLine(consulta.Informacoes);
                    Console.WriteLine();
                }
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
            string nome = StringCheck.NullOrEmpty(Console.ReadLine()!);

            Console.Write("Digite o endereço do tutor: ");
            string endereco = StringCheck.NullOrEmpty(Console.ReadLine()!);

            Console.Write("Digite o telefone do tutor: ");
            string telefone = StringCheck.NullOrEmpty(Console.ReadLine()!);

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
                                CadastrarTutor();
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
    }
}