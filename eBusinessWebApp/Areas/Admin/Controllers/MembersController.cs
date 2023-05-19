using eBusinessWebApp.DAL;
using eBusinessWebApp.Models;
using eBusinessWebApp.ViewModels.TeamVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBusinessWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MembersController : Controller
    {
        private readonly eBusinessDbContext _dbContext;

        public MembersController(eBusinessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Members.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberVM memberVM)
        {
            if (memberVM == null)
            {
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View(memberVM);
            }
            await _dbContext.Members.AddAsync(new Member()
            {
                Name = memberVM.Name,
                Surname = memberVM.Surname,
                Position = memberVM.Position
            });
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            Member? member = await _dbContext.Members.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (member==null)
            {
                return NotFound();
            }
            return View(member);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Member? member = await _dbContext.Members.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (member == null)
            {
                return NotFound();
            }
            _dbContext.Members.Remove(member);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Member? member = await _dbContext.Members.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, Member updatedMember)
        {
            Member? member = await _dbContext.Members.AsNoTracking().FirstOrDefaultAsync(m=>m.Id==id);
            if(updatedMember == null){
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View(updatedMember);
            }
            updatedMember.Id=member.Id;
            _dbContext.Members.Update(member);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
