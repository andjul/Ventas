using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ventas.Negocios;

namespace WebVentas
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductosBL andres = new ProductosBL();
            andres.ProductoBO.idProducto = 0;
            andres.ProductoBO.DescripcionProducto = "Andres";
            andres.Registrar();

        }
    }
}