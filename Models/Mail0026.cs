using System.ComponentModel.DataAnnotations;

namespace MailManagementAPI0026.Models
{
    public class Mail0026
    {
        [Key]  // Add this attribute
        public int MailId { get; set; }

        [Required]
        public string Subject { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        [Required]
        public int SenderDepartmentId { get; set; }

        [Required]
        public int RecipientDepartmentId { get; set; }

        public MailStatus0026 DeliveryStatus { get; set; } = MailStatus0026.InTransit;

        // Navigation properties
        public Department0026? SenderDepartment { get; set; }
        public Department0026? RecipientDepartment { get; set; }
    }
}
