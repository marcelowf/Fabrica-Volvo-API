namespace VOLVO_API
{
    public abstract class Veiculo
    {
        private string? _Marca; 
        public string? Marca 
        { 
            get
            {
                try
                {
                    return _Marca;
                }
                catch
                {
                    throw new GetPropriedadeException("Falha ao retornar a Marca.");
                }
            }
            set
            {
                try
                {
                    if (value == null || value == "")
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Marca.");
                    }
                    _Marca = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor da Marca do Veiculo.");
                }
            }
        }

        public string? _Modelo;
        public string? Modelo 
        { 
            get
            {
                try
                {
                    return _Modelo;
                }
                catch
                {
                    throw new GetPropriedadeException("Falha ao retornar o Modelo do Veiculo.");
                }
            }
            set
            {
                try
                {
                    if (value == null || value == "")
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Modelo.");
                    }
                    _Modelo = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do Modelo do Veiculo.");
                }
            }
        }

        public int? _AnoFabricacao;
        public int? AnoFabricacao 
        { 
            get
            {
                try
                {
                    return _AnoFabricacao;
                }
                catch
                {
                    throw new GetPropriedadeException("Falha ao retornar o Ano de Fabricacao do Veiculo.");
                }
            }
            set
            {
                try
                {
                    if (value == null || value < 1927)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade AnoFabricacao.");
                    }
                    _AnoFabricacao = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do AnoFabricacao do Veiculo.");
                }
            }
        }

        private double? _Preco; 
        public double? Preco 
        { 
            get
            {
                try
                {
                    return _Preco;
                }
                catch
                {
                    throw new GetPropriedadeException("Falha ao retornar o Preco do Veiculo.");
                }
            }
            set
            {
                try
                {
                    if (value == null || value < 0)
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Preco.");
                    }
                    _Preco = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor do Preco do Veiculo.");
                }
            } 
        }

        public string? _Cor; 
        public string? Cor 
        { 
            get
            {
                try
                {
                    return _Cor;
                }
                catch
                {
                    throw new GetPropriedadeException("Falha ao retornar a Cor do Veiculo.");
                }
            }
            set
            {
                try
                {
                    if (value == null || value == "")
                    {
                        throw new SetPropriedadeException("Valor inválido para a propriedade Cor.");
                    }
                    _Cor = value;
                }
                catch (SetPropriedadeException)
                {
                    throw new SetPropriedadeException("Inspossivel modificar o valor da Cor do Veiculo.");
                }
            }  
        }

        public Veiculo()
        {
            
        }

        public Veiculo(string marca, string modelo, int anoFabricacao, double preco, string cor)
        {
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            Preco = preco;
            Cor = cor;
        }
    }
}
