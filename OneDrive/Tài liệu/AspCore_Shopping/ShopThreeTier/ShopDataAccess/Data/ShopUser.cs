﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShopDataAccess.Models
{
    public class ShopUser:IdentityUser
    {
        [MaxLength(100)]
        public string FullName { set; get; }

        [MaxLength(255)]
        public string Address { set; get; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }
    }
}
