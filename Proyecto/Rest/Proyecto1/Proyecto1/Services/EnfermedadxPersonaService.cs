using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Data.SqlClient;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class EnfermedadxPersonaService
    {
        public List<EnfermedadxPersona> GetAllEnfermedadxPersona()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT * from EnfermedadxPersona", conn);
            read = command.ExecuteReader();

            List<EnfermedadxPersona> ListEnfermedadxPersona = new List<EnfermedadxPersona>();
            while (read.Read())
            {
                EnfermedadxPersona enfermedadxpersona = new EnfermedadxPersona();
                enfermedadxpersona.IdCedula = Convert.ToInt32(read["IdCedula"]);
                enfermedadxpersona.IdEnfermedad = Convert.ToInt32(read["IdEnfermedad"]);
                enfermedadxpersona.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

            }
            read.Close();
            conn.Close();
            return ListEnfermedadxPersona;
        }

        public void PostEnfermedadxPersona([FromBody] EnfermedadxPersona exp)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();


            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = exp.IdCedula;

            SqlParameter IdEnfermedad = new SqlParameter("@IdEnfermedad", System.Data.SqlDbType.Bit);
            IdEnfermedad.Value = exp.IdEnfermedad;


            command = new SqlCommand("insert into EnfermedadxPersona(IdCedula,IdEnfermedad) VALUES (@IdCedula,@IdEnfermedad)", conn);
            command.Parameters.Add(IdCedula);
            command.Parameters.Add(IdEnfermedad);

            command.ExecuteNonQuery();

            conn.Close();


        }


    }
}