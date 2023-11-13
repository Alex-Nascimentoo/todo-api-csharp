# Todo API (C#)

This is a simple to-do API to learn basic concepts in ASP.NET and Entity Framework



## Routes
__GET__ `http://localhost:5136/api/task` will return an array of tasks:
```json
[
  {
    "id": 1,
    "title": "First task"
  },
  {
    "id": 2,
    "title": "Second task"
  }
]
```

##

__GET__ `http://localhost:5136/api/task/{id}` will return a single task
```json
{
  "id": 0,
  "title": "{Task title}"
}
```

##

__POST__ `http://localhost:5136/api/task` will receive a JSON body with task info and return the new task. The body should look like this:
```json
{
  "title": "{some title here}"
}
```

##

__PUT__ `http://localhost:5136/api/task/{id}` will receive a JSON body with task info and return the string "Task updated successfully". The body should be just like the POST method.

##

__DELETE__ `http://localhost:5136/api/task/{id}` will delete the task corresponding to the id in route and return the string "Task deleted successfully".


