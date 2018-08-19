using AutoMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel.AutoMapper;

namespace ViewModel.Account
{
    public class RegisterViewModel : IViewModel<User, RegisterViewModel>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Surname { get; set; }

        [DataType("DateTime")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        public RegisterViewModel MapFrom(User sourceObject)
        {
            return Mapper.Map<User, RegisterViewModel>(sourceObject);
        }

        public User MapTo()
        {
            User user = Mapper.Map<RegisterViewModel, User>(this);
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            return user;
        }
    }
}
