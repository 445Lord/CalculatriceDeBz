using calculatriceFairyFountain.Database.DAL;
using calculatriceFairyFountain.Database.OBJ;
using EmericSqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatriceFairyFountain.Database.BAL
{
    public class Eleve : BalCore
    {
        private readonly DalEleve _dalEleve = new DalEleve();
        public List<ObjEleve> GetAll()
        {
            return ParseMultiple<ObjEleve>(_dalEleve.GetAll());
        }

        public ObjEleve GetByNum(int num)
        {
            return ParseSingle<ObjEleve>(_dalEleve.GetByNum(num));
        }

        public List<ObjEleve> GetByGroupe(ObjGroupe groupe)
        {
            return ParseMultiple<ObjEleve>(_dalEleve.GetByGroupe(groupe));
        }


        public DataResult Insert(ObjEleve objEleve)
        {
            return _dalEleve.Insert(objEleve);
        }

        public DataResult Update(ObjEleve objEleve)
        {
            return _dalEleve.Update(objEleve);
        }

        public DataResult Delete(ObjEleve objEleve)
        {
            return _dalEleve.Delete(objEleve);
        }
    }
}
