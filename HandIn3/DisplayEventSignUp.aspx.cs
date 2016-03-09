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
    public partial class DisplayEventSignUp : System.Web.UI.Page
    {
        int userlevel;
        int membernumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();

            try
            {
                userlevel = (int)Session["Level"];
                membernumber = (int)Session["MemberNumber"];
            }
            catch (NullReferenceException nre)
            {
                userlevel = 0;
                Session["Level"] = userlevel;
                LabelMessage.Text = nre.Message;
            }
            finally
            {
                SetButtonAndText();
            }

            UpdateGridView();
        }

        public void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select activitynumber as [Activity Number], Title, Description, Weekday, Time, coach.Name from activities, coach where activities.coachid = coach.coachnumber";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewActivity.DataSource = rdr;
                GridViewActivity.DataBind();
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

        protected void GridViewUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqludp = "select membersignup.activityid as [Activity Number], membersignup.memberid as [Member Number], members.name as Name from membersignup, members where membersignup.activityid = @ActivityNumber and membersignup.memberid = membernumber";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqludp, conn);
                cmd.Parameters.Add("@ActivityNumber", SqlDbType.Int);
                
                // Cells[count] select is 0
                cmd.Parameters["@ActivityNumber"].Value = Convert.ToInt32(GridViewActivity.SelectedRow.Cells[1].Text);

                rdr = cmd.ExecuteReader();

                LabelMessage.Text = "Signed up for the activity";

                GridViewSignUp.DataSource = rdr;
                GridViewSignUp.DataBind();               
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

        private void SetButtonAndText()
        {
            if (userlevel == 2)
            {
                LabelUserLevel.Text = "You are logged in as a coach ";
            }
            else
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}