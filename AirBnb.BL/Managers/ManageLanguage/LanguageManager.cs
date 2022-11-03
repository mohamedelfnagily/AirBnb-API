using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.DAL.Repository.Non_Generic.LanguageRepo;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageLanguage
{
    public class LanguageManager : ILanguageManager
    {
        private readonly ILanguageRepository _languageRepository;
   
        public LanguageManager(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public IEnumerable<UserLanguagesDTO> GetLanguagesNamesByIds(IEnumerable<Guid> languageId)
        {
           var LanguagesNames = _languageRepository.GetLanguagesNamesByIds(languageId);
            List<UserLanguagesDTO> userLanguages = new List<UserLanguagesDTO>();
            foreach(string name in LanguagesNames)
            {
                userLanguages.Add(new UserLanguagesDTO { Name=name});
            }

           return userLanguages;
           
        }
    }
}
