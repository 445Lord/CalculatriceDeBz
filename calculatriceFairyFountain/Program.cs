using calculatriceFairyFountain.Database;
using calculatriceFairyFountain.Database.BAL;
using calculatriceFairyFountain.Database.OBJ;
using EmericSqlite;

namespace calculatriceFairyFountain
{
   
    internal static class Program
    {
        public static ORM FairyFountainOrm = new ORM("Calculatrice.db.sqlite");
        public static DataContext DataContext = new DataContext();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
       
            
            
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            
        }
    }
}