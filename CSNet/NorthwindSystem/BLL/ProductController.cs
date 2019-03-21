using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.DAL;

#endregion

namespace NorthwindSystem.BLL
{//This class will be called from an external source
    // in our ex. this source will be the web page
    //naming standard is <T>Controller which represents a particular data class (sql table)
    public class ProductController
    {
        //code methods which will be called for processing
        //methods will be public
        //these systems are reffered to as the system interface

        //a method to look up a record on the DataBase table by primary key
        //input pKey
        //output instance of data class
        public Product Product_Get(int productid)
        {
            //the proccessing of the request will be done in a transaction using the Context Class
            // a) instance of Context Class
            // b) issue the request for lookup via the appropriate DbSet<T>
            // c) return results
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productid);
            }
        }
        // a method that retreives all records on the DbSet<T>
        // input: none
        // output: List<T>
        public List<Product> Product_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }
    }
}
