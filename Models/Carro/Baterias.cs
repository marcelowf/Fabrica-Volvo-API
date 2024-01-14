namespace VOLVO_API
{
    public class Bateria
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
                        throw new GetPropriedadeException("Falha ao retornar o Modelo da Bateria.");
                    }
            }    
            set
            {
                try
                {
                    if (value == null || value == "")
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Modelo de Bateria.");
                    }
                    _Modelo = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do Modelo de Bateria");
                }
            } 
        }

        private double? _CapacidadeKW;
        public double? CapacidadeKW 
        {
            get
            {
                try
                    {
                        return _CapacidadeKW;
                    }
                    catch(GetPropriedadeException)
                    {
                        throw new GetPropriedadeException("Falha ao retornar o Capacidade em KWh.");
                    }
            }
            set
            {
                try
                {
                    if (value == null || value < 0)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade CapacidadeKW.");
                    }
                    _CapacidadeKW = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do CapacidadeKW");
                }
            } 
        }

        private double? _CargaBateria;
        public double? CargaBateria
        {
            get
            {
                try
                    {
                        return _CargaBateria;
                    }
                    catch(GetPropriedadeException)
                    {
                        throw new GetPropriedadeException("Falha ao retornar a Carga da Bateria.");
                    }
            }
            set
            {
                try
                {
                    if (value == null || value < 0 || value > CapacidadeKW)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade CargaBateria.");
                    }
                    _CargaBateria = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor de CargaBateria");
                }
            } 
        }

        public Bateria()
        { 
        }

        public Bateria(string modelo, double capacidadeKW)
        {
            Modelo = modelo;
            CapacidadeKW = capacidadeKW;
            CargaBateria = 0.0;
        }
        
        public bool AbastecerEletrico(double quantidade)
        {
            double novaCarga = CargaBateria.GetValueOrDefault() + quantidade;

            if (novaCarga >= CapacidadeKW || quantidade <= 0)
            {
                return false;
            }

            CargaBateria = novaCarga;
            return true;
        }

        public double? ChecarCarga()
        {
            return CargaBateria;
        }
    }
}