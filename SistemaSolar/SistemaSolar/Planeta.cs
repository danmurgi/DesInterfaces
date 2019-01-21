using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSolar
{
    public class Planeta
    {
        public string Nombre { get; set; }
        public double Diametro { get; set; }
        public double DistanciaSol { get; set; }
        public string Imagen { get; set; }
    }

    public class GestorPlanetas
    {
        public static List<Planeta> GetPlanetas()
        {
            return new List<Planeta>
            {
                new Planeta() {Nombre="Mercurio", Diametro=16, DistanciaSol=140, Imagen = "Assets/Planetas/mercurio.png"},
                new Planeta() {Nombre="Venus", Diametro=30, DistanciaSol=190, Imagen = "Assets/Planetas/venus.png"},
                new Planeta() {Nombre="Tierra", Diametro=36, DistanciaSol=240, Imagen = "Assets/Planetas/tierra.png"},
                new Planeta() {Nombre="Marte", Diametro=20, DistanciaSol=290, Imagen = "Assets/Planetas/marte.png"},
                new Planeta() {Nombre="Júpiter", Diametro=90, DistanciaSol=420, Imagen = "Assets/Planetas/jupiter.png"},
                new Planeta() {Nombre="Saturno", Diametro=80, DistanciaSol=490, Imagen = "Assets/Planetas/saturno.png"},
                new Planeta() {Nombre="Urano", Diametro=46, DistanciaSol=570, Imagen = "Assets/Planetas/urano.jpg"},
                new Planeta() {Nombre="Neptuno", Diametro=46, DistanciaSol=660, Imagen = "Assets/Planetas/neptuno.png"}
            };
        }
    }
}
