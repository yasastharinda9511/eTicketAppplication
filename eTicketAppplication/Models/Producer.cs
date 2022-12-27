﻿using System.ComponentModel.DataAnnotations;

namespace eTicketAppplication.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePicturURL { get; set; }
        public string FullName { get; set; }

        public string Bio { get; set; }

    }
}
