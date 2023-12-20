namespace Sample.Music.Instrument.Services.Interfaces
{
    public interface IInstrumentTypeSettings
    {
        string InstrumentTypeCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}