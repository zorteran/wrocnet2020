using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogElkDemo.Web.Services
{
    public interface ICalculatorService
    {
        Task<double> Add(int firstNumber, int secondNumber);
        Task<double> Sub(int firstNumber, int secondNumber);
        Task<double> Multi(int firstNumber, int secondNumber);
        Task<double> RemoteMulti(int firstNumber, int secondNumber);
        Task<double> Div(int firstNumber, int secondNumber);
        Task<double> RemoteDiv(int firstNumber, int secondNumber);
    }
}

