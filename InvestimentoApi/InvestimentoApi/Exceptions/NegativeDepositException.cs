using InvestimentoApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace InvestimentoApi.Exceptions
{
    [Serializable]
    public class NegativeTransactionException : Exception
    {
        public NegativeTransactionException(): base(Constantes.Exceptions.NEGATIVE_TRANSACTION) { }

        public NegativeTransactionException(string mensagem) : base(mensagem) { }

        public NegativeTransactionException(string mensagem, Exception inner) : base(mensagem, inner) { }

        protected NegativeTransactionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
