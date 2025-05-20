using DAL.DataBase;
using DAL.Interface;
using DAL.Repositores;
using Tranning_pro.BLInterface;

namespace Tranning_pro.BL
{
    public class LogsBLServices: ILogsBLServices
    {
        private readonly ILogsRepository _ILogsRepository;
        public LogsBLServices(DbContextDLA context)
        {
            _ILogsRepository = new LogsRepository(context);

        }
        public bool addLog(string detalies)
        {
            try
            {
                _ILogsRepository.Add(detalies);
                return true;    
            }
            catch (Exception ex)
            {
                return false;
            }

              
        }
    }
}
