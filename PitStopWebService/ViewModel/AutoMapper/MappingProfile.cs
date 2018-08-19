using AutoMapper;
using DomainModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Account;

namespace ViewModel.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginViewModel, User>();
            CreateMap<RegisterViewModel, User>().ForMember(dst => dst.UserName, opt => opt.MapFrom(c => c.Email));
        }
    }
}
