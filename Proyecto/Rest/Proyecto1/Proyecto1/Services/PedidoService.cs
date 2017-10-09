﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using System.Data.SqlClient;

namespace Proyecto1.Services
{
    public class PedidoService
    {
        public List<Pedido> GetAllPedidos()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Pedido where LogicDelete = 0", conn);
            read = command.ExecuteReader();

            List<Pedido> ListPedidos = new List<Pedido>();
            while (read.Read())
            {
                Pedido pedido = new Pedido();
                pedido.IdPedido = Convert.ToInt32(read["IdPedido"]);
                pedido.IdCedula = Convert.ToInt32(read["IdCedula"]);
                pedido.IdSucursal = Convert.ToInt32(read["IdSucursal"]);
                pedido.Estado = Convert.ToBoolean(read["Estado"]);
                pedido.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

                ListPedidos.Add(pedido);

            }
            read.Close();
            conn.Close();
            return ListPedidos;
        }

        public List<PedidosId> GetPedidos(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select Sucursal.Nombre,Sucursal.Provincia,Sucursal.Canton,Sucursal.Distrito,Pedido.IdPedido from Pedido inner join Sucursal on Pedido.IdSucursal=Sucursal.IdSucursal where Pedido.Estado=0 and Pedido.LogicDelete=0 and Pedido.IdCedula=" + id.ToString(), conn);
            read = command.ExecuteReader();

            List<PedidosId> ListPedidos = new List<PedidosId>();
            while (read.Read())
            {
                PedidosId pedido = new PedidosId();
                pedido.NombreSucursal = Convert.ToString(read["Nombre"]);
                pedido.IdPedido = Convert.ToInt32(read["IdPedido"]);
                pedido.Provincia = Convert.ToString(read["Provincia"]);
                pedido.Canton = Convert.ToString(read["Canton"]);
                pedido.Distrito = Convert.ToString(read["Distrito"]);

                ListPedidos.Add(pedido);

            }
            read.Close();
            conn.Close();
            return ListPedidos;
        }

        public void PostPedido([FromBody] Pedido pedido)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = pedido.IdCedula;

            SqlParameter IdSucursal = new SqlParameter("@IdSucursal", System.Data.SqlDbType.Int);
            IdSucursal.Value = pedido.IdSucursal;

            SqlParameter Estado = new SqlParameter("@Estado", System.Data.SqlDbType.Bit);
            Estado.Value = pedido.Estado;

            command = new SqlCommand("insert into Pedido(IdCedula,IdSucursal,Estado) VALUES (@IdCedula,@IdSucursal,@Estado)", conn);
            command.Parameters.Add(IdCedula);
            command.Parameters.Add(IdSucursal);
            command.Parameters.Add(Estado);
            command.ExecuteNonQuery();

            conn.Close();

        }
    }
}