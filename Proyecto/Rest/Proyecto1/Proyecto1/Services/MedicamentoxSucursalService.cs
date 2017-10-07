using Proyecto1.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class MedicamentoxSucursalService
    {
        public List<MedicamentoxSucursal> GetAllMedicamentoxSucursal()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT * from MedicamentoxSucursal where LogicDelete = 0", conn);
            read = command.ExecuteReader();
            List<MedicamentoxSucursal> ListMedicamentoxSucursal = new List<MedicamentoxSucursal>();
            while (read.Read())
            {
                MedicamentoxSucursal mxs = new MedicamentoxSucursal();
                mxs.IdSucursal = Convert.ToInt32(read["IdSucursal"]);
                mxs.IdMedicamento = Convert.ToInt32(read["IdMedicamento"]);
                mxs.PrecioSucursal = Convert.ToInt32(read["PrecioSucursal"]);
                mxs.Logicdelete = Convert.ToBoolean(read["LogicDelete"]);

                ListMedicamentoxSucursal.Add(mxs);

            }
            return ListMedicamentoxSucursal;
        }
        public void PostMedicamentoxSucursal([FromBody] MedicamentoxSucursal mxs)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdSucursal = new SqlParameter("@IdCasaFarmaceutica", System.Data.SqlDbType.Int);
            IdSucursal.Value = mxs.IdSucursal;

            SqlParameter IdMedicamento = new SqlParameter("@IdMedicamento", System.Data.SqlDbType.Int);
            IdMedicamento.Value = mxs.IdMedicamento;

            SqlParameter PrecioSucursal = new SqlParameter("@PrecioSucursal", System.Data.SqlDbType.Int);
            PrecioSucursal.Value = mxs.PrecioSucursal;



            command = new SqlCommand("insert into MedicamentoxCasaFarmaceutica(IdSucursal,IdMedicamento,PrecioSucursal) VALUES (@IdSucursal,@IdMedicamento,@PrecioSucursal)", conn);

            command.Parameters.Add(IdSucursal);
            command.Parameters.Add(IdMedicamento);
            command.Parameters.Add(PrecioSucursal);

            command.ExecuteNonQuery();

            conn.Close();

        }

    }
}