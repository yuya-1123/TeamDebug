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
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication1.Controllers
{
    public class RentalsController : Controller
    {
        private readonly WebApplication1Context _context;

        public RentalsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Rentals
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            
            if (_context.Rental == null)
            {
                return Problem("Entity set 'WebApplication1Context.Rental'  is null.");
            }

            var rentals = await _context.Rental
                .SelectMany(
                    Rental => _context.Device
                    .Where(Device => Device.AssetsNo == Rental.AssetsNo
                    && !Device.DeleteFlag && !Device.Break),
                    (Rental, Device) => new { Rental, Device }
                )
                .SelectMany(
                    RentalWithDevice => _context.User
                    .Where(User => User.EmployeeNo == RentalWithDevice.Rental.EmployeeNo)
                    .DefaultIfEmpty(),
                    (RentalWithDevice, User) => new RentalViewModel
                    {
                        AssetsNo = RentalWithDevice.Rental.AssetsNo,
                        Maker = RentalWithDevice.Device != null ? RentalWithDevice.Device.Maker : "",
                        OS = RentalWithDevice.Device != null ? RentalWithDevice.Device.Os : "",
                        Location = RentalWithDevice.Device != null ? RentalWithDevice.Device.Location : "",
                        Vacant = RentalWithDevice.Rental.Vacant,
                        EmployeeNo = User != null ? User.EmployeeNo : "",
                        Name = User != null ? User.Name : "",
                        LoanDate = User != null ? RentalWithDevice.Rental.LoanDate : null,
                        ReturnDate = User != null ? RentalWithDevice.Rental.ReturnDate : null,
                        Remarks = RentalWithDevice.Rental.Remarks,
                        SearchString = searchString
                    }
                )
                .ToListAsync();


            string strSQL = "SELECT * FROM dbo.Rental";
            string strWhere = string.Empty;
            int cnt = 0;

            var param_word = new SqlParameter("@param_word", string.Empty);
            //-------------------------------資産番号、社員名で検索できるようにする------------------------//
            if (!string.IsNullOrEmpty(searchString))
            {
                //とりあえず名前を検索の対象にしてる　後で変える
                var rental = rentals.Where(r => r.Name!.ToUpper().Contains(searchString.ToUpper()));

            foreach(var i in rental)
            {
                if (i.ReturnDate < DateTime.Now)
                    cnt++;
            }
            ViewBag.Limit = cnt;
                return View( rental );
              //  param_word.Value = "%" + searchString + "%";
              //  strWhere = "( AssetsNo LIKE @param_word ) OR ( Name LIKE @param_word )";
            }
            else
            {
                ViewBag.reset = "disabled";
            }

            /* var RentalVM = new RentalViewModel
             {
                 RentalList = await rentals.ToListAsync()
             };*/

            //貸出期限の切れたリストをカウント
            
            foreach(var i in rentals)
            {
                if (i.ReturnDate < DateTime.Now)
                    cnt++;
            }
            ViewBag.Limit = cnt;

            return View(rentals);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .FirstOrDefaultAsync(m => m.AssetsNo == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetsNo,Maker,OS,Location,Vacant,EmployeeNo,Name,LoanDate,ReturnDate,Remarks")] TeamD_Database.Entity.Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rental);
        }

        // GET: Rentals/Edit/5
        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rental = _context.Rental.Find(id);

            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,AssetsNo,Maker,OS,Location,Vacant,EmployeeNo,Name,LoanDate,ReturnDate,Remarks")] Rental rental)
        {
            if (id != rental.AssetsNo)
            {
                return NotFound();
            }
            var userData = _context.User.Find(rental.EmployeeNo);
            if (userData == null)
                return RedirectToAction(nameof(Index));

            if (ModelState.IsValid)
            {
                try
                {
                    var Date = DateTime.Now;
                    rental.LoanDate = Date;
                    rental.ReturnDate = Date.AddMonths(1);
                    rental.Vacant = true;
                    rental.Name = userData.Name;
                    _context.Entry(rental).State = EntityState.Modified;
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.AssetsNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rental);
        }

        // GET: Rentals/Delete/5
        [HttpGet]
        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = _context.Rental.Find(id);
            if (rental == null)
            {
                return RedirectToAction(nameof(Index));
            }
                
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, [Bind("Id,AssetsNo,Maker,OS,Location,Vacant,EmployeeNo,Name,LoanDate,ReturnDate,Remarks")] Rental rental)
        {
            if (id != rental.AssetsNo)
            {
                return View(rental);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    //履歴追加----データリセットより前にやらないとだめ
                    RentalsHistory history = new RentalsHistory()
                    {
                        Assets_No = rental.AssetsNo,
                        Employee_No = rental.EmployeeNo == null ? "" : rental.EmployeeNo,
                        LoanDate = rental.LoanDate,
                        ReturnDate = DateTime.Now,
                    };

                    //データリセット
                    rental.LoanDate = null;
                    rental.ReturnDate = null;
                    rental.Vacant = false;
                    rental.EmployeeNo = null;
                    rental.Name = null;
                    

                 
                    _context.Add(history);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.AssetsNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _context.Entry(rental).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rental);
        }

        public async Task<IActionResult> RentalsHistory()
        {
            var history = _context.RentalsHistory;

            var historyVM = new HistoryViewModel
            {
                HistoryList = await history.ToListAsync()
            };

            return View(historyVM);
        }

        private bool RentalExists(string id)
        {
            return _context.Rental.Any(e => e.AssetsNo == id);
        }
    }
}
