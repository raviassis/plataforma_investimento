﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Shared
{
    public static class Constantes
    {
        public static class JwtClains
        {
            public const string ID = "id";
            public const string EMAIL = "email";
        }

        public static class Exceptions
        {
            public const string NEGATIVE_DEPOSIT_EXCEPTION = "Cannot deposit negative amounts.";
        }
    }
}
