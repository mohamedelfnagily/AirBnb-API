using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.LanguageRepo
{
    public interface ILanguageRepository : IBaseRepository<Language>
    {
        IEnumerable<string> GetLanguagesNamesByIds(IEnumerable<Guid> languageIds);
    }
}
