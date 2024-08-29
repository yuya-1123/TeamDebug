using Microsoft.AspNetCore.Mvc;
using TeamD_Database;
using TeamD_Database.Entity;
using WebApplication1.Models;
using WebApplication1.Models.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace WebApplication1.Controllers
{
    public class DeviceController : Controller
    {

        private readonly WebApplication1Context _context;

        public DeviceController(WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var deviceList = _context.Device.ToList();

            var viewModel = new DeviceViewModel()
            {
                DeviceList = deviceList
            };
            viewModel.DeviceList = deviceList;
            return View(viewModel);
        }

        /* public IActionResult Create(DeviceViewModel viewModel)
         {
             var addDevice = new Device()
             {
                 AssetsNo = 18762113,
                 Maker = "Dell",
                 Os = "Windows",
                 Memory = "500GB",
                 Capacity = "1TB",
                 Graphics = false,
                 Location = "会社",
                 Break = false,
                 StartleaseDate = DateTime.Now,
                 LimitleaseDate = DateTime.Now,
                 Remarks = "",
                 RegisterDate = DateTime.Now,
                 UpdateDate = DateTime.Now,
                 InventoryDate = DateTime.Now,
                 DeleteFlag = false
             };

             _context.Add(addDevice);
             // DBに反映
             _context.SaveChanges();

             return RedirectToAction(nameof(Index));
         }
        */

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("EmployeeNo,Name,Namekana,department,TelNo,MailAdress,Age,Gender,Position,AccountLevel,RetireDate,RegisterDate,UpdateDate,DeleteFlag")] Device device)
        {
            if (ModelState.IsValid)
            {
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        public IActionResult Detail(int Num)
        {
            var entities = _context.Device;

            var device = entities.OrderByDescending(g => g.AssetsNo == null)
                .FirstOrDefault();
            var viewModel = new DeviceViewModel()
            {
                DeviceList = device != null ? new List<Device> { device } : new List<Device>()
            };

            return View(viewModel);
        }

        public IActionResult Delete(int Num)
        {
            //g.AssetsNoに値の受け渡しができてない（削除機能）
            var entities = _context.Device;

            var deleteDevice = entities.Where(g => g.AssetsNo == "18762111")
                             .FirstOrDefault();
            if (deleteDevice == null) return RedirectToAction(nameof(Index));

            _context.Remove(deleteDevice);
                         // DBに反映
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
                     
        }
    }
}
