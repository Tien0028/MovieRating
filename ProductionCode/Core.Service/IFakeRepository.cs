using ProductionCode.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCode.Core.Service
{
    public interface IFakeRepository
    {

        IEnumerable<BERating> GetAll();

    }
}
