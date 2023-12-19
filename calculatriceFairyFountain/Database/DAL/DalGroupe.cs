using EmericSqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Microsoft.Data.Sqlite;
using calculatriceFairyFountain.Database.OBJ;

namespace calculatriceFairyFountain.Database.DAL
{
    public class DalGroupe
    {
        public DataResult GetAll()
        {
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Groupe");
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }

        public DataResult GetByLibelle(string libelle)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Groupe WHERE libelle=@libelle");
            Program.FairyFountainOrm.AddParameters("@libelle", libelle);
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }

        public DataResult GetByEleve(ObjEleve eleve)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Groupe WHERE num=@numGroupe");
            Program.FairyFountainOrm.AddParameters("@numGroupe", eleve.numGroupe);
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }

        public DataResult GetByNum(int num)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Groupe WHERE num=@num");
            Program.FairyFountainOrm.AddParameters("@num", num);
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }



        public DataResult Insert(ObjGroupe groupe)
        {
            
            SqliteCommand sqliteCommand = new SqliteCommand("INSERT INTO Groupe(libelle) VALUES (@libelle)");
            Program.FairyFountainOrm.AddParameters("@libelle", groupe.libelle);
            return Program.FairyFountainOrm.Insert(sqliteCommand);
        }

        public DataResult Update(ObjGroupe groupe)
        {

            SqliteCommand sqliteCommand = new SqliteCommand("Update Groupe SET libelle=@libelle WHERE num=@num");
            Program.FairyFountainOrm.AddParameters("@libelle", groupe.libelle);
            Program.FairyFountainOrm.AddParameters("@num", groupe.num);
            return Program.FairyFountainOrm.Update(sqliteCommand);
        }
        public DataResult Delete(ObjGroupe groupe)
        {

            SqliteCommand sqliteCommand = new SqliteCommand("DELETE FROM Groupe WHERE num=@num");
            Program.FairyFountainOrm.AddParameters("@num", groupe.num);
            return Program.FairyFountainOrm.Delete(sqliteCommand);
        }


    }
}
