using System.ComponentModel.DataAnnotations;
using Core.Entities.Abstract;

namespace Entities.Concrete.School
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EMail { get; set; }
        public string? Password { get; set; }

        public ICollection<OperationClaim>? OperationClaims { get; set; }
        
    }
}
