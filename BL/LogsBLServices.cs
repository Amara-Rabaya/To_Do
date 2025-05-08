using DAL.Interface;
using DAL.Repositores;
using Tranning_pro.BLInterface;

namespace Tranning_pro.BL
{
    public class LogsBLServices: ILogsBLServices
    {
        private readonly ILogsRepository _ILogsRepository;
        public LogsBLServices(ILogsRepository logsRepository)
        {
            _ILogsRepository = logsRepository;   


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
