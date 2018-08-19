using AutoMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel.AutoMapper;

namespace ViewModel.Account
{
    public class LoginViewModel : IViewModel<User,LoginViewModel>
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public LoginViewModel(User user)
        {
            MapFrom(user);
        }

        public LoginViewModel MapFrom(User sourceObject)
        {
            return Mapper.Map<User, LoginViewModel>(sourceObject);
        }

        public User MapTo()
        {
            return Mapper.Map<LoginViewModel, User>(this);
        }
    }
}
