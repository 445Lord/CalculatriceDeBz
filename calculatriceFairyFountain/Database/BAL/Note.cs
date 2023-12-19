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
    
    public class Note : BalCore
    {
        private readonly DalNote _dalNote = new DalNote();


        public List<ObjNote> GetAll()
        {
            return ParseMultiple<ObjNote>(_dalNote.GetAll());
        }

        public ObjNote GetByNum(int num)
        {
            return ParseSingle<ObjNote>(_dalNote.GetByNum(num));
        }

        public List<ObjNote> GetByEleve(ObjEleve eleve)
        {
            return ParseMultiple<ObjNote>(_dalNote.GetByEleve(eleve));
        }

        public DataResult Insert(ObjNote note)
        {
            return _dalNote.Insert(note);
        }

        public DataResult Update(ObjNote note)
        {
            return _dalNote.Update(note);
        }

        public DataResult Delete(ObjNote note)
        {
            return _dalNote.Delete(note);
        }
    }
}
