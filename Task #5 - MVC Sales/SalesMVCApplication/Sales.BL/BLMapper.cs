using AutoMapper;
using Sales.BL.DTO;
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
        internal OperationDto Mapping(Sales.Model.Models.Operation operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Operation, OperationDto>()
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
            return Mapper.Map<Sales.Model.Models.Operation, OperationDto>(operation);
        }
        internal ClientDto Mapping(Sales.Model.Models.Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Client, ClientDto>());
            return Mapper.Map<Sales.Model.Models.Client, ClientDto>(client);
        }
        internal ManagerDto Mapping(Sales.Model.Models.Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Manager, ManagerDto>());
            return Mapper.Map<Sales.Model.Models.Manager, ManagerDto>(manager);
        }
        internal PriceHistoryDto Mapping(Sales.Model.Models.PriceHistory priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.PriceHistory, PriceHistoryDto>()
                .ForMember(x => x.Product, o => o.Ignore())
                .AfterMap((pH1, pH2) =>
                    {
                        pH2.Product = Mapping(pH1.Product);
                    }));
            return Mapper.Map<Sales.Model.Models.PriceHistory, PriceHistoryDto>(priceHistory);
        }
        internal ProductDto Mapping(Sales.Model.Models.Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Sales.Model.Models.Product, ProductDto>());
            return Mapper.Map<Sales.Model.Models.Product, ProductDto>(product);
        }

        // To Model Types
        internal Sales.Model.Models.Operation Mapping(OperationDto operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<OperationDto, Sales.Model.Models.Operation>()
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
            return Mapper.Map<OperationDto, Sales.Model.Models.Operation>(operation);
        }
        internal Sales.Model.Models.Client Mapping(ClientDto client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ClientDto, Sales.Model.Models.Client>());
            return Mapper.Map<ClientDto, Sales.Model.Models.Client>(client);
        }
        internal Sales.Model.Models.Manager Mapping(ManagerDto manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ManagerDto, Sales.Model.Models.Manager>());
            return Mapper.Map<ManagerDto, Sales.Model.Models.Manager>(manager);
        }
        internal Sales.Model.Models.PriceHistory Mapping(PriceHistoryDto priceHistory)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PriceHistoryDto, Sales.Model.Models.PriceHistory>()
                .ForMember(x => x.Product, o => o.Ignore())
                .AfterMap((pH1, pH2) =>
                {
                    pH2.Product = Mapping(pH1.Product);
                }));
            return Mapper.Map<PriceHistoryDto, Sales.Model.Models.PriceHistory>(priceHistory);
        }
        internal Sales.Model.Models.Product Mapping(ProductDto product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDto, Sales.Model.Models.Product>());
            return Mapper.Map<ProductDto, Sales.Model.Models.Product>(product);
        }
    }
}
