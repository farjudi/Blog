using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Exceptions
{
    public class EntityNotFoundException<TEntity> : DomainException where TEntity : class
    {
        public object EntityId { get; }
        public string EntityName { get; }
        public EntityNotFoundException(object entityId) : base($"{typeof(TEntity).Name} با شناسه {entityId} یافت نشد", "ENTITY_NOT_FOUND")
        {
            EntityId = entityId;
            EntityName = typeof(TEntity).Name;
        }
    }
};