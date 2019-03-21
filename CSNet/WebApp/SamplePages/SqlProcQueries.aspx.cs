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

       
    }
}