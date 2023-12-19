using EmericSqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatriceFairyFountain.Database.OBJ
{
    public class ObjNote
    {
        public int num {  get; set; }
        public int numEleve { get; set; }
        public double note {  get; set; }
        public DateTime dateEvaluation { get; set; }

        public ObjNote(DataRow dr) 
        {
            num = dr["num"].ToInt();
            numEleve = dr["numEleve"].ToInt();
            note = dr["note"].ToDouble();
            dateEvaluation = dr["dateEvaluation"].ToDateTime();
        }

        public ObjNote() { }

    }
}
