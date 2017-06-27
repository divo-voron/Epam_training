using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.MVCClient.Models;
using Sales.MVCClient.Models.CreateEdit;

namespace Sales.MVCClient
{
    class MVCMapper
    {
        // To MVC types
        internal Operation Mapping(BL.DTO.OperationDto operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.DTO.OperationDto, Operation>()
                .ForMember(x => x.Client, o => o.Ignore())
                .ForMember(x => x.Manager, o => o.Ignore())
                .ForMember(x => x.PriceHistory, o => o.Ignore())
                .ForMember(x => x.Product, o => o.Ignore())
                .AfterMap((op1, op2) =>
                {
                    op2.Client = Mapping(op1.Client);
                    op2.Manager = Mapping(op1.Manager);
                    op2.PriceHistory = Mapping(op1.PriceHistory);
                    op2.Product = Mapping(op1.Product);
                }));
            return Mapper.Map<BL.DTO.OperationDto, Operation>(operation);
        }
        internal Client Mapping(BL.DTO.ClientDto client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.DTO.ClientDto, Client>());
            return Mapper.Map<BL.DTO.ClientDto, Client>(client);
        }
        internal Manager Mapping(BL.DTO.ManagerDto manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.DTO.ManagerDto, Manager>());
            return Mapper.Map<BL.DTO.ManagerDto, Manager>(manager);
        }
        internal PriceHistory Mapping(BL.DTO.PriceHistoryDto priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.DTO.PriceHistoryDto, PriceHistory>()
                .ForMember(x => x.Product, o => o.Ignore())
                .AfterMap((pH1, pH2) =>
                    {
                        pH2.Product = Mapping(pH1.Product);
                    }));
            return Mapper.Map<BL.DTO.PriceHistoryDto, PriceHistory>(priceHistory);
        }
        internal Product Mapping(BL.DTO.ProductDto product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.DTO.ProductDto, Product>());
            return Mapper.Map<BL.DTO.ProductDto, Product>(product);
        }
        
        // To BL types
        internal BL.DTO.OperationDto Mapping(Operation operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Operation, BL.DTO.OperationDto>()
                .ForMember(x => x.Client, o => o.Ignore())
                .ForMember(x => x.Manager, o => o.Ignore())
                .ForMember(x => x.PriceHistory, o => o.Ignore())
                .ForMember(x => x.Product, o => o.Ignore())
                .AfterMap((op1, op2) =>
                {
                    op2.Client = Mapping(op1.Client);
                    op2.Manager = Mapping(op1.Manager);
                    op2.PriceHistory = Mapping(op1.PriceHistory);
                    op2.Product = Mapping(op1.Product);
                }));
            return Mapper.Map<Operation, BL.DTO.OperationDto>(operation);
        }
        internal BL.DTO.ClientDto Mapping(Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, BL.DTO.ClientDto>());
            return Mapper.Map<Client, BL.DTO.ClientDto>(client);
        }
        internal BL.DTO.ManagerDto Mapping(Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Manager, BL.DTO.ManagerDto>());
            return Mapper.Map<Manager, BL.DTO.ManagerDto>(manager);
        }
        internal BL.DTO.PriceHistoryDto Mapping(PriceHistory priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PriceHistory, BL.DTO.PriceHistoryDto>()
                .ForMember(x => x.Product, o => o.Ignore())
                .AfterMap((pH1, pH2) =>
                    {
                        pH2.Product = Mapping(pH1.Product);
                    }));
            return Mapper.Map<PriceHistory, BL.DTO.PriceHistoryDto>(priceHistory);
        }
        internal BL.DTO.ProductDto Mapping(Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, BL.DTO.ProductDto>());
            return Mapper.Map<Product, BL.DTO.ProductDto>(product);
        }

        // To BLIdentity types
        internal BLIdentity.DTO.UserDto Mapping(User user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, BLIdentity.DTO.UserDto>());
            return Mapper.Map<User, BLIdentity.DTO.UserDto>(user);
        }
        internal BLIdentity.DTO.UserDto Mapping(UserCreate user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserCreate, BLIdentity.DTO.UserDto>());
            return Mapper.Map<UserCreate, BLIdentity.DTO.UserDto>(user);
        }

        // To MVC types
        internal User Mapping(BLIdentity.DTO.UserDto user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BLIdentity.DTO.UserDto, User>());
            return Mapper.Map<BLIdentity.DTO.UserDto, User>(user);
        }
    }
}
