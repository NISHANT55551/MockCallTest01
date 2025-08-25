using Microsoft.AspNetCore.Mvc;
using StudentPortalBackend.Model.Domain;
using StudentPortalBackend.Model.Dto;
using StudentPortalBackend.Repositories.Interface;

namespace StudentPortalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptAvailabilityController : ControllerBase
    {
        private readonly IReceiptAvailabilityRepository receiptRepository;

        public ReceiptAvailabilityController(IReceiptAvailabilityRepository receiptRepository)
        {
            this.receiptRepository = receiptRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceipt([FromBody] ReceiptAvailabilityDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var receipt = new ReceiptAvailability
            {
                StudentID = request.StudentID,
                Name = request.Name,
                PaymentDate = request.PaymentDate
            };

            var createdReceipt = await receiptRepository.CreateAsync(receipt);

            return CreatedAtAction(nameof(GetReceiptByStudentId), new { studentId = createdReceipt.StudentID }, createdReceipt);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReceipts()
        {
            var receipts = await receiptRepository.GetAllAsync();
            return Ok(receipts);
        }

        [HttpGet("{studentId:guid}")]
        public async Task<IActionResult> GetReceiptByStudentId([FromRoute] Guid studentId)
        {
            var receipt = await receiptRepository.GetByIdAsync(studentId);

            if (receipt == null)
                return NotFound(new { message = "Receipt not found for the specified student ID." });

            return Ok(receipt);
        }

        [HttpPut("{studentId:guid}")]
        public async Task<IActionResult> UpdateReceipt([FromRoute] Guid studentId, [FromBody] ReceiptAvailabilityDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (studentId != request.StudentID)
                return BadRequest(new { message = "Student ID in route and body do not match." });

            var receipt = new ReceiptAvailability
            {
                StudentID = request.StudentID,
                Name = request.Name,
                PaymentDate = request.PaymentDate
            };

            var updatedReceipt = await receiptRepository.UpdateAsync(receipt);

            if (updatedReceipt == null)
                return NotFound(new { message = "Receipt not found for update." });

            return Ok(updatedReceipt);
        }

        [HttpDelete("{studentId:guid}")]
        public async Task<IActionResult> DeleteReceipt([FromRoute] Guid studentId)
        {
            var deletedReceipt = await receiptRepository.DeleteAsync(studentId);

            if (deletedReceipt == null)
                return NotFound(new { message = "Receipt not found for deletion." });

            return Ok(new { message = "Receipt deleted successfully." });
        }
    }
}
