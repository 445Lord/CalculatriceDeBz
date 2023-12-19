using calculatriceFairyFountain.Database.OBJ;
using EmericSqlite;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatriceFairyFountain.Database.DAL
{
    public class DalNote
    {
        public DataResult GetAll()
        {
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Note");
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }

        public DataResult GetByNum(int num)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Note WHERE num=@num");
            Program.FairyFountainOrm.AddParameters("@num", num);
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }

        public DataResult GetByEleve(ObjEleve eleve)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Note WHERE numEleve=@num");
            Program.FairyFountainOrm.AddParameters("@num", eleve.num);
            return Program.FairyFountainOrm.Select(sqliteCommand);
        }

        public DataResult Insert(ObjNote note)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("INSERT INTO Note (numEleve, note, dateEvaluation) VALUES (@numEleve, @note, @dateEvaluation)");
            Program.FairyFountainOrm.AddParameters("@numEleve", note.numEleve);
            Program.FairyFountainOrm.AddParameters("@note", note.note);
            Program.FairyFountainOrm.AddParameters("@dateEvaluation", note.dateEvaluation);
            return Program.FairyFountainOrm.Insert(sqliteCommand);
        }
        public DataResult Update(ObjNote note)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("UPDATE Note SET numEleve=@numEleve, note=@note, dateEvaluation=@dateEvaluation WHERE num=@num");
            Program.FairyFountainOrm.AddParameters("@numEleve", note.numEleve);
            Program.FairyFountainOrm.AddParameters("@note", note.note);
            Program.FairyFountainOrm.AddParameters("@dateEvaluation", note.dateEvaluation);
            Program.FairyFountainOrm.AddParameters("@num", note.num);
            return Program.FairyFountainOrm.Update(sqliteCommand);
        }

        public DataResult Delete(ObjNote note)
        {
            SqliteCommand sqliteCommand = new SqliteCommand("DELETE FROM Note WHERE num=@num");
            Program.FairyFountainOrm.AddParameters("@num", note.num);
            return Program.FairyFountainOrm.Delete(sqliteCommand);
        }


    }
}
