namespace VOLVO_API
{
    public abstract class Carro : Veiculo
    {
        private double? _Quilometragem;
        public double? Quilometragem 
        {
            get
            {
                try
                    {
                        return _Quilometragem;
                    }
                    catch(GetPropriedadeException)
                    {
                        throw new GetPropriedadeException("Falha ao retornar a Quilometragem.");
                    }
            }
            set
            {
                try
                {
                    if (value == null || value < 0)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Quilometragem.");
                    }
                    _Quilometragem = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor da Quilometragem");
                }
            } 
        }

        private int? _NumeroPortas;
        public int? NumeroPortas 
        { 
            get
            {
                try
                {
                    return _NumeroPortas;
                }
                catch(GetPropriedadeException)
                {
                    throw new GetPropriedadeException("Falha ao retornar o Numero de Portas.");
                }
            }
            set
            {
                try
                {
                    if (value != 2 && value != 4)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade NumeroPortas.");
                    }
                    _NumeroPortas = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do NumeroPortas");
                }
            } 
        }
        
        private bool? _TetoSolar;
        public bool? TetoSolar 
        {
            get
            {
                try
                    {
                        return _TetoSolar;
                    }
                    catch(GetPropriedadeException)
                    {
                        throw new GetPropriedadeException("Falha ao retornar o Teto Solar.");
                    }
            }
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade TetoSolar.");
                    }
                    _TetoSolar = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do TetoSolar");
                }
            } 
        }

        private List<Motor>? _MotoresDisponiveis;
        public List<Motor>? MotoresDisponiveis 
        { 
            get
            {
                try
                {
                    return _MotoresDisponiveis;
                }
                catch(GetPropriedadeException)
                {
                    throw new GetPropriedadeException("Falha ao retornar Motores.");
                }
            } 
            set
            {
                try
                {
                    if (value == null || value.Count == 0)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade MotoresDisponiveis");
                    }
                    _MotoresDisponiveis = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar valores em MotoresDisponiveis");
                }
            }
        }

        private Motor? _MotorSelecionado;
        public Motor? MotorSelecionado 
        { 
            get
            {
                try
                {
                    return _MotorSelecionado;
                }
                catch(GetPropriedadeException)
                {
                    throw new GetPropriedadeException("Falha ao retornar um MotorSelecionado.");
                }
            }
            set 
            {
                try
                {
                    if(value == null) 
                    {
                        throw new SetPropriedadeException("O MotorSelecionado é nulo.");
                    }
                    _MotorSelecionado = value;
                }
                catch(SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Falha ao definir um MotorSelecionado.");
                }
            }
        }

        private string _Placa;
        public string Placa
        {
            get
            {
                try
                {
                    return _Placa;
                }
                catch
                {
                    throw new GetPropriedadeException("Falha ao retornar a Palca do Veiculo.");
                }
            }
            set
            {
                try
                {
                    if (value == null || value == "")
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Palca.");
                    }
                    _Placa = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor da Palca do Veiculo.");
                }
            }  
        } 

        public Carro()
        {
            
        }

        public Carro(string marcaVeiculo, string modeloVeiculo, int anoFabricacaoVeiculo, double precoVeiculo, string corVeiculo, double quilometragem, int numeroPortas, bool tetoSolar, string placaCarro, List<Motor> motoresDisponiveis, string modeloMotorSelecionado)
        : base(marcaVeiculo, modeloVeiculo, anoFabricacaoVeiculo, precoVeiculo, corVeiculo)
        {
            
            MotoresDisponiveis = motoresDisponiveis;
            MotorSelecionado = MotoresDisponiveis.FirstOrDefault(motor => motor.Modelo == modeloMotorSelecionado);

            Quilometragem = quilometragem;
            NumeroPortas = numeroPortas;
            TetoSolar = tetoSolar;
            Placa = placaCarro;
        }

        public virtual bool ViajarComCarro(double distancia)
        {
            return true;
        }
    }
}