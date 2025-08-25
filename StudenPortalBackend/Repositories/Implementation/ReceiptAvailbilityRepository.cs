using Microsoft.EntityFrameworkCore;
using StudentPortalBackend.Data;
using StudentPortalBackend.Model.Domain;
using StudentPortalBackend.Repositories.Interface;

namespace StudentPortalBackend.Repositories.Implementation
{
    public class ReceiptAvailabilityRepository : IReceiptAvailabilityRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ReceiptAvailabilityRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ReceiptAvailability> CreateAsync(ReceiptAvailability receipt)
        {
            await dbContext.ReceiptAvailabilities.AddAsync(receipt);
            await dbContext.SaveChangesAsync();
            return receipt;
        }

        public async Task<ReceiptAvailability?> DeleteAsync(Guid studentId)
        {
            var existingReceipt = await dbContext.ReceiptAvailabilities
                .FirstOrDefaultAsync(x => x.StudentID == studentId);

            if (existingReceipt != null)
            {
                dbContext.ReceiptAvailabilities.Remove(existingReceipt);
                await dbContext.SaveChangesAsync();
                return existingReceipt;
            }

            return null;
        }

        public async Task<IEnumerable<ReceiptAvailability>> GetAllAsync()
        {
            return await dbContext.ReceiptAvailabilities.ToListAsync();
        }

        public async Task<ReceiptAvailability?> GetByIdAsync(Guid studentId)
        {
            return await dbContext.ReceiptAvailabilities
                .FirstOrDefaultAsync(x => x.StudentID == studentId);
        }

        public async Task<ReceiptAvailability?> UpdateAsync(ReceiptAvailability receipt)
        {
            var existingReceipt = await dbContext.ReceiptAvailabilities
                .FirstOrDefaultAsync(x => x.StudentID == receipt.StudentID);

            if (existingReceipt == null)
            {
                return null;
            }

            dbContext.Entry(existingReceipt).CurrentValues.SetValues(receipt);
            await dbContext.SaveChangesAsync();

            return receipt;
        }
    }
}

