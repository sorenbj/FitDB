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
    public partial class MemberSignUpDelete : System.Web.UI.Page
    {
        int userlevel;
        int membernumber;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (!Page.IsPostBack)
            {
                UpdateGridView();
                DropDownListSignup.AutoPostBack = true;
                ButtonDelete.Enabled = false;
            }

            LabelMessage.Text = "";
            ButtonDelete.Enabled = false;
        }

        private void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select membersignup.ActivityID as [Activity Number], Activities.Title, Activities.Weekday, Activities.Time from membersignup, Activities where MemberID = @MemberID and ActivityNumber = ActivityID";

            try
            {
                // conn.Open();  SqlDataAdapter open the connection by itself
                da = new SqlDataAdapter();

                cmd = new SqlCommand(sqlsel, conn);

                cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4, "MemberID");
                cmd.Parameters["@MemberID"].Value = membernumber;

                da.SelectCommand = cmd;

                ds = new DataSet();
                da.Fill(ds, "SignUps");

                dt = ds.Tables["SignUps"];

                GridViewMember.DataSource = dt;
                GridViewMember.DataBind();

                DropDownListSignup.Items.Clear();
                DropDownListSignup.DataSource = dt;
                DropDownListSignup.DataTextField = "Title";
                DropDownListSignup.DataValueField = "Activity Number";
                DropDownListSignup.DataBind();
                DropDownListSignup.Items.Insert(0, "Select a signup");

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();  // SqlDataAdapter closes the connection by itself, but can fail in case of errors
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlDataAdapter da = null;
            SqlCommandBuilder cb = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from membersignup where memberid = @MemberID";

            try
            {
                // conn.Open();  SqlDataAdapter open the connection by itself
                da = new SqlDataAdapter();

                cmd = new SqlCommand(sqlsel, conn);

                cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4, "MemberID");
                cmd.Parameters["@MemberID"].Value = membernumber;

                da.SelectCommand = cmd;

                cb = new SqlCommandBuilder(da);

                ds = new DataSet();
                da.Fill(ds, "SignUp");

                dt = ds.Tables["SignUp"];

                foreach (DataRow dr in dt.Select("ActivityID = " + Convert.ToInt32(DropDownListSignup.SelectedValue)))
                {
                    dr.Delete();
                }

                da.Update(ds, "SignUp");
                LabelMessage.Text = "Signup has been deleted";
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();  // SqlDataAdapter closes the connection by itself, but can fail in case of errors
            }

            UpdateGridView();
        }

        protected void DropDownListSignup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelMessage.Text = "You chose your signup for activity " + DropDownListSignup.SelectedValue;
            ButtonDelete.Enabled = true;
        }

        private void SetButtonAndText()
        {
            if (userlevel == 1)
            {
                LabelUserLevel.Text = "You are logged in as a member ";
            }
            else
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}