using AirBnb.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageLanguage
{
    public interface ILanguageManager
    {
        public IEnumerable<UserLanguagesDTO> GetLanguagesNamesByIds(IEnumerable<Guid> languageId);
    }
}
