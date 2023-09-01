using Practica.Data;


namespace Practica3.Logic
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
