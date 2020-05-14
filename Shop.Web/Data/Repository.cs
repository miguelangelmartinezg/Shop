

namespace Shop.Web.Data
{

    
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    public class Repository : IRepository
    {
        //creamos una propiedad de solo lectura y la instanciamos en el CONSTRUCTOR
        private readonly DataContext context;

        //INYECCION DE LA BD
        //LE CREAMOS UN CONSTRUCTOR A LA CLASE Y EN ESTE LLAMAMOS AL DATACONTEXT
        public Repository(DataContext context)
        {
            //Instancia de la propiedad de solo lectura
            this.context = context;
        }

        //EN ESTA CLASE TENDREMOS TODOS LOS METODOS QUE MANEJARAN LOS CURD de las tablas

        //metodo que devuelve una LISTA (no Instanciada)
        public IEnumerable<Product> GetProducts()// de vuelve todos los productos ordendados por nombre
        {
            return this.context.Products.OrderBy(p => p.Name);
        }

        //este metodo busca un Producto filtrado por su ID
        public Product GetProduct(int id)//devuelve un objeto de la clase producto, es decir un producto
        {
            return this.context.Products.Find(id);
        }

        //Metodo que AGREGA un producto
        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
        }

        //Metdo que ACTUALIZA un Producto
        public void UpdateProduct(Product product)
        {
            this.context.Update(product);
        }

        //Elimina un Producto
        public void RemoveProduct(Product product)
        {
            this.context.Products.Remove(product);
        }
        //TODOS ESTOS METODOS NO HACEN NADA EN LA BASE DE DATOS HASTA QUE NO EJECUTEMO EL SIGUIENTE METODO


        //METODO QUE GRABA EN LA BASE DE DATOS
        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        //METODO QUE DEVUELVE SI UN PRODUCTO EXISTE EN LA BASE DATOS
        public bool ProductExists(int id)
        {
            return this.context.Products.Any(p => p.Id == id);
        }
    }

}

