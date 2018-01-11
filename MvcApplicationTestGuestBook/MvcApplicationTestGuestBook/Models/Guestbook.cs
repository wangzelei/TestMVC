using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplicationTestGuestBook.Models
{
    public class Guestbook
    {
        public int Id { get; set; }

        [DisplayName("姓名")]
        [Required]
        public string Name { get; set; }

        [DisplayName("邮箱")]
        [Required]
        public string Email { get; set; }
        
        [DisplayName("描述")]
        [Required]
        public string Memo { get; set; }
    }
}