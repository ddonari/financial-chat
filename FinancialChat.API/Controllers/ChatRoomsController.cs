﻿using AutoMapper;
using FinancialChat.Domain.Models.API.Chatroom;
using FinancialChat.Domain.Models.DB;
using FinancialChat.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatroomsController : ControllerBase
    {
        private readonly IMapper _mapper;
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly IDatabaseProvider _databaseProvider;

        public ChatroomsController(UserManager<ApplicationUser> userManager, IDatabaseProvider databaseProvider, IMapper mapper)
        {
            _mapper = mapper;
            _databaseProvider = databaseProvider;
            _userManager = userManager;
        }

        // GET api/chatroom
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var chatrooms = await _databaseProvider.GetChatrooms();

            return Ok(_mapper.Map<IEnumerable<ChatroomModel>>(chatrooms));
        }

        // POST api/chatroom
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ChatroomModel model)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            var chatroom = await _databaseProvider.CreateChatroom(user.Id, model.Name);

            return Ok(chatroom);
        }

        // POST api/chatroom
        [HttpPost]
        [Route("join")]
        public async Task<IActionResult> Join([FromBody] ChatroomModel chatroom)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);


            var result = await _databaseProvider.Join(user, chatroom.Id);

            return Ok(result);
        }

        // GET api/chatroom
        [HttpGet]
        [Route("{id}/messages")]
        public async Task<IActionResult> Get(Guid id)
        {
            var messages = await _databaseProvider.GetMessages(id);

            return Ok(messages);
        }

    }
}
