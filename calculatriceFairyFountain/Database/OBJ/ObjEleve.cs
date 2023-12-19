using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmericSqlite.conversionTypes;


namespace calculatriceFairyFountain.Database.OBJ
{
    public class ObjEleve
    {
        public int num {  get; set; }
        public int numGroupe {  get; set; }
        public string prenom {  get; set; }
        public string nom { get; set; }
        public bool estPleinTemps { get; set; }

        public ObjEleve(DataRow dr)
        {
            num = dr["num"].ToInt();
            numGroupe = dr["numGroupe"].ToInt();
            prenom = dr["prenom"].ToString();
            nom = dr["nom"].ToString();
            estPleinTemps = dr["estPleinTemps"].ToBool();
        }

        public ObjEleve() { }
        
    }
}
