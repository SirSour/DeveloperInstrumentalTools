using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("User")]
    public class UserEntity
    {
        public int Id { get; set; }
        
        public RoleEntity Role { get; set; }
        
        public string UserName { get; set; }
    }
}