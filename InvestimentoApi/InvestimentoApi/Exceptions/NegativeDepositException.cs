using InvestimentoApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace InvestimentoApi.Exceptions
{
    [Serializable]
    public class NegativeDepositException : Exception
    {
        public NegativeDepositException(): base(Constantes.Exceptions.NEGATIVE_DEPOSIT_EXCEPTION) { }

        public NegativeDepositException(string mensagem) : base(mensagem) { }

        public NegativeDepositException(string mensagem, Exception inner) : base(mensagem, inner) { }

        protected NegativeDepositException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
