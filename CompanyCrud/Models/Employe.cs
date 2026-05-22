using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyCrud.Models
{
    [Table("Employees")]
    public class Employe
    {
        [Key]
        [Column("EmployeId")]
        public int EmployeId { get; set; }
        [Column("EmployeName")]
        public string? EmployeName { get; set; }
        [Column("LastName")]
        public string? LastName { get; set; }
        [Column("Email")]
        public string? Email { get; set; }
        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }
        [Column("DeptId")]
        public int DeptId { get; set; }
        [Column("UpdateDate")]
        public DateTime UpdateDate { get; set; } 
        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}
