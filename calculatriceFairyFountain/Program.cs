using calculatriceFairyFountain.Database;
using calculatriceFairyFountain.Database.BAL;
using calculatriceFairyFountain.Database.OBJ;
using EmericSqlite;
using System.Configuration;
using System.Net.Http.Headers;

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
            bool isClosing = false;
           while (!isClosing)
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Menu princpal programme de gestion des notes");
                Console.WriteLine("Pour ajouter un groupe taper 1");
                Console.WriteLine("Pour ajouter un �l�ve taper 2");
                Console.WriteLine("Pour ajouter une note taper 3");
                Console.WriteLine("Pour connaitre la moyenne d'un �l�ve taper 4");
                Console.WriteLine("Pour la Gestion des �l�ves taper 5");
                Console.WriteLine("Pour la Gestion des groupes taper 6");
                Console.WriteLine("Pour Quitter le programme taper 7");
                Console.Write("Entrez votre choix : ");
                int iChoix = Console.ReadLine().ToInt();
                switch (iChoix)
                {
                    case 1:
                        ajouterGroupe();
                        break;
                    case 2:
                        ajouterELeve();
                        break;
                    case 3:
                        ajouterNote();
                        break;
                    case 4:
                        afficherMoyenne();
                        break;
                    case 5:
                        gestionEleve();
                        break;
                    case 6:
                        gestionGroupe();
                        break;
                    case 7:
                        isClosing = true;
                        break;
                    default:
                        Console.WriteLine("Choix incorrect");
                        break;
                }


                
           }

           void ajouterGroupe()
           {
                
                try
                {
                    ObjGroupe nouveauGroupe = new ObjGroupe();
                    Console.Write("Veuillez renseigner le libelle du nouveau groupe : ");
                    nouveauGroupe.libelle = Console.ReadLine();
                    DataContext.Groupe.Insert(nouveauGroupe);
                    Console.WriteLine("Groupe ajout� !");
                }catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'ajout du groupe");
                }
           }
           void ajouterELeve()
            {
          
                try
                {
                    ObjEleve nouveauEleve = new ObjEleve();
                    Console.Write(" Veuillez renseigner le nom : ");
                    nouveauEleve.nom = Console.ReadLine();
                    Console.Write(" Veuillez renseigner le prenom : ");
                    nouveauEleve.prenom = Console.ReadLine();
                    Console.Write(" L'�l�ve est t'il a plein temps ? (0=non et 1=oui) : ");
                    if(Console.ReadLine().ToInt() == 1)
                    {
                        nouveauEleve.estPleinTemps = true;
                    }
                    else
                    {
                        nouveauEleve.estPleinTemps= false;
                    }
                    List<ObjGroupe> groupes = DataContext.Groupe.GetAll();
                    foreach(ObjGroupe groupe in groupes)
                    {
                        Console.WriteLine(groupe.num +" | "+groupe.libelle);
                    }
                    Console.Write("De quel groupe est t'il membre ? (veuillez renseigner le numero) : ");
                    nouveauEleve.numGroupe = Console.ReadLine().ToInt();
                    DataContext.Eleve.Insert(nouveauEleve);
                    Console.WriteLine("El�ve ajout�");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'ajout de l'�l�ve");
                }
            }
            void ajouterNote()
            {
                try
                {
                    ObjNote nouvelleNote = new ObjNote();
                    List<ObjEleve> eleves = DataContext.Eleve.GetAll();
                    foreach (ObjEleve eleve in eleves)
                    {
                        ObjGroupe groupe = DataContext.Groupe.GetByNum(eleve.numGroupe);
                        Console.WriteLine(eleve.num + " | " + eleve.nom + " " + eleve.prenom + " | " + groupe.libelle);
                    }
                    Console.Write("A quel �l�ve voulez ajouter la note ? (veuillez renseigner le num�ro) : ");
                    nouvelleNote.numEleve = Console.ReadLine().ToInt();
                   
                    int note;
                    do
                    {
                        Console.Write("veuillez renseigner la note (1-6) : ");
                        note = Console.ReadLine().ToInt();
                    } while (note > 6 || note < 1);
                    nouvelleNote.note = note;
                    nouvelleNote.dateEvaluation = DateTime.Now;
                    DataContext.Note.Insert(nouvelleNote);
                    Console.WriteLine("Note ajout�e");
                }catch(Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'ajout de la note");
                }
                
               
            }
            void afficherMoyenne()
            {
                try
                {
                    List<ObjEleve> eleves = DataContext.Eleve.GetAll();
                    foreach (ObjEleve eleve in eleves)
                    {
                        ObjGroupe groupe = DataContext.Groupe.GetByNum(eleve.numGroupe);
                        Console.WriteLine(eleve.num + " | " + eleve.nom + " " + eleve.prenom + " | " + groupe.libelle);
                    }
                    Console.Write("Quel est l'�l�ve dont vous voulez conna�tre la moyenne ? (veuillez renseigner le num�ro) : ");
                    ObjEleve eleveMoyenne = DataContext.Eleve.GetByNum(Console.ReadLine().ToInt());
                    List<ObjNote> notes = DataContext.Note.GetByEleve(eleveMoyenne);
                    double moyenne = 0;
                    foreach (ObjNote note in notes) { 
                        Console.WriteLine(note.note + " | " + note.dateEvaluation.Day + "." + note.dateEvaluation.Month + "." + note.dateEvaluation.Year);
                        moyenne += note.note;
                    }
                    Console.WriteLine("moyenne : " + moyenne/notes.Count); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors du calcul de la moyenne");
                }
            }

            void gestionEleve()
            {
                try
                {
                    List<ObjEleve> eleves = DataContext.Eleve.GetAll();
                    foreach (ObjEleve eleve in eleves)
                    {
                        ObjGroupe groupe = DataContext.Groupe.GetByNum(eleve.numGroupe);
                        Console.WriteLine(eleve.num + " | " + eleve.nom + " " + eleve.prenom + " | " + groupe.libelle);
                    }
                    Console.WriteLine("taper 1 pour modifier un �l�ve");
                    Console.WriteLine("taper 2 pour supprimer un �l�ve");
                    Console.WriteLine("taper 3 ou autre pour quitter");
                    Console.Write("veuillez renseigner votre choix : ");
                    int iChoix = Console.ReadLine().ToInt();
                    switch (iChoix)
                    {
                        case 1:
                            Console.Write("Quel El�ve voulez vous modifier (veuillez renseigner le num�ro) : ");
                            ObjEleve eleve = DataContext.Eleve.GetByNum(Console.ReadLine().ToInt());
                            Console.Write("Veuillez renseigner le nom : ");
                            eleve.nom = Console.ReadLine();
                            Console.Write("Veuillez renseigner le prenom : ");
                            eleve.prenom = Console.ReadLine();
                            Console.Write(" L'�l�ve est t'il a plein temps ? (0=non et 1=oui) : ");
                            if (Console.ReadLine().ToInt() == 1)
                            {
                                eleve.estPleinTemps = true;
                            }
                            else
                            {
                                eleve.estPleinTemps = false;
                            }
                            List<ObjGroupe> groupes = DataContext.Groupe.GetAll();
                            foreach (ObjGroupe groupe in groupes)
                            {
                                Console.WriteLine(groupe.num + " | " + groupe.libelle);
                            }
                            Console.Write("De quel groupe est t'il membre ? (veuillez renseigner le numero) : ");
                            eleve.numGroupe = Console.ReadLine().ToInt();
                            DataContext.Eleve.Update(eleve);
                            Console.WriteLine("El�ve modifi�");
                            break;
                        case 2:
                            Console.WriteLine("Quel El�ve voulez vous supprimer (veuillez renseigner le num�ro) : ");
                            ObjEleve eleve1 = DataContext.Eleve.GetByNum(Console.ReadLine().ToInt());
                            DataContext.Eleve.Delete(eleve1);
                            Console.WriteLine("El�ve supprim�");
                            break;
                        default:
                            Console.WriteLine("Menu de gestion quitt�");
                            break;
                    }



                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la gestion d'�l�ves");
                }
            }

            void gestionGroupe()
            {
                try
                {
                    List<ObjGroupe> groupes = DataContext.Groupe.GetAll();
                    foreach (ObjGroupe groupe in groupes)
                    {
                        Console.WriteLine(groupe.num + " | " + groupe.libelle);
                    }
                    Console.WriteLine("taper 1 pour modifier un groupe");
                    Console.WriteLine("taper 2 pour supprimer un groupe");
                    Console.WriteLine("taper 3 ou autre pour quitter");
                    Console.Write("veuillez renseigner votre choix : ");
                    int iChoix = Console.ReadLine().ToInt();
                    switch(iChoix)
                    {
                        case 1:
                            Console.WriteLine("Quel groupe voulez vous modifier (veuillez renseigner le num�ro) : ");
                            ObjGroupe groupe = DataContext.Groupe.GetByNum(Console.ReadLine().ToInt());
                            Console.Write("Veuillez renseigner le libelle : ");
                            groupe.libelle = Console.ReadLine();
                            DataContext.Groupe.Update(groupe);
                            Console.WriteLine("groupe modifi�");
                            break;
                        case 2:
                            Console.WriteLine("Quel groupe voulez vous supprimer (veuillez renseigner le num�ro) : ");
                            ObjGroupe eleve1 = DataContext.Groupe.GetByNum(Console.ReadLine().ToInt());
                            DataContext.Groupe.Delete(eleve1);
                            Console.WriteLine("Groupe supprim�");
                            break;
                        default:
                            Console.WriteLine("Menu de gestion quitt�");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la gestion des groupes");
                }
            }
        }
    }
}