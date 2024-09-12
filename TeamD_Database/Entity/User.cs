using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamD_Database.Entity
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "*入力必須項目です")]
        public required string EmployeeNo {  get; set; }

        [Required(ErrorMessage = "*入力必須項目です")]
        [MaxLength(20)]
        public required string Name { get; set; } = string.Empty;

        [MaxLength(20)]
        public  string? Namekana { get; set; }

        [MaxLength(20)]
        public  string? department { get; set; }

        [MaxLength(20)]
        public  string? TelNo { get; set; }

        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "*メールアドレスの形式で入力してください")]
        public  string? MailAdress { get; set; }

        [Range(0,100, ErrorMessage = "*年齢は0～100歳まで入力可能です")]
        [Required(ErrorMessage = "*入力必須項目です")]
        public  required int Age { get; set; }

        [Required(ErrorMessage = "*入力必須項目です")]
        public required int Gender { get; set; }

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
