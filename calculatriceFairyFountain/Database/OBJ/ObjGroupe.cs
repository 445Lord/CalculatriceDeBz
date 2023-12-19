using EmericSqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatriceFairyFountain.Database.OBJ
{
    public class ObjGroupe
    {
        public int num {  get; set; }
        public string libelle { get; set; }

        public ObjGroupe(DataRow dr)
        {
            num = dr["num"].ToInt();
            libelle = dr["libelle"].ToString();
        }

        public ObjGroupe() { }



    }
}
