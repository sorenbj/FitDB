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
    public partial class CreateActivity : System.Web.UI.Page
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
                ButtonCreate.Enabled = false;
                UpdateDropDownListCoach();
            }

            DropDownListCoach.AutoPostBack = true;
        }

        protected void UpdateDropDownListCoach()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "select coachnumber, name from coach";

            try
            {
                // conn.Open();  SqlDataAdapter open the connection by itself
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "Coaches");

                dt = ds.Tables["Coaches"];

                // populate the dropdownlist
                DropDownListCoach.Items.Clear();
                DropDownListCoach.DataSource = dt;
                DropDownListCoach.DataTextField = "Name";
                DropDownListCoach.DataValueField = "CoachNumber";
                DropDownListCoach.DataBind();
                DropDownListCoach.Items.Insert(0, "Select a coach");
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

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDb");
            SqlCommand cmd = null;
            string sqlins = "insert into activities values(@ActivityNumber, @Title, @Description, @Weekday, @Time, @Picturelink, @CoachID)";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlins, conn);
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
                cmd.Parameters["@CoachID"].Value = Convert.ToInt32(DropDownListCoach.SelectedValue);

                cmd.ExecuteNonQuery();

                LabelMessage.Text = "Activity added";
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

        protected void DropDownListCoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCoach.SelectedIndex != 0)
            {
                ButtonCreate.Enabled = true;
            }
            else
            {
                LabelMessage.Text = "You chose none";
                ButtonCreate.Enabled = false;                               
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // Specify the path
            String savePath = @"C:\Users\Sorenbj\Documents\WEBSTUD - 1\Database\HandIn3\HandIn3\Pictures\";

            // Verify that the FileUpload control contains a file.
            if (FileUploadPicture.HasFile)
            {
                // Get the name of the file to upload.
                String fileName = FileUploadPicture.FileName;

                // Get the extension of the uploaded file.
                string extension = System.IO.Path.GetExtension(fileName);

                if ((extension == ".jpg") || (extension == ".png"))
                {
                    // Add the path to the name of the file to upload
                    savePath += fileName;

                    // Call the SaveAs method to save the uploaded file to the path.
                    FileUploadPicture.SaveAs(savePath);

                    LabelUpload.Text = "Your file was saved as " + fileName;
                }
                else
                {
                    LabelUpload.Text = "Your file was not uploaded because " +
                                         "it does not have a .jpg or .png extension.";
                }

            }
            else
            {
                // Notify the user that a file was not uploaded.
                LabelUpload.Text = "You did not specify a file to upload.";
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