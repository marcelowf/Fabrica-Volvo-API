using System;
using System.Collections.Generic;

namespace VOLVO_API
{
    public class Combustao : Carro
    {
        private List<Tanque>? _TanquesDisponiveis;
        public List<Tanque>? TanquesDisponiveis 
        {
            get
            {
                try
                {
                    return _TanquesDisponiveis;
                }
                catch(GetPropriedadeException)
                {
                    throw new GetPropriedadeException("Falha ao retornar tanques.");
                }
            } 
            set
            {
                try
                {
                    if (value == null || value.Count == 0)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade TanquesDisponiveis.");
                    }
                    _TanquesDisponiveis = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar valores em TanquesDisponiveis");
                }
            } 
        }

        private Tanque? _TanqueSelecionado;
        public Tanque? TanqueSelecionado 
        {
            get
            {
                try
                {
                    return _TanqueSelecionado;
                }
                catch(GetPropriedadeException)
                {
                    throw new GetPropriedadeException("Falha ao retornar um TanqueSelecionado.");
                }
            }
            set 
            {
                try
                {
                    if(value == null) 
                    {
                        throw new SetPropriedadeException("O TanqueSelecionado é nulo.");
                    }
                    _TanqueSelecionado = value;
                }
                catch(SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Falha ao definir um TanqueSelecionado.");
                }
            }
        }

        public Combustao()
        {
        }

        public Combustao(string marcaVeiculo, string modeloVeiculo, int anoFabricacaoVeiculo, double precoVeiculo, string corVeiculo, double quilometragemCarro, 
        int numeroPortasCarro, bool tetoSolarCarro, string placaCarro, string modeloMotorSelecionado, string modeloTanqueSelecionado, List<Motor> motoresDisponiveis, List<Tanque> tanquesDisponiveis)

        : base(marcaVeiculo, modeloVeiculo, anoFabricacaoVeiculo, precoVeiculo, corVeiculo, quilometragemCarro, numeroPortasCarro, tetoSolarCarro, placaCarro, motoresDisponiveis, modeloMotorSelecionado)

        {
            TanquesDisponiveis = tanquesDisponiveis;
            TanqueSelecionado = TanquesDisponiveis.FirstOrDefault(tanque => tanque.Modelo == modeloTanqueSelecionado);
        }

        public override bool ViajarComCarro(double distancia)
        {
            if (TanqueSelecionado == null || MotorSelecionado == null)
            {
                throw new CarroException("Tanque ou Motor nulo.");
            }
            if(TanqueSelecionado?.LitrosTanque <= 0)
            {
                throw new CarroException("Combustivel Zerado.");
            }
            if(MotorSelecionado?.Potencia * distancia > TanqueSelecionado?.LitrosTanque)
            {
                throw new CarroException("Combustivel Insuficiente para a viagem.");
            }
            TanqueSelecionado.LitrosTanque -= MotorSelecionado?.Potencia * distancia;
            return true;
        }
    }
}