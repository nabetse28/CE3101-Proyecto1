using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class Persona
    {
        public int IdCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Telefono { get; set; }
        public string Contraseña { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string DescripcionDireccion { get; set; }
<<<<<<< HEAD
        public string FechaNacimiento { get; set; }

=======
        public DateTime FechaNacimiento { get; set; }

        /*public int idCedula
        {
            get { return this.IdCedula; }
            set { IdCedula = value; }
        }
        public string nombre
        {
            get { return this.Nombre; }
            set { Nombre = value; }
        }
        public string apellido1
        {
            get { return this.Apellido1; }
            set { Apellido1 = value; }
        }
        public string apellido2
        {
            get { return this.Apellido2; }
            set { Apellido2 = value; }
        }
        public int telefono
        {
            get { return this.Telefono; }
            set { Telefono = value; }
        }
        public string contraseña
        {
            get { return this.Contraseña; }
            set { Contraseña = value; }
        }
        public string provincia
        {
            get { return this.Provincia; }
            set { Provincia = value; }
        }
        public string canton
        {
            get { return this.Canton; }
            set { Canton = value; }
        }
        public string distrito
        {
            get { return this.Distrito; }
            set { Distrito = value; }
        }
        public string decripcionDireccion
        {
            get { return this.DescripcionDireccion; }
            set { DescripcionDireccion = value; }
        }
        public string fechaNacimiento
        {
            get { return this.FechaNacimiento; }
            set { FechaNacimiento = value; }
        }*/
>>>>>>> 4bbda2e463e7e00f0fb0cc0fcec04b46bb65f7f0
    }
}