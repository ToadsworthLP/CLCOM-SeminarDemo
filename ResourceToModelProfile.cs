using AutoMapper;
using CLCOM_SeminarRestApi.Models;
using CLCOM_SeminarRestApi.Resources;

namespace CLCOM_SeminarRestApi
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<AddStudentResource, Student>();
        }
    }
}
