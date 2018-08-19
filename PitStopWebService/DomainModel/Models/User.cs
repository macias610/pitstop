using DomainModel.Interfaces;
using DomainModel.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class User : IdentityUser, IEntity<string>
    {
        object IEntity.Id
        {
            get { return this.Id; }
            set { this.Id = (string)value;  }
        }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public byte[] Version { get; set; }

        public User()
        {
        }

    }
}
