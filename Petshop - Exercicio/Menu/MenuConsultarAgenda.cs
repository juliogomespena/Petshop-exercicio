using PetshopExercicio.Entidades;

namespace PetshopExercicio.Menu;

internal class MenuConsultarAgenda : Menu
{
    public override void ExibirMenu(Dictionary<string, object> db)
    {
        Console.Clear();
        ExibirTitulo("Agenda de consultas");
        Console.WriteLine();

        Agenda agenda = (Agenda)db["agenda"];

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
}
