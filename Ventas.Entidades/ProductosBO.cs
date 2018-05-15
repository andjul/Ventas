using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class ProductosBO
{
	private int intidProducto;
	private string strDescripcionProducto;

	public int idProducto
	{
		get { return intidProducto; }
		set { intidProducto = value; }
	}
	public string DescripcionProducto
	{
		get { return strDescripcionProducto; }
		set { strDescripcionProducto = value; }
	}

	public ProductosBO(){ }

}
