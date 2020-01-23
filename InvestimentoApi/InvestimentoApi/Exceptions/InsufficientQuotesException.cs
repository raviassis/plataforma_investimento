using InvestimentoApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace InvestimentoApi.Exceptions
{
    [Serializable]
    public class InsufficientQuotesException: Exception
    {
        public InsufficientQuotesException() : base(Constantes.Exceptions.INSUFFICIENT_QUOTES) { }

        public InsufficientQuotesException(string mensagem) : base(mensagem) { }

        public InsufficientQuotesException(string mensagem, Exception inner) : base(mensagem, inner) { }

        protected InsufficientQuotesException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
