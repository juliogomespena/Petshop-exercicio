using PetshopExercicio.Entidades;
using PetshopExercicio.Utility;
using PetshopExercicio.Menu;

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

        Dictionary<string, object> db = new();
        db.Add("tutores", tutoresCadastrados);
        db.Add("pets", petsCadastrados);
        db.Add("veterinarios", veterinariosCadastrados);
        db.Add("agenda", agenda);

        Menu menu = new();
        menu.ExibirMenu(db);


    }
}