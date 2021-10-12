using AutoMapper;
using StudentsAdmin.API.Models;

namespace StudentsAdmin.API.Profiles.AfterMapp
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, Student>
    {
        void IMappingAction<UpdateStudentRequest, Student>.Process(UpdateStudentRequest source, Student destination, ResolutionContext context)
        {
            destination.Address = new Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
