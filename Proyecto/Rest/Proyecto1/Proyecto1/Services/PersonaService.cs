using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class PersonaService
    {
        public List<Persona> GetAllPersonas()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;
            

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Persona", conn);
            read = command.ExecuteReader();

            List<Persona> ListPersonas = new List<Persona>();
            while (read.Read())
            {
                Persona persona = new Persona();
               // persona.IdCedula = Convert.ToInt32(read["IdCedula"]);
                persona.Nombre = read["Nombre"].ToString();
                //persona.Apellido1 = read["Apellido1"].ToString();

                ListPersonas.Add(persona);
                
            }
            read.Close();
            conn.Close();
            return ListPersonas;
        }

        public void PostPersona([FromBody] Persona persona)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            


            //string insert = @"insert into Persona(Nombre,Apellido,Salario) VALUES ('Abuela','Varas',130000)";

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Test;Integrated Security=True");
            conn.Open();

            SqlParameter Nombre = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
            Nombre.Value = persona.Nombre;

            SqlParameter Apellido = new SqlParameter("@Apellido", System.Data.SqlDbType.VarChar);
            Apellido.Value = persona.Apellido;

            SqlParameter Salario = new SqlParameter("@Salario", System.Data.SqlDbType.Int);
            Salario.Value = persona.Salario;

            //persona.IdCedula.ToString() + "," + persona.Nombre.ToString() + "," + persona.Apellido1.ToString();
            command = new SqlCommand("insert into Persona(Nombre,Apellido,Salario) VALUES (@Nombre,@Apellido,@Salario)", conn);
            command.Parameters.Add(Nombre);
            command.Parameters.Add(Apellido);
            command.Parameters.Add(Salario);

            command.ExecuteNonQuery();                   
            
            conn.Close();
            
        }
    }
}