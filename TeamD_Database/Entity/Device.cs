using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamD_Database.Entity
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "*入力必須項目です")]
        public required string AssetsNo { get; set; }

        [MaxLength(20)]
        public string? Maker { get; set; }

        [MaxLength(20)]
        public string? Os { get; set; }

        [MaxLength(20)]
        public string? Memory { get; set; }

        [MaxLength(20)]
        public string? Capacity { get; set; }

        public Boolean Graphics { get; set; }

        [MaxLength(20)]
        public string? Location { get; set; }

        public Boolean Break { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartleaseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LimitleaseDate { get; set; }

        [MaxLength(100)]
        public string? Remarks { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public required DateTime? RegisterDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdateDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InventoryDate { get; set; }

        public required Boolean DeleteFlag { get; set; }
    }
}
