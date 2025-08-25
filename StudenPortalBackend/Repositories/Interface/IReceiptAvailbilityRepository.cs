using StudentPortalBackend.Model.Domain;

namespace StudentPortalBackend.Repositories.Interface
{
    public interface IReceiptAvailabilityRepository
    {
        Task<ReceiptAvailability> CreateAsync(ReceiptAvailability receipt);
        Task<ReceiptAvailability?> DeleteAsync(Guid studentId);
        Task<IEnumerable<ReceiptAvailability>> GetAllAsync();
        Task<ReceiptAvailability?> GetByIdAsync(Guid studentId);
        Task<ReceiptAvailability?> UpdateAsync(ReceiptAvailability receipt);
    }
}
