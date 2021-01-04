using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConfigurationManagement.Models;
using ConfigurationManagement.Helpers;

namespace ConfigurationManagement.Controllers
{
    public class MConfigurationManagementsController : Controller
    {
        private readonly CONFIG_DBContext _context;

        public MConfigurationManagementsController(CONFIG_DBContext context)
        {
            _context = context;
        }

        // GET: MConfigurationManagements
        public async Task<IActionResult> Index(string searchWord, string currentFilter, int? pageNumber)
        {
            ViewData["searchWord"] = searchWord;
            if (searchWord != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchWord = currentFilter;
            }
            ViewData["currentFilter"] = searchWord;
            var hosts = _context.MConfigurationManagements.Select(a => a);
            if (!string.IsNullOrEmpty(searchWord))
            {
                hosts = hosts.Where(a => a.Host.Contains(searchWord));
            }
            int pageSize = 10;
            return View(await PaginatedList<MConfigurationManagement>.CreateAsync(hosts.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await hosts.ToListAsync());
        }

        // GET: MConfigurationManagements/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mConfigurationManagement = await _context.MConfigurationManagements.Include(b => b.MAccounts).Include(b => b.MAccounts)
                .FirstOrDefaultAsync(m => m.ConfigurationManagementSeq == id);
            if (mConfigurationManagement == null)
            {
                return NotFound();
            }

            return View(mConfigurationManagement);
        }

        // GET: MConfigurationManagements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MConfigurationManagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfigurationManagementSeq,JissibiS,JissibiE,Host,HostDetail,UserName,Place,HostType,Os,Cpu,Memory,Share1,Share2,Share3,Share4,WebUrl,ParentHost,UpdateDt,UpdateId,UpdateTer,CreateDt,CreateId,CreateTer")] MConfigurationManagement mConfigurationManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mConfigurationManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mConfigurationManagement);
        }

        // GET: MConfigurationManagements/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mConfigurationManagement = await _context.MConfigurationManagements.FindAsync(id);
            if (mConfigurationManagement == null)
            {
                return NotFound();
            }
            return View(mConfigurationManagement);
        }

        // POST: MConfigurationManagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ConfigurationManagementSeq,JissibiS,JissibiE,Host,HostDetail,UserName,Place,HostType,Os,Cpu,Memory,Share1,Share2,Share3,Share4,WebUrl,ParentHost,UpdateDt,UpdateId,UpdateTer,CreateDt,CreateId,CreateTer")] MConfigurationManagement mConfigurationManagement)
        {
            if (id != mConfigurationManagement.ConfigurationManagementSeq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mConfigurationManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MConfigurationManagementExists(mConfigurationManagement.ConfigurationManagementSeq))
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
            return View(mConfigurationManagement);
        }

        // GET: MConfigurationManagements/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mConfigurationManagement = await _context.MConfigurationManagements
                .FirstOrDefaultAsync(m => m.ConfigurationManagementSeq == id);
            if (mConfigurationManagement == null)
            {
                return NotFound();
            }

            return View(mConfigurationManagement);
        }

        // POST: MConfigurationManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var mConfigurationManagement = await _context.MConfigurationManagements.FindAsync(id);
            _context.MConfigurationManagements.Remove(mConfigurationManagement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MConfigurationManagementExists(long id)
        {
            return _context.MConfigurationManagements.Any(e => e.ConfigurationManagementSeq == id);
        }
    }
}
