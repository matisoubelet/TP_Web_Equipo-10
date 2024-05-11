using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ModelDomain;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DBAccess
{
    public class ArticleDBAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public ArticleDBAccess()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            command = new SqlCommand();
        }

        public void SetQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        public void ExecuteRead()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteAction()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CloseConnection()
        {
            reader?.Close();
            connection.Close();
        }
        
        public List<Article> ListArticles()
        {
            List<Article> list = new List<Article>();
            
            try
            {
                SetQuery("select * from Articulos");
                ExecuteRead();

                while (reader.Read())
                {
                    Article aux = new Article();
                    aux.id = reader.GetInt32(0);
                    aux.code = reader.GetString(1);
                    aux.name = reader.GetString(2);
                    aux.desc = reader.GetString(3);
                    aux.idBrand = reader.GetInt32(4);
                    aux.idCategory = reader.GetInt32(5);
                    aux.price = (float)reader.GetDecimal(6);
                    list.Add(aux);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        
        public List<Img> ListImages()
        {
            List<Img> listImages = new List<Img>();

            try
            {
                SetQuery("select * from IMAGENES");
                ExecuteRead();

                while (reader.Read())
                {
                    Img aux = new Img();
                    aux.id = reader.GetInt32(0);
                    aux.articleID = reader.GetInt32(1);
                    aux.imageUrl = reader.GetString(2);
                    listImages.Add(aux);
                }
                
                return listImages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        
        public List<Brand> ListBrands()
        {
            List<Brand> list = new List<Brand>();

            try
            {
                SetQuery("select * from Marcas");
                ExecuteRead();

                while (reader.Read())
                {
                    Brand aux = new Brand();

                    aux.id = reader.GetInt32(0);
                    aux.name = reader.GetString(1);

                    list.Add(aux);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }        
        public List<Category> ListCategories()
        {
            List<Category> list = new List<Category>();

            try
            {
                SetQuery("select * from Categorias");
                ExecuteRead();

                while (reader.Read())
                {
                    Category aux = new Category();

                    aux.id = reader.GetInt32(0);
                    aux.name = reader.GetString(1);

                    list.Add(aux);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }        

        public int GetLastArticleId()
        {
            try
            {
                SetQuery("select top 1 ID from ARTICULOS order by id desc");
                ExecuteRead();

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
            catch(Exception ex )
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void InsertArticle(Article article, List<Img> images)
        {
            try
            {
                SetQuery("Insert into ARTICULOS values('" + article.code + "','" + article.name + "', '" + article.desc + "'," + article.idBrand + "," + article.idCategory + "," + article.price + ")");
                ExecuteAction();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            foreach (Img img in images)
            {
                try
                {
                    SetQuery("Insert into IMAGENES values(" + img.articleID + ", '" + img.imageUrl + "')");
                    ExecuteAction();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        public void ModifyArticle(Article article, List<Img> images)
        {
            try
            {
                SetQuery("update ARTICULOS set Codigo ='"+ article.code +"', Nombre = '"+article.name+"', Descripcion = '"+article.desc+"', IdMarca = "+article.idBrand+", IdCategoria = "+article.idCategory+", Precio = "+article.price+" Where Id ="+article.id+"");
                ExecuteAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            foreach (Img img in images)
            {
                try
                {
                    SetQuery("Insert into IMAGENES values(" + img.articleID + ", '" + img.imageUrl + "')");
                    ExecuteAction();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseConnection();
                }
            }
        }
    }
}
