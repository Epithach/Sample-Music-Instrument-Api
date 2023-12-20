using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Music.Instrument.Services.Interfaces;

namespace Sample.Music.Instrument.Services.Settings
{
    public class InstrumentTypeSettings : IInstrumentTypeSettings
    {
        public string InstrumentTypeCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
