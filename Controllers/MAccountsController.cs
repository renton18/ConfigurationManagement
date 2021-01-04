using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConfigurationManagement.Models;

namespace ConfigurationManagement.Controllers
{
    public class MAccountsController : Controller
    {
        private readonly CONFIG_DBContext _context;

        public MAccountsController(CONFIG_DBContext context)
        {
            _context = context;
        }

        // GET: MAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MAccounts.ToListAsync());
        }

        // GET: MAccounts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAccount = await _context.MAccounts
                .FirstOrDefaultAsync(m => m.AccountSeq == id);
            if (mAccount == null)
            {
                return NotFound();
            }

            return View(mAccount);
        }

        // GET: MAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountSeq,AccountType,Id,Pass,DatabaseName,UpdateDt,UpdateId,UpdateTer,CreateDt,CreateId,CreateTer,ConfigurationManagementSeq")] MAccount mAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mAccount);
        }

        // GET: MAccounts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAccount = await _context.MAccounts.FindAsync(id);
            if (mAccount == null)
            {
                return NotFound();
            }
            return View(mAccount);
        }

        // POST: MAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("AccountSeq,AccountType,Id,Pass,DatabaseName,UpdateDt,UpdateId,UpdateTer,CreateDt,CreateId,CreateTer,ConfigurationManagementSeq")] MAccount mAccount)
        {
            if (id != mAccount.AccountSeq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MAccountExists(mAccount.AccountSeq))
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
            return View(mAccount);
        }

        // GET: MAccounts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAccount = await _context.MAccounts
                .FirstOrDefaultAsync(m => m.AccountSeq == id);
            if (mAccount == null)
            {
                return NotFound();
            }

            return View(mAccount);
        }

        // POST: MAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var mAccount = await _context.MAccounts.FindAsync(id);
            _context.MAccounts.Remove(mAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MAccountExists(long id)
        {
            return _context.MAccounts.Any(e => e.AccountSeq == id);
        }
    }
}
