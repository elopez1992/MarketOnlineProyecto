using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos
{
    public class MarketContex: DbContext
    {
        public MarketContex():base("Name=MarketOnline")
        {

        }
    }

}
