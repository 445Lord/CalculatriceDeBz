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
    public class Groupe : BalCore
    {
        private readonly DalGroupe _dalGroupe = new DalGroupe();

        public List<ObjGroupe> GetAll()
        {
            return ParseMultiple<ObjGroupe>(_dalGroupe.GetAll());
        }

        public ObjGroupe GetByLibelle(string libelle)
        {
            return ParseSingle<ObjGroupe>(_dalGroupe.GetByLibelle(libelle));
        }

        public ObjGroupe GetByNum(int num)
        {
            return ParseSingle<ObjGroupe>(_dalGroupe.GetByNum(num));
        }

        public ObjGroupe GetByEleve(ObjEleve eleve)
        {
            return ParseSingle<ObjGroupe>(_dalGroupe.GetByEleve(eleve));
        }

        public DataResult Insert(ObjGroupe groupe)
        {
            
            return _dalGroupe.Insert(groupe);
            
        }

        public DataResult Update(ObjGroupe groupe)
        {
            return _dalGroupe.Update(groupe);
        }

        public DataResult Delete(ObjGroupe groupe)
        {
            return _dalGroupe.Delete(groupe);
        }
    }
}
