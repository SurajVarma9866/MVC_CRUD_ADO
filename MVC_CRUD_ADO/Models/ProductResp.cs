using System.Data.SqlClient;
using System.Data;

namespace MVC_CRUD_ADO.Models
{
    public class ProductResp : IproductRespo
    {
        
        static string constr = "server=ENCDAPHYDLT0173;database=MySuperMart;User Id=sa; Password=Prime@2019";
        List<Product> Products=new List<Product>();
        public List<Product> GetAll()
        {
            using(SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                Console.WriteLine("Connection estd");
                SqlCommand cmd = new SqlCommand("select * from Productss", con);
                SqlDataReader sa = cmd.ExecuteReader();

                while (sa.Read())
                {
                    Products.Add( new Product() { Id = sa.GetInt32(0), Name = sa.GetString(1), Price = Convert.ToDouble(sa["price"]), Category = sa.GetString(3) });
                   
                }

                return Products;

                
                
            }

            return Products;
        }

        public void Add(Product product)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into productss values(@id, @name, @price, @cate)", con);
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@cate", product.Category);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Product product) {
            Product p;
           
                Products = GetAll();
            
            p = Products.FirstOrDefault(y => y.Id == product.Id);

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Productss set Name = @name, Price=@price, Category=@cate where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@cate", product.Category);
                cmd.ExecuteNonQuery();



            }
            foreach (Product prod in Products) {
                if (prod.Id == product.Id) { 
                prod.Name = product.Name;
                    prod.Price = product.Price;
                    prod.Category = product.Category;

                }
            }

        }
        public Product GetProductById(int id)
        {
            Product p;
            
                Products = GetAll();
            
          
                 p = Products.FirstOrDefault(x=> x.Id == id);
               
            
            return p;

        }

        public void DeleteProductById(int id)
        {
            Product p;
            if (Products == null)
            {
                Products = GetAll();
            }
            p = Products.FirstOrDefault(y => y.Id == id);

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete Productss where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery ();



            }

          
                Products.Remove(p);

        }


    }
}
