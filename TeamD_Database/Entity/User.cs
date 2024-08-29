using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamD_Database.Entity
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required string EmployeeNo {  get; set; } 

        [MaxLength(20)]
        public required string Name { get; set; } = string.Empty;

        [MaxLength(20)]
        public  string? Namekana { get; set; }

        [MaxLength(20)]
        public  string? department { get; set; }

        [MaxLength(20)]
        public  string? TelNo { get; set; }

        [MaxLength(20)]
        public  string? MailAdress { get; set; }

        public  int Age { get; set; }

        public  int Gender { get; set; }

        [MaxLength(20)]
        public  string? Position { get; set; }

        [MaxLength(20)]
        public  string? AccountLevel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public  DateTime? RetireDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public required DateTime? RegisterDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public  DateTime? UpdateDate { get; set; }

        public required Boolean DeleteFlag { get; set; }

    }
}
