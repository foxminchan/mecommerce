//using Ecommerce.Catalog.Domain.ProductAggregate;
//using Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

//namespace Ecommerce.Catalog.Features.Products.Get;

//internal sealed record GetProductQuery(Guid Id) : IQuery<Result<ProductDto>>;

//internal sealed class GetProductHandler(IRepository<Product> repository)
//    : IQueryHandler<GetProductQuery, Result<ProductDto>>
//{
//    public async Task<Result<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
//    {
//        var product = await repository.FirstOrDefaultAsync(new ProductFilterSpec(request.Id), cancellationToken);
//    }
//}
