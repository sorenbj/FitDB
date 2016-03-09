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
    public partial class CreateMember : System.Web.UI.Page
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
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDb");
            SqlCommand cmd = null;
            string sqlins = "insert into members values(@MemberNumber, @Name, @Gender, @Phonenumber, @Email, @Password)";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlins, conn);
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

                LabelMessage.Text = "Member added";
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