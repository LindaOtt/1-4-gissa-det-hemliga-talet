using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_4_Gissa_Talet
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        //Session variable stores ref to business layer


        protected void Page_Load(object sender, EventArgs e)
        {
            //Check to see if the form has already been posted
            //If not, initialize SecretNumber
            if (!IsPostBack)
            {
                SecretNumber secretNumber = new SecretNumber();
                Session["secretNumber"] = secretNumber;
                //LabelResultOfGuess.Text = Convert.ToString(secretNumber.Number);
            }
            //Otherwise, set SecretNumber to the one in View State
            else
            {
                if (Session["secretNumber"] != null)
                {
                    SecretNumber secretNumber = (SecretNumber)Session["secretNumber"];
                }
                else
                {
                    throw new Exception("The secretNumber reference is missing.");
                }

            }

        }
    }
}