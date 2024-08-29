using TeamD_Database;
using TeamD_Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using WebApplication1.Models;


namespace WebApplication1.Models
{
    public class UserSeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(
                serviceProvider.GetRequiredService<DbContextOptions<WebApplication1Context>>()))
            {
                // Look for any movies.
                if (context.User.Any())
                {
                    return; // DB has been seeded
                }

                /*var devices = context.Device;

                foreach (Device d in devices)
                {
                    context.Rental.AddRange(
                        new Rental 
                        { 
                            AssetsNo = d.AssetsNo,
                            Vacant = false,
                        }
                        );
                }
                context.SaveChanges();*/

                context.User.AddRange(
                    new User
                    {
                        EmployeeNo = "1000110645",
                        Name = "高橋裕子",
                        Namekana = "タカハシユウコ",
                        MailAdress = "yukorin@gmail.com",
                        Age = 52,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "1000180111",
                        Name = "金子裕子",
                        Namekana = "カネコユウコ",
                        MailAdress = "yukorin@gmail.com",
                        Age = 45,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "1000120205",
                        Name = "加藤ひさえ",
                        Namekana = "カトウヒサエ",
                        MailAdress = "hisane@gmail.com",
                        Age = 51,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    }



                    // こんな感じで投入データを書き加えていく。
                );
                context.SaveChanges();
            }
        }
    }
}

