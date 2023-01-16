using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly EtDbContext _context;

        public ExpensesController(EtDbContext context)
        {
            _context = context;
        }


        // GET: ExpensesController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expenses.ToListAsync());
        }

        // GET: ExpensesController/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var expense = await _context.Expenses.FirstOrDefaultAsync(m => m.ExpenseId == id);
        //    return View(expense);
        //}

        // GET: ExpensesController/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Expenses());
            else
                return View(_context.Expenses.Find(id));
        }

        // POST: ExpensesController/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrEdit([Bind("ExpenseId,Title,Description,Amount,Category,Date")] Expenses expense)
        {
            if(ModelState.IsValid)
            {
                if (expense.ExpenseId == 0)
                {
                    expense.Date = DateTime.Now;
                    _context.Add(expense);
                }
                else
                    _context.Update(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: ExpensesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ExpensesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // POST: ExpensesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
