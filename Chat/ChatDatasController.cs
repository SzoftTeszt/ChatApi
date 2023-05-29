using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chat.Data;
using Chat.Models;

namespace Chat
{
    public class ChatDatasController : Controller
    {
        private readonly ChatContext _context;

        public ChatDatasController(ChatContext context)
        {
            _context = context;
        }

        // GET: ChatDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChatData.ToListAsync());
        }

        // GET: ChatDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatData = await _context.ChatData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatData == null)
            {
                return NotFound();
            }

            return View(chatData);
        }

        // GET: ChatDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChatDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Room,Message")] ChatData chatData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatData);
        }

        // GET: ChatDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatData = await _context.ChatData.FindAsync(id);
            if (chatData == null)
            {
                return NotFound();
            }
            return View(chatData);
        }

        // POST: ChatDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Room,Message")] ChatData chatData)
        {
            if (id != chatData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatDataExists(chatData.Id))
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
            return View(chatData);
        }

        // GET: ChatDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatData = await _context.ChatData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatData == null)
            {
                return NotFound();
            }

            return View(chatData);
        }

        // POST: ChatDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chatData = await _context.ChatData.FindAsync(id);
            _context.ChatData.Remove(chatData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatDataExists(int id)
        {
            return _context.ChatData.Any(e => e.Id == id);
        }
    }
}
