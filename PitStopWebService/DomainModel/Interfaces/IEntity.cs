using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces
{
    public interface IEntity : IModifableEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        byte[] Version { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
