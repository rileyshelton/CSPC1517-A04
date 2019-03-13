using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApplication : System.Web.UI.Page
    {
        public static List<GridViewCollection> gvCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                gvCollection = new List<GridViewCollection>();
            }
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            FullName.Text = "";
            EmailAddress.Text = "";
            PhoneNumber.Text = "";
            FullOrPartTime.ClearSelection();
            Jobs.ClearSelection();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string fullname = FullName.Text;
            string emailaddress = EmailAddress.Text;
            string phonenumber = PhoneNumber.Text;
            string fullorparttime = FullOrPartTime.SelectedValue;
            //proccess the CheckBoxList
            //the control can be treated as a collection
            // one can step thru the collection line by line using the foreach loop

            string jobs = "";

            foreach(ListItem jobrow in Jobs.Items)
            {
                if (jobrow.Selected)
                {
                    jobs += jobrow.Text + " ";
                }
            }


        }
    }
}