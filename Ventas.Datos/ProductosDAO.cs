using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Ventas.Datos
{
    public class ProductosDAO
    {

        private ProductosBO objProductosBO = new ProductosBO();
        public ProductosBO ProductosBO
        {
            get { return objProductosBO; }
            set { objProductosBO = value; }
        }
        public ProductosDAO()
        {
        }

        clsConexion dbm = new clsConexion();

        public Boolean Crear()
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("spProductos_N", con);
                parametros = cmd.Parameters.Add("@idProducto", SqlDbType.Int);
                parametros.Value = ProductosBO.idProducto;
                parametros = cmd.Parameters.Add("@DescripcionProducto", SqlDbType.VarChar);
                parametros.Value = ProductosBO.DescripcionProducto;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return res;
        }


        public Boolean Modificar()
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("spProductos_M", con);
                parametros = cmd.Parameters.Add("@idProducto", SqlDbType.Int);
                parametros.Value = ProductosBO.idProducto;
                parametros = cmd.Parameters.Add("@DescripcionProducto", SqlDbType.VarChar);
                parametros.Value = ProductosBO.DescripcionProducto;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return res;
        }


        public Boolean Eliminar()
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("spProductos_E", con);
                parametros = cmd.Parameters.Add("@idProducto", SqlDbType.Int);
                parametros.Value = ProductosBO.idProducto;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return res;
        }


        public DataTable  BuscarTodos()
        {
            SqlConnection con = new SqlConnection();
            DataTable ds = new DataTable();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("spProductos_TT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return null;
        }

        public ProductosBO BuscaridProducto(int vidProducto)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("spProductos_TC", con);
                parametros = cmd.Parameters.Add("@idProducto", SqlDbType.Int);
                parametros.Value = ProductosBO.idProducto;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProductosBO.idProducto = dr.GetInt32(0);
                    ProductosBO.DescripcionProducto = dr.GetString(1);
                }
                con.Close();
            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return ProductosBO;
        }


    }
}