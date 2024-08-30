using Cleo.Repos;
using Cleo.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatroomController(ChatroomRepository _chatroomRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Message>>> GetMessagesAsync()
            => Ok(await _chatroomRepository.GetMessagesAsync());
    }
}
