using ProductionCode.BE;
using ProductionCode.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCode.DataAccess
{
    public class FakeRepository: IFakeRepository
    {
        private readonly IEnumerable<BERating> _bERatings;

        IEnumerable<BERating> IFakeRepository.GetAll()
        {

            return _bERatings;

        }

    
    }
}
