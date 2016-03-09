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
    public partial class MemberCRUD : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                UpdateGridView();
            }

            UpdateGridView();
            LabelMessage.Text = "";
        }

        private void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select membersignup.ActivityID as Number, Activities.Title, Activities.Weekday, Activities.Time from Membersignup, Activities where MemberID = @MemberID and ActivityNumber = Membersignup.activityID";

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