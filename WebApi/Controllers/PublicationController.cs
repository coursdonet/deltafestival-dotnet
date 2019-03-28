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
    public class PublicationController : ControllerBase
    {

        //private readonly DeltaDbContext _context;
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUserRepository _userRepository;


        public PublicationController(IPublicationRepository publicationRepository, IUserRepository userRepository)
        {
            _publicationRepository = publicationRepository;
            _userRepository = userRepository;
        }

        // GET all list of publication
        [HttpGet]
        public List<Publication> GetAll()
        {
            Bouchons b = new Bouchons();
            return b.GetAllBouchonPublication();

            /* A décommenter pour mettre en prod */
            //return _publicationRepository.GetAll().ToList();
        }

        // GET publication by id
        [HttpGet("{id}")]
        public Publication Get(int id)
        {
            return _publicationRepository.FindBy(c => c.Id == id).FirstOrDefault();
        }

        // TODO : Fonctionnalité de like de publication

        // Insert publication
        [HttpPost]
        public bool Post(Publication publication)
        {
            User user = _userRepository.FindBy(x => x.Id == publication.UserId).FirstOrDefault();
            try
            {
                _publicationRepository.Add(publication);
                _publicationRepository.Save();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        // Edit publication
        [HttpPut("{id}")]
        public bool Put(Publication publication)
        {
            try
            {
                Publication olderPublication = _publicationRepository.FindBy(c => c.Id == publication.Id).FirstOrDefault();

                #region Edit properties
                olderPublication.UserId = publication.UserId;
                olderPublication.Content = publication.Content;
                olderPublication.IsCoupDeCoeur = publication.IsCoupDeCoeur;
                olderPublication.Hashtag = publication.Hashtag;
                olderPublication.File = publication.File;
                olderPublication.Date = publication.Date;
                #endregion

                _publicationRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        // DELETE publication by id
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                Publication publication = _publicationRepository.FindBy(c => c.Id == id).FirstOrDefault();
                _publicationRepository.Delete(publication);
                _publicationRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }
    }
}
