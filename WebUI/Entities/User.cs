using System.ComponentModel.DataAnnotations;

namespace WebUI.Entities
{
    public class User
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
