using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Web_App.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        private const int PageSize = 10; // Размер страницы для пагинации

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string nameFilter, int page = 1)
        {
            // Фильтрация
            IQueryable<Contact> contactsQuery = _context.Contacts;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                contactsQuery = contactsQuery.Where(c => c.Name.Contains(nameFilter));
            }

            // Пагинация
            var count = await contactsQuery.CountAsync();
            var items = await contactsQuery.Skip((page - 1) * PageSize).Take(PageSize).ToListAsync();

            // Создание PageViewModel
            var pageViewModel = new PageViewModel(count, page, PageSize);

            // Создание FilterViewModel
            var filterViewModel = new FilterViewModel { SelectedName = nameFilter };

            // Формирование модели представления
            IndexViewModel viewModel = new IndexViewModel(items, pageViewModel, filterViewModel);

            return View(viewModel);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Phone,Address")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id.Value);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,Address")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Contact contact = await _context.Contacts.FindAsync(id.Value);
                if (contact != null)
                {
                    _context.Contacts.Remove(contact);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
