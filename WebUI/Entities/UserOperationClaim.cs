using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Entities
{
    public class UserOperationClaim
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
    }
}
