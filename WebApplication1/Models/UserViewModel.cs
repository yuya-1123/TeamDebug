using TeamD_Database.Entity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models;

public class UserViewModel
{
    public List<User>? UserList { get; set; } = new List<User>();
    //名前で検索するためのやつ
    public string? SearchString {  get; set; }
}
