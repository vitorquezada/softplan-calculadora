using System.Threading.Tasks;

namespace Api1.DAL.Interfaces
{
    public interface ITaxaDal
    {
        Task<decimal> ObterTaxaJuros();
    }
}
