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
            // On utilise des données bouchons pour faciliter le développement
            Bouchons b = new Bouchons();
            // Remonter les publications "likés" en premier et trier par date
            return b.GetAllBouchonPublication().OrderBy(x => x.Date).OrderBy(x => x.IsCoupDeCoeur).ToList();

            /* A décommenter pour mettre en prod */
            // Remonter les publications "likés" en premier et trier par date
            //return _publicationRepository.GetAll().OrderBy(x => x.Date).OrderBy(x => x.IsCoupDeCoeur).ToList();


        }

        // GET publication by id
        [HttpGet("{id}")]
        public Publication Get(int id)
        {
            return _publicationRepository.FindBy(c => c.Id == id).FirstOrDefault();
        }

        

        // Insert publication
        [HttpPost]
        public bool Post(Publication publication)
        {
            User user = _userRepository.FindBy(x => x.Id == publication.UserId).FirstOrDefault();
            try
            {
                // Vérification d'ajout de publication toutes les 10min
                if(user.CanPublish == true) {
                    _publicationRepository.Add(publication);
                    _publicationRepository.Save();
                } else
                {
                    return false;
                }
                
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
