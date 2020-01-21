using InvestimentoApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace InvestimentoApi.Exceptions
{
    [Serializable]
    public class InsufficientFundsExcetion : Exception
    {
        public InsufficientFundsExcetion() : base(Constantes.Exceptions.INSUFFICIENT_FUNDS) { }

        public InsufficientFundsExcetion(string mensagem) : base(mensagem) { }

        public InsufficientFundsExcetion(string mensagem, Exception inner) : base(mensagem, inner) { }

        protected InsufficientFundsExcetion(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
