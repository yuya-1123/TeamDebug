using Microsoft.AspNetCore.Mvc;
using TeamD_Database;
using TeamD_Database.Entity;
using WebApplication1.Models;
using WebApplication1.Models.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly WebApplication1Context _context;
        private readonly string _viewModelKey = "ViewModel";

        public UserController(WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userList = _context.User.ToList();

            var viewModel = new UserViewModel()
            {
                UserList = userList
            };
            viewModel.UserList = userList;
            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("EmployeeNo,Name,Namekana,department,TelNo,MailAdress,Age,Gender,Position,AccountLevel,RetireDate,RegisterDate,UpdateDate,DeleteFlag")] UserData user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

       /* public IActionResult Create(UserViewModel viewModel)
        {
            var addUser = new User()
            {
                EmployeeNo = 1000240223,
                Name = "小島孝",
                Namekana = "こじまたかし",
                department = "課長",
                TelNo = "08081231432",
                MailAdress = "tantakatan",
                Age = 44,
                Gender = 1,
                Position = "東京",
                AccountLevel = "nomal",
                RetireDate = DateTime.Now,
                RegisterDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                DeleteFlag = false
            };
            
            _context.Add(addUser);
                         // DBに反映
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }*/


        /*public IActionResult Add(UserViewModel viewModel)
        {
            var NoList = viewModel.UserList.Select(g => g.EmployeeNo);
            var userDataList = _context.User.Where(g => NoList.Contains(g.EmployeeNo)).ToList();

            foreach (var newData in viewModel.UserList)
            {
                // DBに同じIDのデータが存在するか確認
                var entity = userDataList.Where(g => g.EmployeeNo == newData.EmployeeNo).FirstOrDefault();
                if (entity != null)
                {
                    // データが存在する場合は更新
                    _context.Entry(entity).CurrentValues.SetValues(newData);
                }
                else
                {
                    // データが存在しない場合は新規追加
                    var addUser = new UserData()
                    {
                        EmployeeNo = newData.EmployeeNo,
                        Name = newData.Name,
                        Namekana = newData.Namekana,
                        department = newData.department,
                        RegisterDate = newData.RegisterDate,
                        DeleteFlag = newData.DeleteFlag
                    };
                    _context.User.Add(addUser);
                }
            }

            // DBに反映
            _context.SaveChanges();

            // Indexへリダイレクト
            TempData[_viewModelKey] = JsonSerializer.Serialize(viewModel);
            return View(viewModel);
        }*/

        public IActionResult Detail(string Num)
        {
            var entities = _context.User;

            var user = entities.OrderByDescending(g => g.EmployeeNo == Num)
                .FirstOrDefault();
            var viewModel = new UserViewModel()
            {
                UserList = user != null ? new List<User> { user } : new List<User>()
            };

            return View(viewModel);
        }

        public IActionResult Delete(string Num)
        {
            //g.EmployeeNoに値の受け渡しができてない（削除機能）
            var entities = _context.User;

            var deleteUser = entities.Where(g => g.EmployeeNo == "1000240223")
                             .FirstOrDefault();
            if (deleteUser == null) return RedirectToAction(nameof(Index));

            _context.Remove(deleteUser);
            // DBに反映
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        private bool MovieExists(string id)
        {
            return _context.User.Any(e => e.EmployeeNo == id);
        }
    }
}
