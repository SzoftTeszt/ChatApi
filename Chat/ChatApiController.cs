using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chat.Data;
using Chat.Models;

namespace Chat
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatApiController : ControllerBase
    {
        private readonly ChatContext _context;

        public ChatApiController(ChatContext context)
        {
            _context = context;
        }

        // GET: api/ChatApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatData>>> GetChatData()
        {
            return await _context.ChatData.ToListAsync();
        }

        // GET: api/ChatApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatData>> GetChatData(int id)
        {
            var chatData = await _context.ChatData.FindAsync(id);

            if (chatData == null)
            {
                return NotFound();
            }

            return chatData;
        }

        // PUT: api/ChatApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatData(int id, ChatData chatData)
        {
            if (id != chatData.Id)
            {
                return BadRequest();
            }

            _context.Entry(chatData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ChatApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatData>> PostChatData(ChatData chatData)
        {
            _context.ChatData.Add(chatData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatData", new { id = chatData.Id }, chatData);
        }

        // DELETE: api/ChatApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatData(int id)
        {
            var chatData = await _context.ChatData.FindAsync(id);
            if (chatData == null)
            {
                return NotFound();
            }

            _context.ChatData.Remove(chatData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatDataExists(int id)
        {
            return _context.ChatData.Any(e => e.Id == id);
        }
    }
}
