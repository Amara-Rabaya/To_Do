using Tranning_pro.Data;
using Tranning_pro.Models;

namespace Tranning_pro.Repositories
{
    public class LogsRepository
    {
        private readonly ApplicationDbContext _context;

        public LogsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(string detales)
        {
            var log = new Logs
            {
                creat_date = DateTime.Now,
                detales = detales
            };

            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
