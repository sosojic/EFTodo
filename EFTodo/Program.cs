using System.Reflection.Metadata;
using var context = new TodoContext();

// Ajouter des nouveaux todos
var todo1 = new Todo{
    Task = "Wash the dishes",
    Completed = true
};

var todo2 = new Todo{
    Task = "Clean the house",
    Completed = false
};

var todo3 = new Todo{
    Task = "Mow the lawn",
    Completed = false
};
//context.Add(new Todo{...}) (pas obligé de mettre de id pour qu'elle soit unique)

// Ajouter les todos dans la base de données
context.Todo.Add(todo1);
context.Todo.Add(todo2);
context.Todo.Add(todo3);
context.SaveChanges();  // Sauvegarder les changements

// Récupérer la liste des todos depuis la base de données après les avoir ajoutés
var tasks = context.Todo.ToList();

Console.WriteLine($"----- Liste de tous les todos -----");
foreach (var val in tasks)
{
    Console.WriteLine($"Todo {val.Id}, task {val.Task}, completed: {val.Completed}");
}

Console.WriteLine($"----- Liste des todos non terminés -----");
foreach (var task in tasks)
{
    if (task.Completed == false)
    {
        Console.WriteLine($"Todo {task.Id}, task {task.Task}, completed: {task.Completed}");
    }
}

// Mettre à jour l'état des tâches non terminées pour les marquer comme terminées
foreach (var task in tasks) //Todo t in...
{
    if (task.Completed == false) //!task.completed
    {
        task.Completed = true;
    }
}
context.SaveChanges();  // Sauvegarder les modifications

// Récupérer à nouveau la liste des todos pour refléter les changements
tasks = context.Todo.ToList();  // Rafraîchir la liste

Console.WriteLine($"----- Liste des todos terminés -----");
foreach (var task in tasks)
{
    if (task.Completed == true)
    {
        Console.WriteLine($"Todo {task.Id}, task {task.Task}, completed: {task.Completed}");
    }
}

// Supprimer toutes les tâches
foreach (var task in tasks)
{
    context.Todo.Remove(task);
}
context.SaveChanges();  // Sauvegarder les suppressions

Console.WriteLine("----- Suppression de tous les todos -----");
