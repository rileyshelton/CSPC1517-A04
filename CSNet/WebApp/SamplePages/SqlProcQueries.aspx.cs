using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Add Namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Data;

#endregion

namespace WebApp.SamplePages
{
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";

            //the dropdownnlist (DDL) control will be loaded with Data from the Data Base
            //Consideration needs to be given to the data as to it change frequence
            //if your data does not change frequently, you can consider loading on page load

            if (!Page.IsPostBack)
            {
                //use user friendly error handling
                try
                {
                    //create and connect to the appropriate BLL Class
                    CategoryController sysmgr = new CategoryController();
                    //issue the request to the appropriate BLL class method and capture results
                    List<Category> datainfo = sysmgr.Category_List();
                    //  Optional: sort results
                    datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));//ascending
                    //Attach data source collection to DDL
                    CategoryList.DataSource = datainfo;
                    //set DDL DataTextField and Data DataValueField Properties
                    CategoryList.DataTextField = nameof(Category.CategoryName);
                    CategoryList.DataValueField = "CategoryID";
                    //Physically bind the data to the DDL control
                    CategoryList.DataBind();
                    //  Optional: add a prompt to the DDL control
                    CategoryList.Items.Insert(0, "select...");

                }
                catch(Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Ensure a selection was made
            if(CategoryList.SelectedIndex == 0)
            {
                //  No selection: Message to user
                MessageLabel.Text = "Please select a category...";

            }
            else
            {
                //  Yes selection: Proccess lookup
                //    user friendly error handling
                try
                {
                    //      Create and connect to BLL class
                    ProductController sysmgr = new ProductController();
                    //      Issuse request for lookup to appropriate BLL class Method
                    //        and capture results

                    List<Product> datainfo = sysmgr.Product_GetByCategory(int.Parse(CategoryList.SelectedValue));
                    //      check results (  .Count() ==0)
                    if(datainfo.Count() ==0)
                    {
                        //      No records: Message to user
                        MessageLabel.Text = "No Data found for selected Category....";
                        //removed old data (optional)
                        //not confused w/ this message
                        CategoryProductList.DataSource = null;
                        CategoryProductList.DataBind();
                    }
                    else
                    {
                        //      Yes Records: display data
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }

            }

        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();
        }
    }
}