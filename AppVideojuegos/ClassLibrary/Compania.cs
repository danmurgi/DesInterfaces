using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Compania
    {
        //Atributos
        public string nombreComp { get; set; }
        public string fechaIni { get; set; }
        public string numTrab { get; set; }

        public Compania(string nombreComp, string fechaIni, string numTrab) {
            this.nombreComp = nombreComp;
            this.fechaIni = fechaIni;
            this.numTrab = numTrab;
        }

    }
}
