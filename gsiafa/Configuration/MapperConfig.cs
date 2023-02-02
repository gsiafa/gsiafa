

using AutoMapper;
using gsiafa.Models;

namespace gsiafa.Configuration
{
    public class MapperConfig : Profile 
    {
        public MapperConfig()
        {
            CreateMap<Contact, ContactViewModel>().ReverseMap();

        }
    }
}
