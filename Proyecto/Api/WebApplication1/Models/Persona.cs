using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Persona
    {
        int IdCedula;
        string Nombre;
        string Apellido1;
        string Apellido2;
        int Telefono;
        string Contraseña;
        string Provincia;
        string Canton;
        string Distrito;
        string DescripcionDireccion;
        DateTime FechaNacimiento;

        public Persona(int id, string name, string a1, string a2, int t, string password, string p, string c, string d, string dDireccion, DateTime fNac)
        {
            this.IdCedula = id;
            this.Nombre = name;
            this.Apellido1 = a1;
            this.Apellido2 = a2;
            this.Telefono = t;
            this.Contraseña = password;
            this.Provincia = p;
            this.Canton = c;
            this.Distrito = d;
            this.DescripcionDireccion = dDireccion;
            this.FechaNacimiento = fNac;
        }

        public int idCedula {
            get { return this.IdCedula; }
            set { IdCedula = value; }
        }
        public string nombre {
            get { return this.Nombre; }
            set { Nombre = value; }
        }
        public string apellido1 {
            get { return this.Apellido1; }
            set { Apellido1 = value; }
        }
        public string apellido2 {
            get { return this.Apellido2; }
            set { Apellido2 = value; }
        }
        public int telefono {
            get { return this.Telefono; }
            set { Telefono = value; }
        }
        public string contraseña {
            get { return this.Contraseña; }
            set { Contraseña = value; }
        }
        public string provincia {
            get { return this.Provincia; }
            set { Provincia = value; }
        }
        public string canton {
            get { return this.Canton; }
            set { Canton = value; }
        }
        public string distrito {
            get { return this.Distrito; }
            set { Distrito = value; }
        }
        public string decripcionDireccion {
            get { return this.DescripcionDireccion; }
            set { DescripcionDireccion = value; }
        }
        public DateTime fechaNacimiento
        {
            get { return this.FechaNacimiento; }
            set { FechaNacimiento = value; }
        }
    }
}