using Practica4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.Logic
{
    public class BaseLogic
    {
        public readonly NorthwindContext _context;

        public BaseLogic()
        {
            _context = new NorthwindContext();
        }

    }
}
