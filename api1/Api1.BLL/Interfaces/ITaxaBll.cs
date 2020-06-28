using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api1.BLL.Interfaces
{
    public interface ITaxaBll
    {
        Task<decimal> ObterTaxaJuros();
    }
}
