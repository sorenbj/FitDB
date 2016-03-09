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
    public partial class DsiplayUpdateActivity : System.Web.UI.Page
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
                // On show button
                ButtonUpdate.Enabled = false;
            }

            UpdateGridView();
        }

        public void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select activitynumber as [Activity Number], Title, Description, Weekday, Time, picturelink as Picture, coachid as [Coach Number] from activities";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewUpdate.DataSource = rdr;
                GridViewUpdate.DataBind();
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
            // Cells[count] select is 0
            TextBoxActivityNumber.Text = GridViewUpdate.SelectedRow.Cells[1].Text;
            TextBoxTitle.Text = GridViewUpdate.SelectedRow.Cells[2].Text;
            TextBoxDescription.Text = GridViewUpdate.SelectedRow.Cells[3].Text;
            TextBoxWeekday.Text = GridViewUpdate.SelectedRow.Cells[4].Text;
            TextBoxTime.Text = GridViewUpdate.SelectedRow.Cells[5].Text;
            TextBoxPicturelink.Text = GridViewUpdate.SelectedRow.Cells[6].Text;
            TextBoxCoachNumber.Text = GridViewUpdate.SelectedRow.Cells[7].Text;
            LabelMessage.Text = "You have chosen activity number " + GridViewUpdate.SelectedRow.Cells[1].Text;

            // show button
            ButtonUpdate.Enabled = true;
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            string sqludp = "update activities set ActivityNumber = @ActivityNumber, Title = @Title, Description = @Description, Weekday = @Weekday, Time = @Time, Picturelink = @Picturelink, CoachID = @CoachID where ActivityNumber = @ActivityNumber";
            // remember where : else every row will have new data

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqludp, conn);
                cmd.Parameters.Add("@ActivityNumber", SqlDbType.Int);
                cmd.Parameters.Add("@Title", SqlDbType.Text);
                cmd.Parameters.Add("@Description", SqlDbType.Text);
                cmd.Parameters.Add("@Weekday", SqlDbType.Text);
                cmd.Parameters.Add("@Time", SqlDbType.Time);
                cmd.Parameters.Add("@Picturelink", SqlDbType.Text);
                cmd.Parameters.Add("@CoachID", SqlDbType.Int);

                cmd.Parameters["@ActivityNumber"].Value = Convert.ToInt32(TextBoxActivityNumber.Text);
                cmd.Parameters["@Title"].Value = TextBoxTitle.Text;
                cmd.Parameters["@Description"].Value = TextBoxDescription.Text;
                cmd.Parameters["@Weekday"].Value = TextBoxWeekday.Text;
                cmd.Parameters["@Time"].Value = Convert.ToDateTime(TextBoxTime.Text).ToString("HH:mm:ss");
                cmd.Parameters["@Picturelink"].Value = TextBoxPicturelink.Text;
                cmd.Parameters["@CoachID"].Value = Convert.ToInt32(TextBoxCoachNumber.Text);

                cmd.ExecuteNonQuery();

                LabelMessage.Text = "Activity has been updated";
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            UpdateGridView();
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