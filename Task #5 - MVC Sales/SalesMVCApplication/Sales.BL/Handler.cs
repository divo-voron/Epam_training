using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.BL.Model;

namespace Sales.BL
{
    public class Handler
    {
        DALMapper Mapper = new DALMapper();

        public IEnumerable<Manager> Method()
        {
            Sales.DAL.UnitOfWork unit = new Sales.DAL.UnitOfWork();
            return unit.Managers.GetAll().Select(x => Mapper.Mapping(x));
        }
    }
}
