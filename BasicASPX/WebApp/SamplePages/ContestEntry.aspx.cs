using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        //if we had a DataBase, the data would be stored here using this static List<T> is only done in this example b/c we have no db.
        public static List<ApplicationInfo> aiCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                aiCollection = new List<ApplicationInfo>();
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            PostalCode.Text = "";
            City.Text = "";
            Province.SelectedIndex = 0;
            EmailAddress.Text = "";

            CheckAnswer.Text = "";
            Terms.Checked = false;



        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //validate the data coming in

            if (Page.IsValid)
            {
                //validate the user checking Terms
                if (Terms.Checked)
                {
                    //  yes: create and load an Entry, add to the List, display List
                    string firstname = FirstName.Text;
                    string lastname = LastName.Text;
                    string streetaddress1 = StreetAddress1.Text;
                    string streetaddress2 = StreetAddress2.Text;
                    string postalcode = PostalCode.Text;
                    string city = City.Text;
                    int province = Province.SelectedIndex;
                    string emailaddress = EmailAddress.Text;

                    ApplicationInfo.DataSource = DataBindingCollection;
                }

                else
                {
                    //  no:  message
                    Message.Text = "You did not agree to the Terms of the contest, entry is denied.";
                }
            }

        }
    }
}