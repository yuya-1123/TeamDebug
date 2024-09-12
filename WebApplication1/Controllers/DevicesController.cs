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
    public class DevicesController : Controller
    {
        private readonly WebApplication1Context _context;

        public DevicesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index(string searchString,string sortfield)
        {
            if (_context.Device == null)
            {
                return Problem("Entity set 'WebApplication1Context.Device'  is null.");
            }
            //---------追加した分、おかしくなったら消す,ソーと機能---------------------//
            IQueryable<Device> selected;
            string strSQL = "SELECT * FROM dbo.Device";
            string strWhere = string.Empty;

            var param_word = new SqlParameter("@param_word", string.Empty);

            var devices = from m in _context.Device
                          where m.DeleteFlag != true
                          select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                //とりあえずメーカーを検索の対象にしてる　後で変える
                //devices = devices.Where(s => s.Maker!.ToUpper().Contains(searchString.ToUpper()));
                param_word.Value = "%" + searchString + "%";
                strWhere = "( AssetsNo LIKE @param_word ) OR ( Maker LIKE @param_word ) OR ( Os LIKE @param_word ) OR ( Memory LIKE @param_word ) OR ( Capacity LIKE @param_word )";
            }
            else 
            {
                ViewBag.reset = "disabled";
            }

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSQL = strSQL += Environment.NewLine + "WHERE " + strWhere;
            }

            selected = _context.Device.FromSqlRaw(strSQL, param_word);
            selected = selected.Where(m => m.DeleteFlag != true);

            bool desc = false;
            string sortfieldBody = string.Empty;
            if (!string.IsNullOrEmpty(sortfield))
            {
                string[] tokens = sortfield.Split(DeviceViewModel.DLM);
                if (tokens.Length > 1)
                {
                    var sortDirection = tokens[tokens.Length - 1];
                    if (sortDirection.Equals("DESC", StringComparison.CurrentCultureIgnoreCase))
                    {
                        desc = true;
                    }
                    for (int i = 0; i < tokens.Length - 1; i++)
                    {
                        sortfieldBody += tokens[i] + DeviceViewModel.DLM;
                    }
                    sortfieldBody = sortfieldBody.Substring(0, sortfieldBody.Length - 1);
                }
                else
                {
                    sortfieldBody = sortfield;
                }

                switch (sortfieldBody.ToLower())
                {
                    case "assetsno":
                        if (desc)
                        {
                            selected = selected.OrderByDescending(m => m.AssetsNo);
                        }
                        else
                        {
                            selected = selected.OrderBy(m => m.AssetsNo);
                        }
                        break;
                    case "maker":
                        if (desc)
                        {
                            selected = selected.OrderByDescending(m => m.Maker);
                        }
                        else
                        {
                            selected = selected.OrderBy(m => m.Maker);
                        }
                        break;

                    case "os":
                        if (desc)
                        {
                            selected = selected.OrderByDescending(m => m.Os);
                        }
                        else
                        {
                            selected = selected.OrderBy(m => m.Os);
                        }
                        break;

                    case "graphics":
                        if (desc)
                        {
                            selected = selected.OrderByDescending(m => m.Graphics);
                        }
                        else
                        {
                            selected = selected.OrderBy(m => m.Graphics);
                        }
                        break;

                    case "capacity":
                        if (desc)
                        {
                            selected = selected.OrderByDescending(m => m.Capacity);
                        }
                        else
                        {
                            selected = selected.OrderBy(m => m.Capacity);
                        }
                        break;
                }
            }
            else
            {
                if (desc)
                {
                    selected = selected.OrderByDescending(m => m.AssetsNo);
                }
                else
                {
                    selected = selected.OrderBy(m => m.AssetsNo);
                }
            }
            var deviceList = await selected.ToListAsync();
            //-------------------------------------------------------------//

            var DeviceVM = new DeviceViewModel
            {
                DeviceList= deviceList,
                SearchString= searchString,
                SortField = sortfield,
            };

            return View(DeviceVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .FirstOrDefaultAsync(m => m.AssetsNo == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetsNo,Maker,Os,Memory,Capacity,Graphics,Location,Break,StartleaseDate,LimitleaseDate,Remarks,RegisterDate,UpdateDate,InventoryDate,DeleteFlag")] Device device)
        {
            if (ModelState.IsValid)
            {
                var exist_AssetsNo = await _context.Device.FindAsync(device.AssetsNo);
                if (exist_AssetsNo == null)
                {
                    //Deviceに登録
                    device.RegisterDate = DateTime.Now;
                    _context.Device.Add(device);

                    //Rentalに登録
                    Rental devicedata = new Rental()
                    {
                        AssetsNo = device.AssetsNo,
                        Maker = device.Maker,
                        OS = device.Os,
                        Location = device.Location,
                        Vacant = false,
                    };
                    _context.Rental.Add(devicedata);

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(device);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AssetsNo,Maker,Os,Memory,Capacity,Graphics,Location,Break,StartleaseDate,LimitleaseDate,Remarks,RegisterDate,UpdateDate,InventoryDate,DeleteFlag")] Device device)
        {
            if (id != device.AssetsNo)
            {
                return NotFound();
            }
            
            var deviceInrental = _context.Rental.Find(id);
            if (deviceInrental == null)
            {
                return NotFound();
            }

            var deviceRegiDate = await _context.Device.AsNoTracking().FirstOrDefaultAsync(u => id == device.AssetsNo);
            if (ModelState.IsValid)
            {
                try
                {
                    //null参照かもって言われたからやっただけ
                    if (deviceRegiDate != null)
                    {
                        device.RegisterDate = deviceRegiDate.RegisterDate;
                    }
                    //更新日をNOWの時間入力
                    device.UpdateDate = DateTime.Now;
                    _context.Entry(device).State = EntityState.Modified;

                    //レンタルのデバイス情報も更新
                    deviceInrental.Maker = device.Maker;
                    deviceInrental.OS = device.Os;
                    deviceInrental.Location = device.Location;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.AssetsNo))
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
            return View(device);
        }

        // GET: Devices/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .FirstOrDefaultAsync(m => m.AssetsNo == id);
            if (device != null)
            {
                device.UpdateDate = DateTime.Now;
                device.DeleteFlag = true;
                _context.Entry(device).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
                    //View(device);
        }

        // POST: Devices/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var device = await _context.Device.FindAsync(id);
            if (device != null)
            {
                _context.Device.Remove(device);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool DeviceExists(string id)
        {
            return _context.Device.Any(e => e.AssetsNo == id);
        }
    }
}