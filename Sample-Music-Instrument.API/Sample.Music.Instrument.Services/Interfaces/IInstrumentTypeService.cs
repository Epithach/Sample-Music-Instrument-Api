using Sample_Music_Instrument.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Music.Instrument.Services.Interfaces
{
    public interface IInstrumentTypeService
    {
        List<InstrumentType> Get();

        InstrumentType GetById(string id);

        InstrumentType GetByName(string name);

        InstrumentType Create(InstrumentType instrument);

        void Update(InstrumentType instrument);

        void Delete(string id);
    }
}
