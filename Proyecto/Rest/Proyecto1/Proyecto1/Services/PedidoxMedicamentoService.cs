using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using System.Data.SqlClient;



namespace Proyecto1.Services
{
    public class PedidoxMedicamentoService
    {
        public List<PedidoxMedicamento> GetAllPedidosxMedicamentos()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from PedidoxMedicamento where LogicDelete = 0", conn);
            read = command.ExecuteReader();

            List<PedidoxMedicamento> ListPedidosxMedicamento = new List<PedidoxMedicamento>();
            while (read.Read())
            {
                PedidoxMedicamento pedidoxMedicamento = new PedidoxMedicamento();
                pedidoxMedicamento.IdMedicamento = Convert.ToInt32(read["IdMedicamento"]);
                pedidoxMedicamento.IdPedido = Convert.ToInt32(read["IdPedido"]);
                pedidoxMedicamento.Cantidad = Convert.ToInt32(read["Cantidad"]);
                pedidoxMedicamento.RecetaImg = read["RecetaImg"].ToString();
                pedidoxMedicamento.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

                ListPedidosxMedicamento.Add(pedidoxMedicamento);

            }
            read.Close();
            conn.Close();
            return ListPedidosxMedicamento;
        }

        public List<MedicamentosxPedido> GetMedicamentosxPedido(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select PedidoxMedicamento.Cantidad, Medicamento.Nombre from PedidoxMedicamento inner join Medicamento on PedidoxMedicamento.IdMedicamento=Medicamento.IdMedicamento where  PedidoxMedicamento.LogicDelete = 0 and PedidoxMedicamento.IdPedido="+id.ToString(), conn);
            read = command.ExecuteReader();

            List<MedicamentosxPedido> ListPedidosxMedicamento = new List<MedicamentosxPedido>();
            while (read.Read())
            {
                MedicamentosxPedido pedidoxMedicamento = new MedicamentosxPedido();
                pedidoxMedicamento.Cantidad = Convert.ToInt32(read["Cantidad"]);
                pedidoxMedicamento.Nombre = Convert.ToString(read["Nombre"]);
                ListPedidosxMedicamento.Add(pedidoxMedicamento);

            }
            read.Close();
            conn.Close();
            return ListPedidosxMedicamento;
        }

        public void PostPedidoxMedicamento([FromBody] PedidoxMedicamento pedidoxMedicamento)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdPedido = new SqlParameter("@IdPedido", System.Data.SqlDbType.Int);
            IdPedido.Value = pedidoxMedicamento.IdPedido;

            SqlParameter IdMedicamento = new SqlParameter("@IdMedicamento", System.Data.SqlDbType.Int);
            IdMedicamento.Value = pedidoxMedicamento.IdMedicamento;

            SqlParameter Cantidad = new SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
            Cantidad.Value = pedidoxMedicamento.Cantidad;

            /*SqlParameter RecetaImg = new SqlParameter("@RecetaImg", System.Data.SqlDbType.Image);
            RecetaImg.Value = pedidoxMedicamento.RecetaImg;*/

            command = new SqlCommand("insert into PedidoxMedicamento(IdPedido,IdMedicamento,Cantidad) VALUES (@IdPedido,@IdMedicamento,@Cantidad)", conn);
            command.Parameters.Add(IdPedido);
            command.Parameters.Add(IdMedicamento);
            command.Parameters.Add(Cantidad);
            //command.Parameters.Add(RecetaImg);
            command.ExecuteNonQuery();

            conn.Close();

        }
    }
}