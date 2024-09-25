namespace Ecommerce.SharedKernel.Model;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }

    void Delete();
}
