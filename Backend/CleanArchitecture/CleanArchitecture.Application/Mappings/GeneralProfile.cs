using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.FoodImageFiles.Commands.UploadFoodImage;
using CleanArchitecture.Core.Features.Foods.Commands.CreateFood;
using CleanArchitecture.Core.Features.Foods.Queries.GetAllFoods;
using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;
using CleanArchitecture.Core.Features.Table.Commands.CreateTable;
using CleanArchitecture.Core.Features.Table.Queries.GetAllTables;
using CleanArchitecture.Core.Features.Waiters.Commands.CreateWaiter;

namespace CleanArchitecture.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            
            CreateMap<Table, GetAllTablesViewModel>().ReverseMap();
            CreateMap<CreateTableCommand, Table>();
            CreateMap<GetAllTablesQuery, GetAllTablesParameter>();

            CreateMap<CreateFoodCommand, Food>();

            CreateMap<UploadFoodImageCommand, FoodImageFile>();

            CreateMap<CreateWaiterCommand, Waiter>();

            //CreateMap<OrderItem, AddItemToBasketCommandResponse>().ReverseMap();
            //CreateMap<OrderItem, UpdateOrderItemQuantityViewModel>();
            //CreateMap<GetOrderItemsQuery, GetOrderItemsQueryResponse>();
        }
    }
}
