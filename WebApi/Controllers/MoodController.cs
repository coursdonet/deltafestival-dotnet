using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaFestival.IRepository;
using DeltaFestival.Models;
using DeltaFestivalAPI.Transverse;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeltaFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodController : ControllerBase
    {
        //private readonly DeltaDbContext _context;
        private readonly IMoodRepository _moodRepository;

        public MoodController(IMoodRepository moodRepository)
        {
            _moodRepository = moodRepository;
        }
                
        // GET api/values
        [HttpGet]
        public List<Mood> GetAll()
        {

            //Données bouchons
            Bouchons b = new Bouchons();
            return b.GetAllBouchonMood();

            /* A décommenter pour mettre en prod */
            //return _moodRepository.GetAll().ToList();
        }

        // Get a Mood by Id
        [HttpGet("{id}")]
        public ActionResult<Mood> Get(int id)
        {
            return _moodRepository.FindBy(c => c.Id == id).FirstOrDefault();

        }

        // Add a Mood
        [HttpPost]
        public bool Post(Mood mood)
        {
            try
            {
                _moodRepository.Add(mood);
                _moodRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        // Update Mood
        [HttpPut("{id}")]
        public bool Put(Mood mood)
        {
            try
            {
                Mood olderMood = _moodRepository.FindBy(c => c.Id == mood.Id).FirstOrDefault();

                #region Edit properties
                olderMood.Label = mood.Label;
                #endregion

                _moodRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        // DELETE Mood
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Mood currentMood = _moodRepository.FindBy(c => c.Id == id).FirstOrDefault();
            _moodRepository.Delete(currentMood);
            _moodRepository.Save();
        }
    }
}
