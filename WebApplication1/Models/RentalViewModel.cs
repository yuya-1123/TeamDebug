using System.ComponentModel.DataAnnotations;
using TeamD_Database.Entity;

namespace WebApplication1.Models;

public class RentalViewModel
{
    public string AssetsNo { get; set; }

    [MaxLength(20)]
    public string? Maker { get; set; }

    [MaxLength(20)]
    public string? OS { get; set; }

    [MaxLength(20)]
    public string? Location { get; set; }

    public required Boolean Vacant { get; set; }

    [MaxLength(20)]
    public string? EmployeeNo { get; set; }

    [MaxLength(20)]
    public string? Name { get; set; }

    public DateTime? LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    [MaxLength(100)]
    public string? Remarks { get; set; }

    List<Rental>? RentalList { get; set; } = new List<Rental>();

    public string? SearchString { get; set; }
}
