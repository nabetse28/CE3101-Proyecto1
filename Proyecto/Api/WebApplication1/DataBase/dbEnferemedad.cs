using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DataBase
{
    public class dbEnferemedad
    {
        public List<Enfermedad> getEnfermedades()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;
            Enfermedad tmpE;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Farmacia;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Enfermedad", conn);
            read = command.ExecuteReader();

            List<Enfermedad> enfermedades = new List<Enfermedad>();
            while (read.Read())
            {
                tmpE = new Enfermedad(read.GetString(1), read.GetInt32(0));
                enfermedades.Add(tmpE);
            }
            read.Close();
            conn.Close();
            return enfermedades;
        }
    }
}