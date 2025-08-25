using System.ComponentModel.DataAnnotations;

namespace MailManagementAPI0026.Models
{
    public class Department0026
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
    }
}
