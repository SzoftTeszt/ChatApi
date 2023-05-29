using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class ChatData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Room { get; set; }
        public string Message { get; set; }
    }
}
