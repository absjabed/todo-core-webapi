using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using todo_core_webapi.Interface;
using todo_core_webapi.Entities;
using todo_core_webapi.Dtos;
using todo_core_webapi.Models;

namespace todo_core_webapi.Services
{
    public class DataOperationService : IDataOperations
    {
        private ToDoDbContext _context;
        private readonly IMapper _mapper;

        public DataOperationService(ToDoDbContext context, IMapper mapper){
            _mapper = mapper;
            _context = context;
        }

        public List<TodoTableDto> GetUserTodos(UserTodoIdModel userTodoIdModel)
        {
             var todos = _context.TodoTable.Where(x => x.VUserId.Equals(userTodoIdModel.VUserId) && x.BIsDeleted.Equals(false)).ToList();

             if (todos == null) return null;

             List<TodoTableDto> todoData = _mapper.Map<List<TodoTableDto>>(todos);
            
            return todoData;
        }
        public TodoOperationResponse AddTodo(TodoTableDto todo)
        {
            TodoOperationResponse response = new TodoOperationResponse();
            var userEntity = _context.UserInfoTable.FirstOrDefault(x => x.VUserId.Equals(todo.VUserId) && x.BIsActive.Equals(true));
            
            if(userEntity != null && todo != null){
                //Only Existing users will be able to add new tasks...
                TodoTable todoObj = _mapper.Map<TodoTable>(todo);
                     _context.TodoTable.Add(todoObj);
                var res = _context.SaveChanges();
                
                if(res > 0){
                        response = new TodoOperationResponse{
                        isSucceeed = true,
                        vMessage = "New ToDo added successfully!."
                    };

                    return response;
                }
            }
            //Only Existing users will be able to add new tasks...
            response = new TodoOperationResponse{
                isSucceeed = false,
                vMessage =  (userEntity == null) ? "Unregistered users will not be able to add new task!" : "Failed To add new task!."
            };
            
            return response;
        }
        public TodoOperationResponse UpdateTodo(TodoTableDto todo)
        {
            TodoOperationResponse response = new TodoOperationResponse();

            TodoTable todoObj = _mapper.Map<TodoTable>(todo);
            var entity = _context.TodoTable.FirstOrDefault(x => x.VTodoId.Equals(todoObj.VTodoId) && x.VUserId.Equals(todoObj.VUserId) && x.BIsDeleted.Equals(false));

            // Validate entity is not null
            if (entity != null)
            {
                // Make changes on entity
                entity.VUserId = todoObj.VUserId;
                entity.VTodoTitle = todoObj.VTodoTitle;
                entity.VTodoDescription = todoObj.VTodoDescription;
                entity.DDate = todoObj.DDate;
                entity.TTime = todoObj.TTime;
                entity.VLocation = todoObj.VLocation;
                entity.TNotifyTime = todoObj.TNotifyTime;
                entity.VColorLabel = todoObj.VColorLabel;
                entity.BIsDone = todoObj.BIsDone;
                
                // Save changes in database
                var res = _context.SaveChanges();

                if(res > 0) {
                    response = new TodoOperationResponse{
                        isSucceeed = true,
                        vMessage = "Task updated successfully..."
                    };
                    return response;
                }
            }
                response = new TodoOperationResponse{
                    isSucceeed = false,
                    vMessage = "Faild to update task..."
                };
                return response;
        }
        public TodoOperationResponse DeleteTodo(UserTodoIdModel userTodoIdModel)
        {
            TodoOperationResponse response = new TodoOperationResponse();
            var entity = _context.TodoTable.FirstOrDefault(x => x.VTodoId.Equals(userTodoIdModel.VTodoId) && x.VUserId.Equals(userTodoIdModel.VUserId) && x.BIsDeleted.Equals(false));
             // Validate entity is not null
            if (entity != null)
            {
                // Make changes on entity
                entity.BIsDeleted = true;
                
                // Save changes in database
                var res = _context.SaveChanges();

                if(res > 0) {
                    response = new TodoOperationResponse{
                        isSucceeed = true,
                        vMessage = "Task Deleted successfully..."
                    };
                    return response;
                }
            }
            response = new TodoOperationResponse{
                isSucceeed = false,
                vMessage = "Faild to delete task..."
            };
            return response;
        }
        public TodoOperationResponse DoneTodo(UserTodoIdModel userTodoIdModel)
        {
            TodoOperationResponse response = new TodoOperationResponse();
             var entity = _context.TodoTable.FirstOrDefault(x => x.VTodoId.Equals(userTodoIdModel.VTodoId) && x.VUserId.Equals(userTodoIdModel.VUserId) && x.BIsDeleted.Equals(false));
             // Validate entity is not null
            if (entity != null)
            {
                // Make changes on entity
                entity.BIsDone = true;
                
                // Save changes in database
                var res = _context.SaveChanges();

                if(res > 0) {
                    response = new TodoOperationResponse{
                        isSucceeed = true,
                        vMessage = "Task marked as done."
                    };
                    return response;
                }
            }
            response = new TodoOperationResponse{
                isSucceeed = false,
                vMessage = "Faild to mark the task as done."
            };
            return response;
        }
        public AuthenticationResponse LoginUser(AuthenticationRequest authenticationRequest)
        {
            AuthenticationResponse authenticationResponse = new AuthenticationResponse();

            var userEntity = _context.UserInfoTable.FirstOrDefault(x => x.VUserId.Equals(authenticationRequest.VUserId) && x.VPassword.Equals(authenticationRequest.VPassword) && x.BIsActive.Equals(true));

            if(userEntity != null){
                UserInfoTableDto _userObj = _mapper.Map<UserInfoTableDto>(userEntity);

                authenticationResponse = new AuthenticationResponse {
                    isAuthenticated = true,
                    vMessage = "Authentication Succeed!",
                    userObj = _userObj
                };
            }else{
                authenticationResponse = new AuthenticationResponse {
                    isAuthenticated = false,
                    vMessage = "Authentication Failed!",
                    userObj = null
                };
            };

            return authenticationResponse;
        }
        public AuthenticationResponse RegisterUser(UserRegistrationModel userRegistrationModel)
        {
            UserInfoTableDto userInfoTableDto = new UserInfoTableDto {
                IAutoId = 0,
                VUserId = userRegistrationModel.VUserId,
                VFullName = userRegistrationModel.VFullName,
                DDateOfBirth = userRegistrationModel.DDateOfBirth,
                VPassword = userRegistrationModel.VPassword,
                BIsActive = true
            };
            AuthenticationResponse authenticationResponse = new AuthenticationResponse();

            var userEntity = _context.UserInfoTable.FirstOrDefault(x => x.VUserId.Equals(userInfoTableDto.VUserId));

            if(userEntity != null){ //Check if this userid already exists in the system...
                authenticationResponse = new AuthenticationResponse {
                    isAuthenticated = false,
                    isRegistrationSucceed = false,
                    vMessage = "This UserId is not available for new registration!",
                    userObj = null
                };
            }else{
                // New User Registration...

                UserInfoTable userObj = _mapper.Map<UserInfoTable>(userInfoTableDto);

                _context.UserInfoTable.Add(userObj);
                var res = _context.SaveChanges();

                if(res > 0){  // New User Registration entry succeed...

                    UserInfoTableDto newUserObj = _mapper.Map<UserInfoTableDto>(userObj);
                        authenticationResponse = new AuthenticationResponse {
                            isAuthenticated = true,
                            isRegistrationSucceed = true,
                            vMessage = "SignUp Successfull!!",
                            userObj = newUserObj
                        };
                    
                }else{ // New User Registration entry failed...
                        authenticationResponse = new AuthenticationResponse {
                            isAuthenticated = false,
                            isRegistrationSucceed = false,
                            vMessage = "SignUp Failed!",
                            userObj = null
                        };
                }
            }

            return  authenticationResponse;
        }
    }
}