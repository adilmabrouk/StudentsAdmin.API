using AutoMapper;
using StudentsAdmin.API.Models;
using StudentsAdmin.API.Profiles.AfterMapp;

namespace StudentsAdmin.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UpdateStudentRequest , Student>().AfterMap<UpdateStudentRequestAfterMap>();
        }
    }
}
