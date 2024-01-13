namespace VOLVO_API
{
    public class Motor
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
                        throw new GetPropriedadeException("Falha ao retornar o Modelo do Motor.");
                    }
            }    
            set
            {
                try
                {
                    if (value == null || value == "")
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Modelo do Motor.");
                    }
                    _Modelo = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do Modelo do Motor");
                }
            } 
        }

        private double? _Potencia;
        public double? Potencia 
        { 
            get
            {
                try
                    {
                        return _Potencia;
                    }
                    catch(GetPropriedadeException)
                    {
                        throw new GetPropriedadeException("Falha ao retornar a Potencia do Motor.");
                    }
            }    
            set
            {
                try
                {
                    if (value == null || value < 0)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Potencia do Motor.");
                    }
                    _Potencia = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do Potencia do Motor");
                }
            } 
        }

        public Motor()
        {
            
        }

        public Motor(string modelo, double potencia)
        {
            Modelo = modelo;
            Potencia = potencia;
        }
    }
}