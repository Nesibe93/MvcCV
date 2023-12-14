using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCV.Repositories
{
    public class DeneyimRepository : GenericRepository<TblDeneyimlerim>
    {
        DbCVEntities db = new DbCVEntities();
        public List<TblDeneyimlerim> List()
        {
            return db.TblDeneyimlerim.ToList();
        }
        
    }
}