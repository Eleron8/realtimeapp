using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RealTimeApp.Models
{
    public class User : IdentityUser 
    {
        public ICollection<ChatUser> Chats { get; set; }
    }
}