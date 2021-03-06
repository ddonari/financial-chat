﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinancialChat.Domain.Models.DB
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public Guid ChatroomId { get; set; }

        public string Text { get; set; }

        public Guid SenderUserId { get; set; }

        public DateTime SendDate { get; set; }

        public DateTime? ReadDate { get; set; }

        public virtual ApplicationUser SenderUser { get; set; }

        public virtual Chatroom Chatroom { get; set; }

    }
}