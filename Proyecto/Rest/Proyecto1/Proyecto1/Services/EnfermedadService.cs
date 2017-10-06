﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
namespace Proyecto1.Services
{
    public class EnfermedadService
    {
        public List<Enfermedad> GetAllEnfermedades() {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Farmacia;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Enfermedad", conn);
            read = command.ExecuteReader();
            List<Enfermedad> enfermedades = new List<Enfermedad>();
            while (read.Read())
            {
                Enfermedad enfermedad = new Enfermedad();
                enfermedad.IdEnfermedad = Convert.ToInt32(read["IdEnfermedad"]);
                enfermedad.Nombre = read["Nombre"].ToString();
                enfermedades.Add(enfermedad);

            }
            return enfermedades;
        }
        public void PostEnfermedad([FromBody] Enfermedad enfermedad)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            
            command = new SqlCommand("insert  Enfermedad(Nombre) VALUES (@Nombre)", conn);
            
            command.Parameters.AddWithValue("@Nombre", enfermedad.Nombre);
            command.ExecuteNonQuery();

            conn.Close();

        }
    }
}