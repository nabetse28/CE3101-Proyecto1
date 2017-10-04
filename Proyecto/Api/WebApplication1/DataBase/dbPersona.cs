using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DataBase
{
    public class dbPersona
    {
        public List<Persona> getPersonas()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;
            Persona tmpP;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Farmacia;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Persona", conn);
            read = command.ExecuteReader();

            List<Persona> personas = new List<Persona>();
            while (read.Read())
            {
                tmpP = new Persona(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3),
                    read.GetInt32(4),read.GetString(5), read.GetString(6), read.GetString(7), read.GetString(8), 
                    read.GetString(9), read.GetDateTime(10));
                personas.Add(tmpP);
            }
            read.Close();
            conn.Close();
            return personas;
        }
    }
}