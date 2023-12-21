using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Logging;
using Sample.Music.Instrument.Services.Interfaces;
using Sample_Music_Instrument.Business.Interfaces;
using Sample_Music_Instrument.Models;
using System;

namespace Sample_Music_Instrument.Business.Businesses
{
    public  class InstrumentTypeBusiness : IInstrumentTypeBusiness
    {
        private readonly IInstrumentTypeService _instrumentTypeService;
        private readonly ILogger<InstrumentTypeBusiness> _logger;

        public InstrumentTypeBusiness(IInstrumentTypeService instrumentTypeService, ILogger<InstrumentTypeBusiness> logger)
        {
            _instrumentTypeService = instrumentTypeService;
            _logger = logger;
        }

        public List<InstrumentType> Get()
        {
            try
            {
                return _instrumentTypeService.Get();
            }
            catch (Exception exception)
            {
                _logger.LogError("[InstrumentTypeBusiness][Get] : An error occured while gettings all Instrument Types.", exception);
                throw exception;
            }
        }

        public List<string> GetAllTypes()
        {
            try
            {
                var instrumentTypes = Get();
                if (instrumentTypes != null)
                    return instrumentTypes.Select(x => x.Name).ToList();
                _logger.LogWarning("[InstrumentTypeBusiness][GetAllTypes] : No instrument types found.");
                return null;
            }
            catch (Exception exception)
            {
                _logger.LogError("[InstrumentTypeBusiness][GetAllTypes] : An error occured while gettings all Instrument Types.", exception);
                throw exception;
            }
        }

        public InstrumentType GetById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException("id");
                }
                return _instrumentTypeService.GetById(id);
            }
            catch (Exception exception)
            {
                _logger.LogError("[InstrumentTypeBusiness][] : An error occured while ", exception);
                throw exception;
            }
        }

        public InstrumentType GetByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException(nameof(name));
                }
                return _instrumentTypeService.GetByName(name);
            }
            catch (Exception exception)
            {
                _logger.LogError("[InstrumentTypeBusiness][] : An error occured while ", exception);
                throw exception;
            }
        }

        public InstrumentType Create(string instrumentTypeName)
        {
            try
            {
                if (string.IsNullOrEmpty(instrumentTypeName))
                {
                    throw new ArgumentNullException(nameof(instrumentTypeName));
                }
                if (GetByName(instrumentTypeName) == null)
                {
                    _logger.LogDebug($"[InstrumentTypeBusiness][Create] : Creating entry for with value {instrumentTypeName}.");
                    var createdInstrumentTypeName = _instrumentTypeService.Create(new InstrumentType { Name = instrumentTypeName });
                    _logger.LogDebug($"[InstrumentTypeBusiness][Create] : An entry has been created for the value {createdInstrumentTypeName.Name}. Id is {createdInstrumentTypeName.Id}.");
                    return createdInstrumentTypeName;
                }
                _logger.LogWarning($"[InstrumentTypeBusiness][Create] : Instrument Type was not created, there is already one entry for the name {instrumentTypeName}.");
                return null;
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentTypeBusiness][Create] : An error occured while creating new Instrument Type for value {instrumentTypeName}. {exception}", exception);
                throw exception;
            }
        }

        public void Update(InstrumentType instrumentType)
        {
            try
            {

                if (instrumentType == null)
                {
                    throw new ArgumentNullException(nameof(instrumentType));
                }
                _logger.LogDebug($"[InstrumentTypeBusiness][Update] : Updating entry for id {instrumentType.Id} with value {instrumentType.Name}.");
                _instrumentTypeService.Update(instrumentType);
                _logger.LogDebug($"[InstrumentTypeBusiness][Update] : Entry has been updated for id {instrumentType.Id} with value {instrumentType.Name}.");
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentTypeBusiness][Update] : An error occured while updating Instrument type {instrumentType.Id} with value {instrumentType.Name}. {exception}", exception);
                throw exception;
            }
        }

        public void Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException("id");
                }
                _logger.LogDebug($"[InstrumentTypeBusiness][Delete] : Removing entry for id {id}.");
                _instrumentTypeService.Delete(id);
                _logger.LogDebug($"[InstrumentTypeBusiness][Delete] : Entry has been removed for id {id}.");
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentTypeBusiness][Delete] : An error occured while removing type by id {id}. {exception}", exception);
                throw exception;
            }
        }
    }
}
