using System;
using System.Data;
using System.Data.SqlClient;

public class clsConexion
{
	public clsConexion() { }

	public SqlConnection getConexion()
	{
		try
		{
			SqlConnection con = new SqlConnection("SERVER=.;Initial Catalog='Ventas';Integrated Security=True");
			return con;
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
		return null;
	}
}

