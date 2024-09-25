var todo1= new Todo{
    Id=4,
    Task="Wash the dishes",
    Completed=true
};

var todo2= new Todo{
    Id=5,
    Task="Clean the house",
    Completed=false
};

var todo3= new Todo{
    Id=6,
    Task="Mow the lawn",
    Completed=false
};
using var context=new TodoContext();
context.Todo.Add(todo1);
context.Todo.Add(todo2);
context.Todo.Add(todo3);
