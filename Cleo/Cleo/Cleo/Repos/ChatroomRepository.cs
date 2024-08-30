using Cleo.Data;
using Cleo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Cleo.Repos
{
    public class ChatroomRepository(AppDbContext appDbContext)
    {
        public async Task SaveMessagesAsync(Message message)
        {
            appDbContext.Messages.Add(message);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<Message>> GetMessagesAsync() => 
            await appDbContext.Messages.ToListAsync();
        
    }
}
