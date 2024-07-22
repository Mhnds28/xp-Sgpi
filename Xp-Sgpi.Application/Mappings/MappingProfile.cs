using AutoMapper;
using Xp_Sgpi.Application.DTOs.Account;
using Xp_Sgpi.Application.DTOs.Asset;
using Xp_Sgpi.Application.DTOs.Customer;
using Xp_Sgpi.Application.DTOs.Order;
using Xp_Sgpi.Application.DTOs.Transaction;
using Xp_Sgpi.Application.DTOs.Wallet;
using Xp_Sgpi.Domain.Entities;

namespace Xp_Sgpi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();

            CreateMap<Asset, AssetDto>().ReverseMap();
            CreateMap<Asset, CreateAssetDto>().ReverseMap();
            CreateMap<AssetDto, CreateAssetDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<OrderDto, CreateOrderDto>().ReverseMap();

            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<Transaction, CreateTransactionDto>().ReverseMap();
            CreateMap<TransactionDto, CreateTransactionDto>().ReverseMap();

            CreateMap<Wallet, WalletDto>().ReverseMap();
            CreateMap<Wallet, CreateWalletDto>().ReverseMap();
            CreateMap<WalletDto, CreateWalletDto>().ReverseMap();
        }
    }
}
