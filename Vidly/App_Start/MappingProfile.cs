using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //From Domain Class to DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<GenreType, GenreTypeDTO>();


            //From DTO to domain class
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDTO>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<GenreType, GenreType>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}