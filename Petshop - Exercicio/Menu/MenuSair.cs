
namespace PetshopExercicio.Menu
{
    internal class MenuSair : Menu
    {
        public override void ExibirMenu(Dictionary<string, object> db)
        {
            Console.WriteLine("Encerrando!");
            Environment.Exit(0);
        }
    }
}
