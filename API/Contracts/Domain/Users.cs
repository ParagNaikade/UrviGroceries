using System.ComponentModel.DataAnnotations;

namespace Contracts.Domain
{
    public partial class Users
    {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
