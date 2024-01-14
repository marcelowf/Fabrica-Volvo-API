using System;
using System.Collections.Generic;

namespace VOLVO_API
{
    public class Eletrico : Carro
    {
        private List<Bateria>? _BateriasDisponiveis;
        public List<Bateria>? BateriasDisponiveis 
        { 
            get
            {
                try
                {
                    return _BateriasDisponiveis;
                }
                catch(GetPropriedadeException)
                {
                    throw new GetPropriedadeException("Falha ao retornar baterias.");
                }
            } 
            set
            {
                try
                {
                    if (value == null || value.Count == 0)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade BateriasDisponiveis.");
                    }
                    _BateriasDisponiveis = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar valores em BateriasDisponiveis");
                }
            } 
        }

        private Bateria? _BateriaSelecionada;
        public Bateria? BateriaSelecionada 
        { 
            get
            {
                try
                {
                    return _BateriaSelecionada;
                }
                catch(GetPropriedadeException)
                {
                    throw new GetPropriedadeException("Falha ao retornar uma BateriaSelecionada.");
                }
            }
            set 
            {
                try
                {
                    if(value == null) 
                    {
                        throw new SetPropriedadeException("A BateriaSelecionada é nula.");
                    }
                    _BateriaSelecionada = value;
                }
                catch(SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Falha ao definir uma BateriaSelecionada.");
                }
            }
        }

        public Eletrico()
        {
        }

        public Eletrico(string marcaVeiculo, string modeloVeiculo, int anoFabricacaoVeiculo, double precoVeiculo, string corVeiculo, double quilometragemCarro, 
        int numeroPortasCarro, bool tetoSolarCarro, string placaCarro, string modeloMotorSelecionado, string modeloBateriaSelecionada, List<Motor> motoresDisponiveis, List<Bateria> bateriasDisponiveis)

        : base(marcaVeiculo, modeloVeiculo, anoFabricacaoVeiculo, precoVeiculo, corVeiculo, quilometragemCarro, numeroPortasCarro, tetoSolarCarro, placaCarro, motoresDisponiveis, modeloMotorSelecionado)

        {
            BateriasDisponiveis = bateriasDisponiveis;
            BateriaSelecionada = BateriasDisponiveis.FirstOrDefault(bateria => bateria.Modelo == modeloBateriaSelecionada);
        }
        
        public override bool ViajarComCarro(double distancia)
        {
            if (BateriaSelecionada == null || MotorSelecionado == null)
            {
                throw new CarroException("Bateria ou Motor nulo.");
            }
            if(BateriaSelecionada?.CargaBateria <= 0)
            {
                throw new CarroException("Bateria com carga zero.");
            }
            if(MotorSelecionado?.Potencia * distancia > BateriaSelecionada?.CargaBateria)
            {
                throw new CarroException("Bateria Insuficiente para a viagem.");
            }
            BateriaSelecionada.CargaBateria -= MotorSelecionado?.Potencia * distancia;
            return true;
        }
    }
}