using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Entities.Concrete.School
{
    public class UserOperationClaim : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("OperationClaimId")]
        public int OperationClaimId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("OperationClaimId")]
        public OperationClaim? OperationClaim { get; set; }

        public DateTime? ProcessDate { get; set; }
    }
}
