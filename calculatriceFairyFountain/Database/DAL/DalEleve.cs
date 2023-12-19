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
    public class DalEleve
    {
        public DataResult GetAll()
        {
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Eleve");
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }


        public DataResult GetByNum(int num)
        {              
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Eleve WHERE num=@num");
            Program.FairyFountainOrm.AddParameters("@num", num);
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }

        public DataResult GetByGroupe(ObjGroupe groupe)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Eleve WHERE numGroupe=@num");
            Program.FairyFountainOrm.AddParameters("@num", groupe.num);
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }

        public DataResult Insert(ObjEleve eleve)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("INSERT INTO Eleve (numGroupe, prenom, nom, estPleinTemps) VALUES (@numGroupe, @prenom, @nom, @estPleinTemps)");
            Program.FairyFountainOrm.AddParameters("@numGroupe", eleve.numGroupe);
            Program.FairyFountainOrm.AddParameters("@prenom", eleve.prenom);
            Program.FairyFountainOrm.AddParameters("@nom", eleve.nom);
            Program.FairyFountainOrm.AddParameters("@estPleinTemps", eleve.estPleinTemps);
            return Program.FairyFountainOrm.Insert(sqliteCommand);
        }  
        public DataResult Update(ObjEleve eleve)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("UPDATE Eleve SET numGroupe=@numGroupe, prenom=@prenom, nom=@nom, estPleinTemps=@estPleinTemps WHERE num=@num");
            Program.FairyFountainOrm.AddParameters("@numGroupe", eleve.numGroupe);
            Program.FairyFountainOrm.AddParameters("@prenom", eleve.prenom);
            Program.FairyFountainOrm.AddParameters("@nom", eleve.nom);
            Program.FairyFountainOrm.AddParameters("@estPleinTemps", eleve.estPleinTemps);
            Program.FairyFountainOrm.AddParameters("@num", eleve.num);
            return Program.FairyFountainOrm.Insert(sqliteCommand);
        }

        public DataResult Delete(ObjEleve eleve)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("DELETE FROM Eleve WHERE num=@num");
            Program.FairyFountainOrm.AddParameters("@num", eleve.num);
            return Program.FairyFountainOrm.Delete(sqliteCommand);
        }





    }
}
