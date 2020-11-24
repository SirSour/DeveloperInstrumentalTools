using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("Role")]
    public class RoleEntity
    {
        public int Id { get; set; }
        
        public string RoleName { get; set; }
        

    }
}