using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chat.Models;

namespace Chat.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext (DbContextOptions<ChatContext> options)
            : base(options)
        {
        }

        public DbSet<Chat.Models.ChatData> ChatData { get; set; }
    }
}
