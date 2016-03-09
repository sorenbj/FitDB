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
    public partial class DisplayUpdateCoach : System.Web.UI.Page
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
            string sqlsel = "select coachnumber as [Coach Number], Name, phonenumber as Phone, email as [E-mail], Gender, Password from coach";

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
            TextBoxCoachNumber.Text = GridViewUpdate.SelectedRow.Cells[1].Text;
            TextBoxName.Text = GridViewUpdate.SelectedRow.Cells[2].Text;
            TextBoxPhoneNumber.Text = GridViewUpdate.SelectedRow.Cells[3].Text;
            TextBoxEmail.Text = GridViewUpdate.SelectedRow.Cells[4].Text;
            TextBoxGender.Text = GridViewUpdate.SelectedRow.Cells[5].Text;
            TextBoxPassword.Text = GridViewUpdate.SelectedRow.Cells[6].Text;
            LabelMessage.Text = "Coach " + GridViewUpdate.SelectedRow.Cells[1].Text + " " + GridViewUpdate.SelectedRow.Cells[2].Text + " has been selected";

            // show button
            ButtonUpdate.Enabled = true;
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            string sqludp = "update coach set CoachNumber = @CoachNumber, Name = @Name, Phonenumber = @Phonenumber, Email = @Email, Gender = @Gender, Password = @Password where CoachNumber = @CoachNumber";
            // remember where : else every row will have new data

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqludp, conn);
                cmd.Parameters.Add("@CoachNumber", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.Text);
                cmd.Parameters.Add("@Phonenumber", SqlDbType.Text);
                cmd.Parameters.Add("@Email", SqlDbType.Text);
                cmd.Parameters.Add("@Gender", SqlDbType.Text);
                cmd.Parameters.Add("@Password", SqlDbType.Text);

                cmd.Parameters["@CoachNumber"].Value = Convert.ToInt32(TextBoxCoachNumber.Text);
                cmd.Parameters["@Name"].Value = TextBoxName.Text;
                cmd.Parameters["@Phonenumber"].Value = TextBoxPhoneNumber.Text;
                cmd.Parameters["@Email"].Value = TextBoxEmail.Text;
                cmd.Parameters["@Gender"].Value = TextBoxGender.Text;
                cmd.Parameters["@Password"].Value = TextBoxPassword.Text;

                cmd.ExecuteNonQuery();

                LabelMessage.Text = "Coach has been updated";
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