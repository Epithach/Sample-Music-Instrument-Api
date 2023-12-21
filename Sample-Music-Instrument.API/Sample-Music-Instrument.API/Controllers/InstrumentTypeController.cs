using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Sample.Music.Instrument.Services.Interfaces;
using Sample.Music.Instrument.Services.Services;
using Sample_Music_Instrument.Business.Interfaces;
using Sample_Music_Instrument.Models;

namespace Sample_Music_Instrument.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentTypeController : ControllerBase
    {
        private readonly IInstrumentTypeBusiness _instrumentTypeBusiness;
        private readonly ILogger<InstrumentTypeController> _logger;

        public InstrumentTypeController(IInstrumentTypeBusiness instrumentTypeBusiness, ILogger<InstrumentTypeController> logger) 
        {
            _instrumentTypeBusiness = instrumentTypeBusiness;
            _logger = logger;
        }

        public ActionResult Get()
        {
            try
            {
                _logger.LogDebug($"[InstrumentTypeBusiness][Get] : Getting all entries in database.");
                return Ok(_instrumentTypeBusiness.Get());
            }
            catch (Exception exception)
            {
                _logger.LogError("[InstrumentTypeController][Get] : An error occured while gettings all Instrument Types.", exception);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        List<string> GetAllTypes(){}

        InstrumentType GetById(string id){}

        InstrumentType GetByName(string name){}

        InstrumentType Create(string instrumentTypeName){}

        void Update(InstrumentType instrumentType){}

        void Delete(string id){}
    }
}
