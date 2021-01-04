using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConfigurationManagement.Models;
using X.PagedList;
using System.Web;

namespace ConfigurationManagement.Controllers
{
    public class VConfigAccountsController : Controller
    {
        private readonly CONFIG_DBContext _context;

        public VConfigAccountsController(CONFIG_DBContext context)
        {
            _context = context;
        }

        // GET: VConfigAccounts
        public async Task<IActionResult> Index(string searchWord)
        {
            var hosts = _context.VConfigAccounts.Select(a => a);
            if (!string.IsNullOrEmpty(searchWord))
            {
                hosts = hosts.Where(a => a.Host.Contains(searchWord));
            }
            ViewData["searchWord"] = searchWord;
            return View(await hosts.ToListAsync());
        }

        // GET: VConfigAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vConfigAccount = await _context.VConfigAccounts
                .FirstOrDefaultAsync(m => m.ConfigurationManagementId == id);
            if (vConfigAccount == null)
            {
                return NotFound();
            }

            return View(vConfigAccount);
        }

        // GET: VConfigAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VConfigAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfigurationManagementId,JissibiS,JissibiE,Host,HostDetail,UserName,Place,HostType,Os,Cpu,Memory,Share1,Share2,Share3,Share4,WebUrl,ParentHost,UpdateDt,UpdateId,UpdateTer,CreateDt,CreateId,CreateTer,AccountType,AccountId,Pass,DatabaseName")] VConfigAccount vConfigAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vConfigAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vConfigAccount);
        }

        // GET: VConfigAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vConfigAccount = await _context.VConfigAccounts.FindAsync(id);
            if (vConfigAccount == null)
            {
                return NotFound();
            }
            return View(vConfigAccount);
        }

        // POST: VConfigAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfigurationManagementId,JissibiS,JissibiE,Host,HostDetail,UserName,Place,HostType,Os,Cpu,Memory,Share1,Share2,Share3,Share4,WebUrl,ParentHost,UpdateDt,UpdateId,UpdateTer,CreateDt,CreateId,CreateTer,AccountType,AccountId,Pass,DatabaseName")] VConfigAccount vConfigAccount)
        {
            if (id != vConfigAccount.ConfigurationManagementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vConfigAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VConfigAccountExists(vConfigAccount.ConfigurationManagementId))
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
            return View(vConfigAccount);
        }

        // GET: VConfigAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vConfigAccount = await _context.VConfigAccounts
                .FirstOrDefaultAsync(m => m.ConfigurationManagementId == id);
            if (vConfigAccount == null)
            {
                return NotFound();
            }

            return View(vConfigAccount);
        }

        // POST: VConfigAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vConfigAccount = await _context.VConfigAccounts.FindAsync(id);
            _context.VConfigAccounts.Remove(vConfigAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VConfigAccountExists(long id)
        {
            return _context.VConfigAccounts.Any(e => e.ConfigurationManagementId == id);
        }
    }
}
