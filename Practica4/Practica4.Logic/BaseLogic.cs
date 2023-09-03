using Practica4.Data;

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
