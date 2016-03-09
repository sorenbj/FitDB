using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace HandIn3
{
    public partial class LoginMember : System.Web.UI.Page
    {
        // Variables used in session
        int userlevel;
        int membernumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelMessage.Text = "";
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            if ((String.IsNullOrEmpty(TextBoxPassword.Text.Trim())) || (String.IsNullOrEmpty(TextBoxMemberNumber.Text.Trim())))
            {
                LabelMessage.Text = "Please provide login information (number and password)";
            }
            else
            {
                try
                {
                    conn.Open();

                    cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "MemberLogin";  //Stored Procedure

                    // input parameter to stored procedure MemberNumber
                    SqlParameter in1 = cmd.Parameters.Add("@MemberNumb", SqlDbType.Int);
                    in1.Direction = ParameterDirection.Input;
                    in1.Value = Convert.ToInt32(TextBoxMemberNumber.Text);

                    // input parameter to stored procedure Password
                    SqlParameter in2 = cmd.Parameters.Add("@Pass", SqlDbType.Text);
                    in2.Direction = ParameterDirection.Input;
                    in2.Value = TextBoxPassword.Text;

                    // return value from Stored procedure (1 if user exists, 0 if no user)
                    SqlParameter returnvalCount = cmd.Parameters.Add("return_value", SqlDbType.Int);
                    returnvalCount.Direction = ParameterDirection.ReturnValue;

                    // execude stored procedure
                    rdr = cmd.ExecuteReader();

                    // reader has to be closed
                    rdr.Close();

                    // return value to mycount
                    int mycount = Convert.ToInt32(cmd.Parameters["return_value"].Value);

                    //check and login
                    if (mycount == 1) //Member
                    {
                        userlevel = 1;
                        membernumber = Convert.ToInt32(TextBoxMemberNumber.Text);
                        //set session parameters
                        Session["Level"] = userlevel;
                        Session["MemberNumber"] = membernumber;
                        //go to display signups
                        Response.Redirect("MemberCRUD.aspx");
                    }
                    if (mycount == 2) //Coach
                    {
                        userlevel = 2;
                        membernumber = Convert.ToInt32(TextBoxMemberNumber.Text);
                        //set session parameters
                        Session["Level"] = userlevel;
                        Session["MemberNumber"] = membernumber;
                        Response.Redirect("DisplayUpdateCoach.aspx");
                    }
                    else
                    {
                        LabelMessage.Text = "You are not a registered member. Please contact member administration;";
                        userlevel = 0;
                        //Response.Redirect("Welcome.aspx")
                    }
                }
                catch (Exception ex)
                {
                    LabelMessage.Text = ex.Message;
                }

                finally
                {
                    conn.Close();
                }
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            userlevel = 0;
            Session["Level"] = userlevel;
            LabelMessage.Text = "You are logged out";
            //SetButtonAndText();
        }
    }
}