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
    public partial class DisplayUpdateMember : System.Web.UI.Page
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
            string sqlsel = "select membernumber as [Member Number], Name, Gender, Phonenumber as Phone, email as [E-mail], Password from members";

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
            TextBoxMemberNumber.Text = GridViewUpdate.SelectedRow.Cells[1].Text;
            TextBoxName.Text = GridViewUpdate.SelectedRow.Cells[2].Text;
            TextBoxGender.Text = GridViewUpdate.SelectedRow.Cells[3].Text;
            TextBoxPhoneNumber.Text = GridViewUpdate.SelectedRow.Cells[4].Text;
            TextBoxEmail.Text = GridViewUpdate.SelectedRow.Cells[5].Text;           
            TextBoxPassword.Text = GridViewUpdate.SelectedRow.Cells[6].Text;
            LabelMessage.Text = "You have chosen member number " + GridViewUpdate.SelectedRow.Cells[1].Text;

            // show button
            ButtonUpdate.Enabled = true;
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            string sqludp = "update members set MemberNumber = @MemberNumber, Name = @Name, Gender = @Gender, Phonenumber = @Phonenumber, Email = @Email, Password = @Password where MemberNumber = @MemberNumber";
            // remember where : else every row will have new data

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqludp, conn);
                cmd.Parameters.Add("@MemberNumber", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.Text);
                cmd.Parameters.Add("@Gender", SqlDbType.Text);
                cmd.Parameters.Add("@Phonenumber", SqlDbType.Text);
                cmd.Parameters.Add("@Email", SqlDbType.Text);
                cmd.Parameters.Add("@Password", SqlDbType.Text);

                cmd.Parameters["@MemberNumber"].Value = Convert.ToInt32(TextBoxMemberNumber.Text);
                cmd.Parameters["@Name"].Value = TextBoxName.Text;
                cmd.Parameters["@Gender"].Value = TextBoxGender.Text;
                cmd.Parameters["@Phonenumber"].Value = TextBoxPhoneNumber.Text;
                cmd.Parameters["@Email"].Value = TextBoxEmail.Text;              
                cmd.Parameters["@Password"].Value = TextBoxPassword.Text;

                cmd.ExecuteNonQuery();

                LabelMessage.Text = "Member has been updated";
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