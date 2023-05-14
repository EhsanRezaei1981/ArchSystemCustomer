namespace ArchSystem.Service.Customer
{
    public interface ICustomerService
    {
        Task<ArchSystem.Dto.Models.Customer.Create.OutputDto> Create(ArchSystem.Dto.Models.Customer.Create.InputDto iModel);
        Task<ArchSystem.Dto.Models.Customer.Update.OutputDto> Update(ArchSystem.Dto.Models.Customer.Update.InputDto iModel);
        Task<ArchSystem.Dto.Models.Customer.Delete.OutputDto> Delete(ArchSystem.Dto.Models.Customer.Delete.InputDto iModel);
        Task<ArchSystem.Dto.Models.Customer.Retrieve.OutputDto> Retrieve(ArchSystem.Dto.Models.Customer.Retrieve.InputDto iModel);
        Task<ArchSystem.Dto.Models.Customer.Retrieve.ExportToXml.OutputDto> ExportToXml();
    }
}
