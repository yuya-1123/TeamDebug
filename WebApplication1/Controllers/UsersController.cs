using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamD_Database;
using TeamD_Database.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        private readonly WebApplication1Context _context;

        public UsersController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'WebApplication1Context.User'  is null.");
            }

            var users = from m in _context.User
                        where m.DeleteFlag != true
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Name!.ToUpper().Contains(searchString.ToUpper()));
            }
            else
            {
                ViewBag.reset = "disabled";
            }

                var userVM = new UserViewModel
            {
                UserList = await users.ToListAsync()
            };

            return View(userVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.EmployeeNo == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeNo,Name,Namekana,department,TelNo,MailAdress,Age,Gender,Position,AccountLevel,RetireDate,RegisterDate,UpdateDate,DeleteFlag")] User user)
        {
            if (ModelState.IsValid)
            {
                var exist_EmployeeNo = await _context.Device.FindAsync(user.EmployeeNo);
                if (exist_EmployeeNo == null)
                {
                    //Userに登録
                    user.RegisterDate = DateTime.Now;
                    _context.User.Add(user);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeNo,Name,Namekana,department,TelNo,MailAdress,Age,Gender,Position,AccountLevel,RetireDate,RegisterDate,UpdateDate,DeleteFlag")] User user)
        {
            if (id != user.EmployeeNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var userRegiDate = await _context.User.AsNoTracking().FirstOrDefaultAsync(u => id == user.EmployeeNo);
                try
                {
                    //null参照かもって言われたからやっただけ
                    if(userRegiDate != null)
                    {
                        user.RegisterDate = userRegiDate.RegisterDate;
                    }
                    //更新日をNOWの時間入力
                    user.UpdateDate = DateTime.Now;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.EmployeeNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
              .FirstOrDefaultAsync(m => m.EmployeeNo == id);
            if (user != null)
            {
                user.UpdateDate = DateTime.Now;
                user.DeleteFlag = true;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Users/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.EmployeeNo == id);
        }
    }
}
