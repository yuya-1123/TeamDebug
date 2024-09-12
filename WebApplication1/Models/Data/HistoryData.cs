using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Data
{
    public class HistoryData
    {
        public int Id { get; set; }

        public string Assets_No { get; set; } = string.Empty;

        public string Employee_No { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime? LoanDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime? ReturnDate { get; set; }
    }
}
