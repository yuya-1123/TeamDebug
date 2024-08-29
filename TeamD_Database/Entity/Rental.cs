using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamD_Database.Entity
{
    public class Rental
    {
        public string AssetsNo { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Maker {  get; set; }

        [MaxLength(20)]
        public string? OS {  get; set; }

        [MaxLength(20)]
        public string? Location { get; set; }

        public required Boolean Vacant {  get; set; }

        [MaxLength(20)]
        public string? EmployeeNo { get; set; }

        [MaxLength(20)]
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LoanDate {  get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnDate { get; set; }

        [MaxLength(100)]
        public string? Remarks { get; set; }

    }
}
