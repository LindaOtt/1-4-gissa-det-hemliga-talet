using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_4_Gissa_Talet
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        string madeGuessesText = "";
        //Session variable stores ref to business layer


        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxEnterGuess.Focus();
            string message = "";

            

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
                    try {
                        SecretNumber secretNumber = (SecretNumber)Session["secretNumber"];
                        //Check if submit guess button should be usable
                        if (secretNumber.Count >= 7)
                        {
                            ButtonSubmitGuess.Enabled = false;
                            PlaceHolderNewRandomNumber.Visible = true;
                            ButtonGetNewRandomNumber.Enabled = true;
                            ButtonGetNewRandomNumber.Focus();
                        }

                        secretNumber.MakeGuess(Convert.ToInt16(TextBoxEnterGuess.Text));

                        //Creating a string with previously made guesses
                        foreach (int madeGuess in secretNumber.PreviousGuesses)
                        {
                            madeGuessesText = madeGuessesText + madeGuess + ", ";
                        }

                        //Writing out the string of previously made guesses
                        LabelMadeGuesses.Text = madeGuessesText;

                        switch(Convert.ToString(secretNumber.OutCome))
                        {
                            case "Low":
                                message = "Talet du gissade är för lågt";
                                break;
                            case "High":
                                message = "Talet du gissade är för högt";
                                break;
                            case "Correct":
                                message = "Du gissade rätt på " + secretNumber.Count + "försök.";
                                break;
                            case "NoMoreGuesses":
                                message = "Du har inga gissningar kvar. Det hemliga talet var " + secretNumber.Number;
                                break;
                            default:
                                message = "";
                                break;
                        }

                        //Writing out the message resulting from the made guess
                        LabelResultOfGuess.Text = message;

                    }
                    catch (Exception error)  {
                        LabelMadeGuesses.Text = Convert.ToString(error);
                        Debug.Write(error);
                    }
                    
                }
                else
                {
                    throw new Exception("Referens till secretNumber saknas.");
                }

            }

        }
    }
}