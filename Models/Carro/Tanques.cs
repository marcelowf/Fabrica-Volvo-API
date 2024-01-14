namespace VOLVO_API
{
    public class Tanque
    {
        private string? _Modelo;
        public string? Modelo 
        { 
            get
            {
                try
                    {
                        return _Modelo;
                    }
                    catch(GetPropriedadeException)
                    {
                        throw new GetPropriedadeException("Falha ao retornar o Modelo do Tanque.");
                    }
            }    
            set
            {
                try
                {
                    if (value == null || value == "")
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Modelo de Tanque.");
                    }
                    _Modelo = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do Modelo de Tanque");
                }
            } 
        }
        
        private double? _CapacidadeL;
        public double? CapacidadeL 
        {
            get
            {
                try
                    {
                        return _CapacidadeL;
                    }
                    catch(GetPropriedadeException)
                    {
                        throw new GetPropriedadeException("Falha ao retornar o Capacidade em KMh.");
                    }
            }
            set
            {
                try
                {
                    if (value == null || value < 0)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade CapacidadeL.");
                    }
                    _CapacidadeL = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do CapacidadeL");
                }
            } 
        }

        private double? _LitrosTanque;
        public double? LitrosTanque
        {
            get
            {
                try
                    {
                        return _LitrosTanque;
                    }
                    catch(GetPropriedadeException)
                    {
                        throw new GetPropriedadeException("Falha ao retornar os Litros do Tanque.");
                    }
            }
            set
            {
                try
                {
                    if (value == null || value < 0 || value > CapacidadeL)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade LitrosTanque.");
                    }
                    _LitrosTanque = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor de LitrosTanque");
                }
            } 
        }

        public Tanque()
        {
        }

        public Tanque(string modelo, double capacidadeL)
        {
            Modelo = modelo;
            CapacidadeL = capacidadeL;
            LitrosTanque = 0.0;
        }

        public bool AbastecerCombustao(double quantidade)
        {
            double novaCarga = LitrosTanque.GetValueOrDefault() + quantidade;

            if(novaCarga >= CapacidadeL ||  quantidade <= 0)
            {
                return false;
            }
            
            LitrosTanque = novaCarga;
            return true;
        }

        public double? ChecarCombustivel()
        {
            return LitrosTanque;
        }
    }
}