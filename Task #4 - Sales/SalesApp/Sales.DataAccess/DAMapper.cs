using Sales.DataAccess.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Sales.DataAccess
{
    public class DAMapper
    {
        public DAL.Manager Mapping(Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Manager, DAL.Manager>());
            return Mapper.Map<Manager, DAL.Manager>(manager);
        }
        public DAL.Client Mapping(Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, DAL.Client>());
            return Mapper.Map<Client, DAL.Client>(client);
        }
        public DAL.Product Mapping(Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, DAL.Product>());
            return Mapper.Map<Product, DAL.Product>(product);
        }
        public DAL.Session Mapping(Session session)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Session, DAL.Session>());
            return Mapper.Map<Session, DAL.Session>(session);
        }

        //public DAL.Operation Mapping(Operation operation)
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap<Operation, DAL.Operation>()
        //        .ForMember("Manager_ID", opt => opt.MapFrom(c => c.Manager.Id))
        //        .ForMember("Client_ID", opt => opt.MapFrom(c => c.Client.Id))
        //        .ForMember("Product_ID", opt => opt.MapFrom(c => c.Product.Id))
        //        .ForMember("Session_ID", opt => opt.MapFrom(c => c.Session.Id))
        //        );
        //    return Mapper.Map<Operation, DAL.Operation>(operation);
        //}

        public Manager Mapping(DAL.Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DAL.Manager, Manager>());
            return Mapper.Map<DAL.Manager, Manager>(manager);
        }
        public Client Mapping(DAL.Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DAL.Client, Client>());
            return Mapper.Map<DAL.Client, Client>(client);
        }
        public Product Mapping(DAL.Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DAL.Product, Product>());
            return Mapper.Map<DAL.Product, Product>(product);
        }
        public Session Mapping(DAL.Session session)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DAL.Session, Session>());
            return Mapper.Map<DAL.Session, Session>(session);
        }
    }
}
