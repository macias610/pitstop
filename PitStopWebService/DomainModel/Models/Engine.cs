using DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Engine : Entity<Guid>
    {
        public string Manufacturer { get; set; }
    }
}
