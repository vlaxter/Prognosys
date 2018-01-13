using System;

namespace Prognosys.Repository.Sql.Entities
{
    class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
