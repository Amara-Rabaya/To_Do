using DAL.DataBase;
using DAL.Interface;
using DAL.ModelsNew;

namespace DAL.Repositores
{
    public class LogsRepository: ILogsRepository
    {
        private readonly DbContextDLA _context;
       

        public LogsRepository(DbContextDLA context)
        {
            _context = context;
        }

        public void Add(string detales)
        {
            var log = new LogsDAL
            {
                creat_date = DateTime.Now,
                detales = detales
            };

            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
