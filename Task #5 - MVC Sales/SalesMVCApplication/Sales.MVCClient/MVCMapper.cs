using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.MVCClient.Models;

namespace Sales.MVCClient
{
    class MVCMapper
    {
        // To MVC types
        internal Operation Mapping(BL.Model.Operation operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.Model.Operation, Operation>()
                .ForMember(x => x.Client, o => o.Ignore())
                .ForMember(x => x.Manager, o => o.Ignore())
                .ForMember(x => x.PriceHistory, o => o.Ignore())
                .ForMember(x => x.Product, o => o.Ignore())
                .ForMember(x => x.Session, o => o.Ignore())
                .AfterMap((op1, op2) =>
                {
                    op2.Client = Mapping(op1.Client);
                    op2.Manager = Mapping(op1.Manager);
                    op2.PriceHistory = Mapping(op1.PriceHistory);
                    op2.Product = Mapping(op1.Product);
                    op2.Session = Mapping(op1.Session);
                }));
            return Mapper.Map<BL.Model.Operation, Operation>(operation);
        }
        internal Client Mapping(BL.Model.Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.Model.Client, Client>());
            return Mapper.Map<BL.Model.Client, Client>(client);
        }
        internal Manager Mapping(BL.Model.Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.Model.Manager, Manager>());
            return Mapper.Map<BL.Model.Manager, Manager>(manager);
        }
        internal PriceHistory Mapping(BL.Model.PriceHistory priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.Model.PriceHistory, PriceHistory>());
            return Mapper.Map<BL.Model.PriceHistory, PriceHistory>(priceHistory);
        }
        internal Product Mapping(BL.Model.Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.Model.Product, Product>());
            return Mapper.Map<BL.Model.Product, Product>(product);
        }
        internal Session Mapping(BL.Model.Session session)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BL.Model.Session, Session>());
            return Mapper.Map<BL.Model.Session, Session>(session);
        }
        
        // To BL types
        internal BL.Model.Operation Mapping(Operation operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Operation, BL.Model.Operation>()
                .ForMember(x => x.Client, o => o.Ignore())
                .ForMember(x => x.Manager, o => o.Ignore())
                .ForMember(x => x.PriceHistory, o => o.Ignore())
                .ForMember(x => x.Product, o => o.Ignore())
                .ForMember(x => x.Session, o => o.Ignore())
                .AfterMap((op1, op2) =>
                {
                    op2.Client = Mapping(op1.Client);
                    op2.Manager = Mapping(op1.Manager);
                    op2.PriceHistory = Mapping(op1.PriceHistory);
                    op2.Product = Mapping(op1.Product);
                    op2.Session = Mapping(op1.Session);
                }));
            return Mapper.Map<Operation, BL.Model.Operation>(operation);
        }
        internal BL.Model.Client Mapping(Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, BL.Model.Client>());
            return Mapper.Map<Client, BL.Model.Client>(client);
        }
        internal BL.Model.Manager Mapping(Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Manager, BL.Model.Manager>());
            return Mapper.Map<Manager, BL.Model.Manager>(manager);
        }
        internal BL.Model.PriceHistory Mapping(PriceHistory priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PriceHistory, BL.Model.PriceHistory>());
            return Mapper.Map<PriceHistory, BL.Model.PriceHistory>(priceHistory);
        }
        internal BL.Model.Product Mapping(Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, BL.Model.Product>());
            return Mapper.Map<Product, BL.Model.Product>(product);
        }
        internal BL.Model.Session Mapping(Session session)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Session, BL.Model.Session>());
            return Mapper.Map<Session, BL.Model.Session>(session);
        }

        // To BLIdentity types
        internal BLIdentity.DTO.UserDTO Mapping(User user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, BLIdentity.DTO.UserDTO>());
            return Mapper.Map<User, BLIdentity.DTO.UserDTO>(user);
        }

        // To MVC types
        internal User Mapping(BLIdentity.DTO.UserDTO user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BLIdentity.DTO.UserDTO, User>());
            return Mapper.Map<BLIdentity.DTO.UserDTO, User>(user);
        }
    }
}
