using System;
using System.Collections.Generic;
using todo_core_webapi.Dtos;
using todo_core_webapi.Models;

namespace todo_core_webapi.Interface
{
    public interface IDataOperations
    {
        List<TodoTableDto> GetUserTodos(UserTodoIdModel userTodoIdModel);
        TodoOperationResponse AddTodo(TodoTableDto todo);
        TodoOperationResponse UpdateTodo(TodoTableDto todo);
        TodoOperationResponse DeleteTodo(UserTodoIdModel userTodoIdModel);
        TodoOperationResponse DoneTodo(UserTodoIdModel userTodoIdModel);
        AuthenticationResponse LoginUser(AuthenticationRequest authenticationRequest);
        AuthenticationResponse RegisterUser(UserRegistrationModel userRegistrationModel);
        AuthenticationResponse RegisterWithSocialLogin(UserRegistrationModel userRegistrationModel);
    }
}