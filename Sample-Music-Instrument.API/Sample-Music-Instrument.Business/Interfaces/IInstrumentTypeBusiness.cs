using Sample_Music_Instrument.Models;

namespace Sample_Music_Instrument.Business.Interfaces
{
    public interface IInstrumentTypeBusiness
    {
        List<InstrumentType> Get();

        List<string> GetAllTypes();

        InstrumentType GetById(string id);

        InstrumentType GetByName(string name);

        InstrumentType Create(string instrumentTypeName);

        void Update(InstrumentType instrumentType);

        void Delete(string id);
    }
}
