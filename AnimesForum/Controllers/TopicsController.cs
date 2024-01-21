using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimesForum.Data;
using AnimesForum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AnimesForum.ViewModels;

namespace AnimesForum.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TopicsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Topics
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            var totalTopics = await _context.Topics.CountAsync();

            var topicsWithUsers = await _context.Topics
                .OrderBy(t => t.CreationDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(topic => new TopicViewModel
                {
                    TopicId = topic.TopicId,
                    Title = topic.Title,
                    Description = topic.Description,
                    CreationDate = topic.CreationDate,
                    UserName = _context.Users.FirstOrDefault(user => user.Id == topic.UserId).UserName
                })
                .ToListAsync();

            ViewBag.TotalPages = (int)Math.Ceiling(totalTopics / (double)pageSize);
            ViewBag.CurrentPage = page;

            return View(topicsWithUsers);
        }


        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (topic == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(topic.UserId);
            if (user != null)
            {
                ViewBag.UserEmail = user.Email;
            }

            return View(topic);
        }

        // GET: Topics/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TopicId,Title,Description")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                topic.UserId = user.Id;
                topic.CreationDate = DateTime.Now;

                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topics/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            if (topic.UserId != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            return View(topic);
        }

        // POST: Topics/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TopicId,Title,Description,UserId")] Topic topic)
        {
            if (id != topic.TopicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (topic.UserId != _userManager.GetUserId(User))
                    {
                        return Forbid();
                    }

                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.TopicId))
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
            return View(topic);
        }

        // GET: Topics/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (topic == null)
            {
                return NotFound();
            }

            if (topic.UserId != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic.UserId != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.TopicId == id);
        }
    }
}
