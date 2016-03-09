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
    public partial class MemberSignup : System.Web.UI.Page
    {
        int userlevel;
        int membernumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // get userlevel from session (login)
                userlevel = (int)Session["Level"];
                membernumber = (int)Session["MemberNumber"];
            }
            catch (NullReferenceException nre)
            {
                //if user not logged in set userlevel to 0
                userlevel = 0;
                Session["Level"] = userlevel;
                LabelMessage.Text = nre.Message;
            }
            finally
            {
                // display userlevel or go to error page if not logged in
                SetButtonAndText();
            }

            if (!Page.IsPostBack)
            {
                UpdateGridView();
                DropDownListActivity.AutoPostBack = true;
                ButtonCreate.Enabled = false;
            }

            LabelMessage.Text = "";
            ButtonCreate.Enabled = false;
        }

        private void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            // select activities where a member is not already signed up
            string sqlsel = "SELECT A.ActivityNumber as Number, A.Title, A.Description, A.Weekday, A.Time FROM Activities A LEFT JOIN MemberSignup M on A.ActivityNumber = M.ActivityId AND M.MemberId = @MemberID WHERE M.ActivityId IS null";

            try
            {
                // conn.Open();  SqlDataAdapter open the connection by itself
                da = new SqlDataAdapter();
                cmd = new SqlCommand(sqlsel, conn);

                cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4, "MemberID");
                cmd.Parameters["@MemberID"].Value = membernumber;

                da.SelectCommand = cmd;

                //dataset
                ds = new DataSet();
                da.Fill(ds, "Activity");

                //datatable
                dt = ds.Tables["Activity"];

                // populate gridview
                GridViewActivity.DataSource = dt;
                GridViewActivity.DataBind();

                //populate dropdownlist with activities
                DropDownListActivity.Items.Clear();
                DropDownListActivity.DataSource = dt;
                DropDownListActivity.DataTextField = "Title";
                DropDownListActivity.DataValueField = "Number";
                DropDownListActivity.DataBind();
                DropDownListActivity.Items.Insert(0, "Select an activity");

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

        protected void DropDownListActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelMessage.Text = "You chose to signup for activity " + DropDownListActivity.SelectedValue;
            ButtonCreate.Enabled = true;
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from MemberSignup";
            string sqlins = "insert into MemberSignup values(@MemberID, @ActivityID)";

            try
            {
                // conn.Open();  SqlDataAdapter open the connection by itself
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                // dataset
                ds = new DataSet();
                da.Fill(ds, "SignUp");

                // datatable
                dt = ds.Tables["SignUp"];

                // new row and add input data to table
                DataRow newrow = dt.NewRow();
                newrow["MemberID"] = membernumber;
                newrow["ActivityID"] = DropDownListActivity.SelectedValue;
                
                // add the new row to the table
                dt.Rows.Add(newrow);

                // add parameters to command
                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4, "MemberID");
                cmd.Parameters.Add("@ActivityID", SqlDbType.Int, 4, "ActivityID");

                cmd.Parameters["@MemberID"].Value = membernumber;
                cmd.Parameters["@ActivityID"].Value = Convert.ToInt32(DropDownListActivity.SelectedValue);

                da.InsertCommand = cmd;
                da.Update(ds, "SignUp");

                LabelMessage.Text = "Signup added";
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

        private void SetButtonAndText()
        {
            if (userlevel == 1)
            {
                //display login status/role
                LabelUserLevel.Text = "You are logged in as a member ";
            }
            else
            {
                //if no userlevel in session go to error page
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}