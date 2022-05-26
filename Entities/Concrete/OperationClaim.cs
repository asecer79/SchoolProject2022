using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class OperationClaim
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
