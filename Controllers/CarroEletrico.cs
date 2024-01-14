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
    public class CarroEletricoController : ControllerBase
    {
        public static List<Eletrico> carrosEletricos;
        public static List<string> nomesCarrosEletricos;

        public CarroEletricoController()
        {
            if(carrosEletricos == null)
            {
                carrosEletricos = new List<Eletrico>();
            }
            if(nomesCarrosEletricos == null)
            {
                nomesCarrosEletricos = new List<string>();
                AdicionarListaNomesCarrosEletricos();
            }
        }

        static void AdicionarListaNomesCarrosEletricos()
        {
            nomesCarrosEletricos.Clear();
            foreach (Eletrico carro in carrosEletricos)
            {
                nomesCarrosEletricos.Add(carro.Modelo);
            }
        }

        [HttpGet]
        public List<string> getTodosNomesCarrosEletricos()
        {
            return nomesCarrosEletricos;
        }

        [HttpPost]
        public IActionResult CriarCarroEletrico(Eletrico novoCarro)
        {
            try
            {
                carrosEletricos.Add(novoCarro);
                AdicionarListaNomesCarrosEletricos();
                return Ok($"Carro elétrico {novoCarro.Modelo} criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar o carro elétrico: {ex.Message}");
            }
        }

        [HttpDelete("{placa}")]
        public IActionResult ExcluirCarroEletrico(string placa)
        {
            try
            {
                var carroParaExcluir = carrosEletricos.FirstOrDefault(c => c.Placa == placa);

                if (carroParaExcluir == null)
                {
                    return NotFound($"Carro elétrico com a placa {placa} não encontrado.");
                }

                carrosEletricos.Remove(carroParaExcluir);
                AdicionarListaNomesCarrosEletricos();
                return Ok($"Carro elétrico de placa {placa} excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir o carro elétrico: {ex.Message}");
            }
        }

        [HttpPut("{placa}")]
        public IActionResult AtualizarCarroEletrico(string placa, Eletrico carroAtualizado)
        {
            try
            {
                var carroExistente = carrosEletricos.FirstOrDefault(c => c.Placa == placa);

                if (carroExistente == null)
                {
                    return NotFound($"Carro elétrico com a placa {placa} não encontrado.");
                }

                carroExistente.Marca = carroAtualizado.Marca;
                carroExistente.Modelo = carroAtualizado.Modelo;
                carroExistente.AnoFabricacao = carroAtualizado.AnoFabricacao;
                carroExistente.Preco = carroAtualizado.Preco;
                carroExistente.Cor = carroAtualizado.Cor;
                carroExistente.NumeroPortas = carroAtualizado.NumeroPortas;
                carroExistente.TetoSolar = carroAtualizado.TetoSolar;

                AdicionarListaNomesCarrosEletricos();
                return Ok($"Carro elétrico de placa {placa} atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar o carro elétrico: {ex.Message}");
            }
        }

        [HttpGet("{placa}")]
        public IActionResult getCargaBateria(string placa)
        {
            try
            {
                var carro = carrosEletricos.FirstOrDefault(c => c.Placa == placa);

                if (carro == null)
                {
                    return NotFound($"Carro com a placa {placa} não encontrado.");
                }
                
                double? carga = carro.BateriaSelecionada.ChecarCarga();
                return Ok($"Carga da bateria para o carro com a placa {placa}: {carga}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao checar a carga da bateria: {ex.Message}");
            }
        }

        [HttpPost("Abastecer/{placa}/{quantidadeKW}")]
        public IActionResult PostAbastecerBateria(string placa, double quantidadeKW)
        {
            try
            {
                var carro = carrosEletricos.FirstOrDefault(c => c.Placa == placa);

                if (carro == null)
                {
                    return NotFound($"Carro com a placa {placa} não encontrado.");
                }

                if (carro.BateriaSelecionada.AbastecerEletrico(quantidadeKW))
                {
                    double? cargaAtual = carro.BateriaSelecionada.ChecarCarga();
                    return Ok($"Bateria carregada com +{quantidadeKW}KW. Carga atual: {cargaAtual}KW.");
                }
                else
                {
                    return BadRequest($"Valor inválido ou maior que a capacidade da Bateria.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao abastecer a bateria: {ex.Message}");
            }
        }

        [HttpPost("Viajar/{placa}/{distanciaKM}")]
        public IActionResult ViajarComCarroEletrico(string placa, double distanciaKM)
        {
            try
            {
                var carro = carrosEletricos.FirstOrDefault(c => c.Placa == placa);

                if (carro == null)
                {
                    return NotFound($"Carro com a placa {placa} não encontrado.");
                }

                if (carro.ViajarComCarro(distanciaKM))
                {
                    return Ok($"Viagem Realizada!\nCarga restante na bateria: {carro.BateriaSelecionada.ChecarCarga()}.");
                }
                else
                {
                    return BadRequest($"A Viagem não pode ser realizada, verifique a integridade do carro e a carga da Bateria.");
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro ao viajar com o carro de placa {placa}.\n{ex.Message}");
            }
        }
    }
}