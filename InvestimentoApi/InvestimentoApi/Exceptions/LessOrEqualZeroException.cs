using InvestimentoApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace InvestimentoApi.Exceptions
{
    [Serializable]
    public class LessOrEqualZeroException: Exception
    {
        public LessOrEqualZeroException() : base(Constantes.Exceptions.LESS_OR_EQUAL_ZERO) { }

        public LessOrEqualZeroException(string mensagem) : base(mensagem) { }

        public LessOrEqualZeroException(string mensagem, Exception inner) : base(mensagem, inner) { }

        protected LessOrEqualZeroException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
