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

        public ActionResult GetAllTypes()
        {
            try
            {
                _logger.LogDebug($"[InstrumentTypeBusiness][GetAllTypes] : Getting all types available in database.");
                return Ok(_instrumentTypeBusiness.GetAllTypes());
            }
            catch (Exception exception)
            {
                _logger.LogError("[InstrumentTypeController][GetAllTypes] : An error occured while gettings all Instrument Types.", exception);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public ActionResult GetById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    _logger.LogDebug($"[InstrumentTypeBusiness][GetById] : ID is not defined");
                    return BadRequest("Id is not defined");
                }
                _logger.LogDebug($"[InstrumentTypeBusiness][GetById] : Getting entry for id {id} in database.");
                return Ok(_instrumentTypeBusiness.GetById(id));
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentTypeController][GetById] : An error occured while getting instrument type for Id {id}.", exception);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public ActionResult GetByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    _logger.LogDebug($"[InstrumentTypeBusiness][GetByName] : Name is not defined");
                    return BadRequest("Name is not defined");
                }
                _logger.LogDebug($"[InstrumentTypeBusiness][GetByName] : Getting entry for Name {name} in database.");
                return Ok(_instrumentTypeBusiness.GetByName(name));
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentTypeController][GetByName] : An error occured while getting instrument type for Name {name}.", exception);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public ActionResult Create(string instrumentTypeName)
        {
            try
            {
                if (string.IsNullOrEmpty(instrumentTypeName))
                {
                    _logger.LogDebug($"[InstrumentTypeBusiness][Create] : instrument Type is not defined");
                    return BadRequest("Instrument type name is not defined");
                }
                _logger.LogDebug($"[InstrumentTypeBusiness][Create] : Creating entry for {instrumentTypeName} in database.");
                var result = _instrumentTypeBusiness.Create(instrumentTypeName);
                if (result == null)
                    return BadRequest("Entry could not been created, make sure that the entry is not already in database");
                return Ok("Entry has been successfully created");
            }
            catch (Exception exception)
            {
                _logger.LogError("[InstrumentTypeController][Create] : An error occured while gettings all Instrument Types.", exception);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public ActionResult Update(InstrumentType instrumentType)
        {
            try
            {
                if (instrumentType == null) 
                {
                    _logger.LogDebug($"[InstrumentTypeBusiness][Update] : instrumentType is null.");
                    return BadRequest();
                }
                if (string.IsNullOrEmpty(instrumentType.Id))
                {
                    _logger.LogDebug($"[InstrumentTypeBusiness][Update] : id is not defined in the payload.");
                    return BadRequest();
                }
                if (string.IsNullOrEmpty(instrumentType.Name))
                {
                    _logger.LogDebug($"[InstrumentTypeBusiness][Update] : Name is not defined in the payload.");
                    return BadRequest();
                }
                _logger.LogDebug($"[InstrumentTypeBusiness][Update] : updating entry in database.");
                _instrumentTypeBusiness.Update(instrumentType);
                _logger.LogDebug($"[InstrumentTypeBusiness][Update] : entry has been updated in database.");
                return Ok("Entry has been updated");
            }
            catch (Exception exception)
            {
                _logger.LogError("[InstrumentTypeController][Update] : An error occured while updating an Instrument Type.", exception);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                _logger.LogDebug($"[InstrumentTypeBusiness][Delete] : Removing entry for id {id}.");
                _instrumentTypeBusiness.Delete(id);
                return Ok($"Instrument type has been deleted for id {id}");
            }
            catch (Exception exception)
            {
                _logger.LogError("[InstrumentTypeController][Delete] : An error occured while gettings all Instrument Types.", exception);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
