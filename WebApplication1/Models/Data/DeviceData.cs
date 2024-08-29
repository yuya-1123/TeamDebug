using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Data
{
    public class DeviceData
    {
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

        public DateTime StartleaseDate { get; set; }

        public DateTime LimitleaseDate { get; set; }

        [MaxLength(100)]
        public string? Remarks { get; set; }

        public required DateTime RegisterDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime InventoryDate { get; set; }

        public required Boolean DeleteFlag { get; set; }
    }
}
