using AutoMapper;
using Sales.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL
{
    class BLMapper
    {
        // To BL Types
        internal Operation Mapping(Sales.Model.Models.Operation operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Operation, Operation>()
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
            return Mapper.Map<Sales.Model.Models.Operation, Operation>(operation);
        }
        internal Client Mapping(Sales.Model.Models.Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Client, Client>());
            return Mapper.Map<Sales.Model.Models.Client, Client>(client);
        }
        internal Manager Mapping(Sales.Model.Models.Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Manager, Manager>());
            return Mapper.Map<Sales.Model.Models.Manager, Manager>(manager);
        }
        internal PriceHistory Mapping(Sales.Model.Models.PriceHistory priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.PriceHistory, PriceHistory>());
            return Mapper.Map<Sales.Model.Models.PriceHistory, PriceHistory>(priceHistory);
        }
        internal Product Mapping(Sales.Model.Models.Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Product, Product>());
            return Mapper.Map<Sales.Model.Models.Product, Product>(product);
        }
        internal Session Mapping(Sales.Model.Models.Session session)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Session, Session>());
            return Mapper.Map<Sales.Model.Models.Session, Session>(session);
        }


        // To Model Types
        internal Sales.Model.Models.Operation Mapping(Operation operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Operation, Sales.Model.Models.Operation>()
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
            return Mapper.Map<Operation, Sales.Model.Models.Operation>(operation);
        }
        internal Sales.Model.Models.Client Mapping(Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, Sales.Model.Models.Client>());
            return Mapper.Map<Client, Sales.Model.Models.Client>(client);
        }
        internal Sales.Model.Models.Manager Mapping(Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Manager, Sales.Model.Models.Manager>());
            return Mapper.Map<Manager, Sales.Model.Models.Manager>(manager);
        }
        internal Sales.Model.Models.PriceHistory Mapping(PriceHistory priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PriceHistory, Sales.Model.Models.PriceHistory>());
            return Mapper.Map<PriceHistory, Sales.Model.Models.PriceHistory>(priceHistory);
        }
        internal Sales.Model.Models.Product Mapping(Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, Sales.Model.Models.Product>());
            return Mapper.Map<Product, Sales.Model.Models.Product>(product);
        }
        internal Sales.Model.Models.Session Mapping(Session session)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Session, Sales.Model.Models.Session>());
            return Mapper.Map<Session, Sales.Model.Models.Session>(session);
        }
    }
}
