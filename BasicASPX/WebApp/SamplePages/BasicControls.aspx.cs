using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        public static List<DDLClass> DataCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this event method is executed each and every time this page is proccessed
            //this event method is executed BEFORE ANY EVENT method is processed

            //this page is an excelent place to do page initialization of your controls
            //there is a property to test for Post back of your page called Page.IsPostBack (Razor IsPost)
            if (!Page.IsPostBack)
            {
                //do first page init proc

                //create an instance of the Data Collection List
                DataCollection = new List<DDLClass>();


                //load the data collection w/ dummy data
                //normally this data would come from your db
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "CPSC1517"));
                DataCollection.Add(new DDLClass(3, "DMIT2018"));
                DataCollection.Add(new DDLClass(4, "DMIT1508"));

                //SORT THE List<T> IN ONE LINE OF CODE
                //  Use the method .Sort()
                //    (x,y) a and y represent and two instances in your list at any time
                DataCollection.Sort((x,y) => 
                  x.DisplayField.CompareTo(y.DisplayField));

                //setup the dropdownlist
                // a. ASssign your data to the control
                CollectionList.DataSource = DataCollection;
                // b. assign the data list field names to the appropriate control properties
                //  1. .DataValueField this is the value of the select
                //  2. .DataTextField this is the display of the select
                CollectionList.DataValueField = "ValueField";
                CollectionList.DataTextField = nameof(DDLClass.DisplayField);
                // c. physically bind the data to the control for show
                CollectionList.DataBind();
                //what prompt?
                //one can add a prompt to the start of the 
                // BOUND control list
                //one will use the index 0 to position the prompt
                CollectionList.Items.Insert(1, "select...");


            }
        }

        protected void SubMitButton_Click(object sender, EventArgs e)
        {
            //this method is executed when the sumbit when the submit button is pressed
            //this method is concerned with the actions needed for the submit button

            //to acces the data of the control, you use the appropriate control (get, set) property and access technique

            //for TextBox, Label, Literal use .Text
            //for a list (DRopDownList, RadioButtonList) use one of:
            //  .SelectedIndex  the physical location of the item in the list
            //  .SelectedValue  the assoicated Data Value "
            //  .SelectedItem   the assoicated Data Display Text "
            //for boolena controls (RadioButton, CheckBox) use .Checked

            //most controls will use strings except for boolean controls

            string submitchoice = TextBoxNumericChoice.Text;

            //sample
            if (string.IsNullOrEmpty(submitchoice))
            {
                OutputMessage.Text = "Enter a course choice of 1 to 4";
            }
            else
            {
                //set the RadioButton using the entered data value
                //property: .SelectedValue
                RadioButtonListChoice.SelectedValue = submitchoice;

                if(submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }
                //position in the DDL
                //use the entered data value to position
                //property: .SelectedValue
                CollectionList.SelectedValue = submitchoice;

                //demon 3 diff access tech for a list
                DisplayReadOnly.Text = CollectionList.SelectedItem.Text
                                     + " at index " + CollectionList.SelectedIndex
                                     + " has a value of " + CollectionList.SelectedValue;



            }//eof
        }//eom submitchoie
    }//eoc form class
}