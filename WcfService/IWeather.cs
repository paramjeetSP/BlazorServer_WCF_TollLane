using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWeather" in both code and config file together.
    [ServiceContract]
    public interface IWeather
    {
        [OperationContract]
        Task<List<WeatherForecast>> GetForecast(DateTime startDate);
    }
}
