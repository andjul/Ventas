using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Datos;

namespace Ventas.Negocios
{
    public class ProductosBL
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private ProductosDAO _productoDal = new ProductosDAO();
        private ProductosBO _productoBO = new ProductosBO();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public ProductosBO ProductoBO
        {
            get { return _productoBO; }
            set { _productoBO = value; }
        }

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar()
        {
            if (ValidarProducto())
            {
                if (_productoDal.BuscaridProducto(ProductoBO.idProducto))
                {
                    _productoDal.Crear();
                }
                else
                    _productoDal.Modificar();

            }
        }

        public System.Data.DataTable Todos()
        {
            return _productoDal.BuscarTodos();
        }

        public List<ProductosBO> Todos()
        {
            return _productoDal.BuscarTodos();
        }

        public ProductosBO TraerPorId(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _productoDal.BuscaridProducto(idProduct);
            }
            return null;
        }

        public void Eliminar()
        {
            stringBuilder.Clear();

            if (ProductoBO.idProducto == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _productoDal.Eliminar();
            }
        }

        private bool ValidarProducto()
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(ProductoBO.DescripcionProducto)) stringBuilder.Append("El campo Descripción es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}


