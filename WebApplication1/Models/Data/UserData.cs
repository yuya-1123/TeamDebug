using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Data
{
    public class UserData
    {
        public required string EmployeeNo { get; set; }

        [MaxLength(20)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public string? Namekana { get; set; }

        [MaxLength(20)]
        public string? department { get; set; }

        [MaxLength(20)]
        public string? TelNo { get; set; }

        [MaxLength(20)]
        public string? MailAdress { get; set; }

        public int Age { get; set; }

        public int Gender { get; set; }

        [MaxLength(20)]
        public string? Position { get; set; }

        [MaxLength(20)]
        public string? AccountLevel { get; set; }

        public DateTime? RetireDate { get; set; }

        public required DateTime? RegisterDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public required Boolean DeleteFlag { get; set; }
    }
}
