using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL
{
    class DALMapper
    {
        // To BL Types
        internal Model.Operation Mapping(Sales.Model.Models.Operation operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Operation, Model.Operation>()
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
            return Mapper.Map<Sales.Model.Models.Operation, Model.Operation>(operation);
        }
        internal Model.Client Mapping(Sales.Model.Models.Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Client, Model.Client>());
            return Mapper.Map<Sales.Model.Models.Client, Model.Client>(client);
        }
        internal Model.Manager Mapping(Sales.Model.Models.Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Manager, Model.Manager>());
            return Mapper.Map<Sales.Model.Models.Manager, Model.Manager>(manager);
        }
        internal Model.PriceHistory Mapping(Sales.Model.Models.PriceHistory priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.PriceHistory, Model.PriceHistory>());
            return Mapper.Map<Sales.Model.Models.PriceHistory, Model.PriceHistory>(priceHistory);
        }
        internal Model.Product Mapping(Sales.Model.Models.Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Product, Model.Product>());
            return Mapper.Map<Sales.Model.Models.Product, Model.Product>(product);
        }
        internal Model.Session Mapping(Sales.Model.Models.Session session)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Session, Model.Session>());
            return Mapper.Map<Sales.Model.Models.Session, Model.Session>(session);
        }


        // To Model Types
        internal Sales.Model.Models.Operation Mapping(Model.Operation operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Model.Operation, Sales.Model.Models.Operation>()
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
            return Mapper.Map<Model.Operation, Sales.Model.Models.Operation>(operation);
        }
        internal Sales.Model.Models.Client Mapping(Model.Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Model.Client, Sales.Model.Models.Client>());
            return Mapper.Map<Model.Client, Sales.Model.Models.Client>(client);
        }
        internal Sales.Model.Models.Manager Mapping(Model.Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Model.Manager, Sales.Model.Models.Manager>());
            return Mapper.Map<Model.Manager, Sales.Model.Models.Manager>(manager);
        }
        internal Sales.Model.Models.PriceHistory Mapping(Model.PriceHistory priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Model.PriceHistory, Sales.Model.Models.PriceHistory>());
            return Mapper.Map<Model.PriceHistory, Sales.Model.Models.PriceHistory>(priceHistory);
        }
        internal Sales.Model.Models.Product Mapping(Model.Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Model.Product, Sales.Model.Models.Product>());
            return Mapper.Map<Model.Product, Sales.Model.Models.Product>(product);
        }
        internal Sales.Model.Models.Session Mapping(Model.Session session)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Model.Session, Sales.Model.Models.Session>());
            return Mapper.Map<Model.Session, Sales.Model.Models.Session>(session);
        }
    }
}
