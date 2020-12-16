using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogElkDemo.Web.Services
{
    public interface IRemoteCalculatorClient
    {
        Task<double> Multi(int firstNumber, int secondNumber);
        Task<double> Div(int firstNumber, int secondNumber);
    }
}
