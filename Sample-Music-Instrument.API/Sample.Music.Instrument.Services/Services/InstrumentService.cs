using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Sample.Music.Instrument.Services.Interfaces;
using Sample_Music_Instrument.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Music.Instrument.Services.Services
{
    public class InstrumentService : IInstrumentTypeService
    {
        private readonly IMongoCollection<InstrumentType> _collection;
        private readonly ILogger<InstrumentService> _logger;

        public InstrumentService(IInstrumentTypeSettings settings, IMongoClient mongoClient, ILogger<InstrumentService> logger)
        {
            var currentDatase = mongoClient.GetDatabase(settings.DatabaseName);
            _collection = currentDatase.GetCollection<InstrumentType>(settings.InstrumentTypeCollection);
            _logger = logger;
        }

        public InstrumentType Create(InstrumentType instrument)
        {
            try
            {
                _collection.InsertOne(instrument);
                return GetByName(instrument.Name);
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentService][Create] : An error occured while creating new instrument Type. {exception}");
                throw exception;
            }
        }

        public void Delete(string id)
        {
            try
            {
                _collection.DeleteOne(instrument => instrument.Id == id);
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentService][Delete] : An error occured while removing instrument Type with id {id}. {exception}");
                throw exception;
            }
        }

        public void Update(InstrumentType instrument)
        {
            try
            {
                _collection.ReplaceOne(instrumentToReplace => instrumentToReplace.Id == instrument.Id, instrument);
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentService][Update] : An error occured while updating instrument Type {instrument.Id} with {instrument.Name}. {exception}");
                throw exception;
            }
        }

        public List<InstrumentType> Get()
        {
            try
            {
                return _collection.Find<InstrumentType>(instrumentToFind => true).ToList();
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentService][Get] : An error occured while getting all instrument Type. {exception}");
                throw exception;
            }
        }

        public InstrumentType GetById(string id)
        {
            try
            {
                return _collection.Find<InstrumentType>(instrumentToFind => instrumentToFind.Id == id).FirstOrDefault();
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentService][GetById] : An error occured while getting instrument Type with id {id}. {exception}");
                throw exception;
            }
        }

        public InstrumentType GetByName(string name)
        {
            try
            {
                return _collection.Find<InstrumentType>(instrumentToFind => instrumentToFind.Name == name).FirstOrDefault();
            }
            catch (Exception exception)
            {
                _logger.LogError($"[InstrumentService][GetByName] : An error occured while getting instrument Type with name {name}. {exception}");
                throw exception;
            }
        }
    }
}
