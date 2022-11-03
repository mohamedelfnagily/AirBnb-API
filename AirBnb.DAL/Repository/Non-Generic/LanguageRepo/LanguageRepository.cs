using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.LanguageRepo
{
    public class LanguageRepository : BaseRepository<Language> ,ILanguageRepository
    {
        private readonly ApplicationDbContext _context;
        public LanguageRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<string> GetLanguagesNamesByIds(IEnumerable<Guid> languageIds)
        {
          IEnumerable<string> LanguagesNames = new List<string>();
          return _context.Languages.Where(e => languageIds.Contains(e.Id)).Select(e=>e.Name);
        }
    }
}
