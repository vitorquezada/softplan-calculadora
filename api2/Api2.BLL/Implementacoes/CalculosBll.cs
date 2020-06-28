using Api2.BLL.Interfaces;
using Api2.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace Api2.BLL.Implementacoes
{
    public class CalculosBll : ICalculosBll
    {
        private readonly ICalculosDal _calculosDal;

        public CalculosBll(ICalculosDal calculosDal)
        {
            _calculosDal = calculosDal;
        }

        public async Task<double> CalcularJuros(double valorInicial, int tempo)
        {
            var juros = Convert.ToDouble(await _calculosDal.ObterTaxaJuros());

            var valorFinal = valorInicial * Math.Pow(1 + juros, tempo);

            const int quantidadeCasasDecimais = 2;
            var multiplicadorCasasDecimais = Math.Pow(10, quantidadeCasasDecimais);
            var valorFinalTruncado = Math.Truncate(valorFinal * multiplicadorCasasDecimais) / multiplicadorCasasDecimais;

            return valorFinalTruncado;
        }
    }
}
