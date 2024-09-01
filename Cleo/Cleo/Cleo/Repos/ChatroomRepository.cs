using Cleo.Data;
using Cleo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Cleo.Repos
{
    public class ChatroomRepository(AppDbContext appDbContext)
    {
        public async Task SaveMessagesAsync(Message message)
        {
            var existingMessage = await appDbContext.Messages
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == message.Id);

            if (existingMessage != null)
            {
                // Generate a new Id for the message if it already exists
                message.Id = Guid.NewGuid();
            }

            // Add the new message to the context
            appDbContext.Messages.Add(message);

            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<Message>> GetMessagesAsync() => 
            await appDbContext.Messages
            .ToListAsync();
       
    }
}
