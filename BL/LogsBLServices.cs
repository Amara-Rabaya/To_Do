using DAL.Repositores;

namespace Tranning_pro.BL
{
    public class LogsBLServices
    {
        private readonly LogsRepository _logsRepository;
        public LogsBLServices(LogsRepository logsRepository)
        {
            _logsRepository = logsRepository;   


        }
        public bool addLog(string detalies)
        {
            try
            {
                _logsRepository.Add(detalies);
                return true;    
            }
            catch (Exception ex)
            {
                return false;
            }

              
        }
    }
}
