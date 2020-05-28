using System;
using Domain.Interfaces;

namespace Domain.Entities.Base
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
