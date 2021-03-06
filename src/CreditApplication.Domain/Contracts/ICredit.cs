﻿using System.Collections.Generic;

namespace CreditApplication.Domain.Contracts
{
    public interface ICredit
    {
        decimal Amount { get; }
        decimal Interest { get; }
        bool Aproved { get; }
        IEnumerable<string> Notifications { get; }
    }
}