using TeamD_Database.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class HistoryViewModel
{
    public List<RentalsHistory>? HistoryList { get; set; } = new List<RentalsHistory>();
}
