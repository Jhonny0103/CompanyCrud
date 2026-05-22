using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyCrud.Models
{
    [Table("Dept")]
    public class Dept
    {
        [Key]
        [Column("DeptId")]
        public int DeptId { get; set; }
        [Column("DeptName")]
        public string? DeptName { get; set; }
    }
}
