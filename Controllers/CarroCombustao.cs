using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VOLVO_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroCombustaoController : ControllerBase
    {
        public static List<Combustao> carrosCombustao;
        public static List<string> nomesCarrosCombustao;

        public CarroCombustaoController()
        {
            if (carrosCombustao == null)
            {
                carrosCombustao = new List<Combustao>();
            }
            if(nomesCarrosCombustao == null)
            {
                nomesCarrosCombustao = new List<string>();
                AdicionarListaNomesCarrosCombustao();
            }
        }

        static void AdicionarListaNomesCarrosCombustao()
        {
            nomesCarrosCombustao.Clear();
            foreach (Combustao carro in carrosCombustao)
            {
                nomesCarrosCombustao.Add(carro.Modelo);
            }
        }

        [HttpGet]
        public List<string> getTodosNomesCarrosCombustao()
        {
            return nomesCarrosCombustao;
        }

        [HttpPost]
        public IActionResult CriarCarroCombustao(Combustao novoCarro)
        {
            try
            {
                carrosCombustao.Add(novoCarro);
                AdicionarListaNomesCarrosCombustao();
                return Ok($"Carro elétrico {novoCarro.Modelo} criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar o carro elétrico: {ex.Message}");
            }
        }

        [HttpDelete("{placa}")]
        public IActionResult ExcluirCarroCombustao(string placa)
        {
            try
            {
                var carroParaExcluir = carrosCombustao.FirstOrDefault(c => c.Placa == placa);

                if (carroParaExcluir == null)
                {
                    return NotFound($"Carro a Combustão com a placa {placa} não encontrado.");
                }

                carrosCombustao.Remove(carroParaExcluir);
                AdicionarListaNomesCarrosCombustao();
                return Ok($"Carro a Combustão de placa {placa} excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir o carro elétrico: {ex.Message}");
            }
        }

        [HttpPut("{placa}")]
        public IActionResult AtualizarCarroCombustao(string placa, Combustao carroAtualizado)
        {
            try
            {
                var carroExistente = carrosCombustao.FirstOrDefault(c => c.Placa == placa);

                if (carroExistente == null)
                {
                    return NotFound($"Carro a Combustão com a placa {placa} não encontrado.");
                }

                carroExistente.Marca = carroAtualizado.Marca;
                carroExistente.Modelo = carroAtualizado.Modelo;
                carroExistente.AnoFabricacao = carroAtualizado.AnoFabricacao;
                carroExistente.Preco = carroAtualizado.Preco;
                carroExistente.Cor = carroAtualizado.Cor;
                carroExistente.NumeroPortas = carroAtualizado.NumeroPortas;
                carroExistente.TetoSolar = carroAtualizado.TetoSolar;

                AdicionarListaNomesCarrosCombustao();
                return Ok($"Carro a Combustão de placa {placa} atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar o carro elétrico: {ex.Message}");
            }
        }

        [HttpGet("{placa}")]
        public IActionResult getCombustivelTanque(string placa)
        {
            try
            {
                var carro = carrosCombustao.FirstOrDefault(c => c.Placa == placa);

                if (carro == null)
                {
                    return NotFound($"Carro com a placa {placa} não encontrado.");
                }
                
                double? carga = carro.TanqueSelecionado.ChecarCombustivel();
                return Ok($"Carga do tanque para o carro com a placa {placa}: {carga}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao checar a carga do tanque: {ex.Message}");
            }
        }

        [HttpPost("Abastecer/{placa}/{quantidadeL}")]
        public IActionResult postAbastecerTanque(string placa, double quantidadeL)
        {
            try
            {
                var carro = carrosCombustao.FirstOrDefault(c => c.Placa == placa);

                if (carro == null)
                {
                    return NotFound($"Carro com a placa {placa} não encontrado.");
                }

                if (carro.TanqueSelecionado.AbastecerCombustao(quantidadeL))
                {
                    double? CombustivelAtual = carro.TanqueSelecionado.ChecarCombustivel();
                    return Ok($"Tanque abastecido com +{quantidadeL} Litros. Carga atual: {CombustivelAtual}L.");
                }
                else
                {
                    return BadRequest($"Valor inválido ou maior que a capacidade do Tanque.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao abastecer o tanque: {ex.Message}");
            }
        }

        [HttpPost("Viajar/{placa}/{distanciaKM}")]
        public IActionResult ViajarComCarroCombustao(string placa, double distanciaKM)
        {
            try
            {
                var carro = carrosCombustao.FirstOrDefault(c => c.Placa == placa);

                if (carro == null)
                {
                    return NotFound($"Carro com a placa {placa} não encontrado.");
                }

                if (carro.ViajarComCarro(distanciaKM))
                {
                    return Ok($"Viagem Realizada!\nCarga restante no tanque: {carro.TanqueSelecionado.ChecarCombustivel()}.");
                }
                else
                {
                    return BadRequest($"A Viagem não pode ser realizada, verifique a integridade do carro e a carga do Tanque.");
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro ao viajar com o carro de placa {placa}.\n{ex.Message}");
            }
        }
    }
}

