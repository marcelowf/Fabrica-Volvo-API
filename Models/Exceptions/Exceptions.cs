using System;

namespace VOLVO_API
{
    class GetPropriedadeException : ApplicationException
    {
        public GetPropriedadeException(string mensagem) : base(mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }

    class SetPropriedadeException : ApplicationException
    {
        public SetPropriedadeException(string mensagem) : base(mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }

    class CarroException : ApplicationException
    {
        public CarroException(string mensagem) : base(mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }

    public class ControllerException : ApplicationException
    {
        public ControllerException(string mensagem) : base(mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}