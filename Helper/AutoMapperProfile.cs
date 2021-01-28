using AutoMapper;
using todo_core_webapi.Entities;
using todo_core_webapi.Dtos;

namespace todo_core_webapi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoTable, TodoTableDto>().ReverseMap();

            CreateMap<UserInfoTable, UserInfoTableDto>().ReverseMap();
        }
    }
}