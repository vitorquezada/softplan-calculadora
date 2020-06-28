using System.Threading.Tasks;

namespace Api2.BLL.Interfaces
{
    public interface ICalculosBll
    {
        Task<double> CalcularJuros(double valorInicial, int tempo);
    }
}
