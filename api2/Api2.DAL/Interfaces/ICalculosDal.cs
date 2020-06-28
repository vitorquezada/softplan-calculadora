using System.Threading.Tasks;

namespace Api2.DAL.Interfaces
{
    public interface ICalculosDal
    {
        Task<double?> ObterTaxaJuros();
    }
}
