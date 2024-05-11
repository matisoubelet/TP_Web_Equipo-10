using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDomain
{
    public class Article
    {

        public int id; // Unique, identity (1,1)
        public string code; //Maximo 50 caracteres (en la tabla aparecen codigos de 3, ejemplo: SO1, MO2
        public string name; //Maximo 50 caracteres
        public string desc; //Maximo 50 caracteres
        public int idBrand; // Clase de donde se puede linkear el IdMarca con el IdArticulo
        public int idCategory; //Clase de donde se puede linkear el IdCategoria con el IdArticulo
        public float price; // Que sea mayor a cero

        private static Random random = new Random();

        //Mas adelante va a haber que linkear con la imagen para que pueda traer todas las imagenes que tenga cada articulo
        //Vamos a tener que buscar la clase imagen cuyo IdImagen coincida con el IdArticulo.
        public Article() {
            //El constructor deberia agarrar el ultimo articulo, copiar su ID y sumarlo en 1 para guardarlo en
            //el nuevo articulo que se este creando. De esta forma no se pueden repetir IDs de Articulos
            //Por lo demas, hacer los "cin" necesarios para ya dejar el articulo todo cargado
            id = 0;
            code = string.Empty;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            name = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
            desc = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
            price = random.Next(1000);

        }

   
    }
}
