using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

namespace GameShop.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
