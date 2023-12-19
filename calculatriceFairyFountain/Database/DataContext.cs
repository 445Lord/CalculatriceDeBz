using calculatriceFairyFountain.Database.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatriceFairyFountain.Database
{
    public class DataContext
    {
        private Groupe _groupe;
        private Eleve _eleve;
        private Note _note;
        public Groupe Groupe 
        { 
            get
            {
                if (_groupe == null)
                {
                    _groupe = new Groupe();
                }
                return _groupe;
            }     
        }

        public Eleve Eleve 
        { 
            get
            {
                if( _eleve == null)
                {
                    _eleve = new Eleve();
                }
                return _eleve;
            } 
        }
        public Note Note
        {
            get
            {
                if( _note == null)
                {
                    _note = new Note();
                }
                return _note;
            }
        }

    }
}
