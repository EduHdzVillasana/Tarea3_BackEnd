using DatabaseFirstDWB.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.Backend
{
    public class BaseSC
    {
        protected static NorthwindContext dataContext = new NorthwindContext();
    }
}