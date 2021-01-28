using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todo_core_webapi.Dtos;
using todo_core_webapi.Interface;
using todo_core_webapi.Models;

namespace todo_core_webapi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApiDataController : ControllerBase
    {
        private IDataOperations _iDataOperations;

        private readonly ILogger<ApiDataController> _logger;

        public ApiDataController(ILogger<ApiDataController> logger, IDataOperations iDataOperations)
        {
            _iDataOperations = iDataOperations;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticationRequest authenticationRequest)
        {
            var authenticationResponse = _iDataOperations.LoginUser(authenticationRequest);

            return Ok(authenticationResponse);
        }

        [HttpPost]
        public IActionResult SignUp(UserRegistrationModel userRegistrationModel)
        {
            var registrationResponse = _iDataOperations.RegisterUser(userRegistrationModel);

            return Ok(registrationResponse);
        }

        [HttpPost]
        public IActionResult UserTodos(UserTodoIdModel userTodoIdModel)
        {
            var userTodoResponse = _iDataOperations.GetUserTodos(userTodoIdModel);

            return Ok(userTodoResponse);
        }

        [HttpPost]
        public IActionResult AddTodo(TodoTableDto todoTableDto)
        {
            var todoAddedResponse = _iDataOperations.AddTodo(todoTableDto);

            return Ok(new{ addedStatus = todoAddedResponse});
        }

        [HttpPost]
        public IActionResult UpdateTodo(TodoTableDto todoTableDto)
        {
            var todoUpdatedResponse = _iDataOperations.UpdateTodo(todoTableDto);

            return Ok(new{ updatedStatus = todoUpdatedResponse});
        }

        [HttpPost]
        public IActionResult DeleteTodo(UserTodoIdModel userTodoIdModel)
        {
            var todoDeletedResponse = _iDataOperations.DeleteTodo(userTodoIdModel);

            return Ok(new{ deletedStatus = todoDeletedResponse});
        }

        [HttpPost]
        public IActionResult DoneTodo(UserTodoIdModel userTodoIdModel)
        {
            var todoDoneResponse = _iDataOperations.DoneTodo(userTodoIdModel);

            return Ok(new{ doneStatus = todoDoneResponse});
        }
    }
}
