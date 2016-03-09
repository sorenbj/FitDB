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
    public partial class SponsorCRUD : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
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
                UpdatePage();
            }
            else
            {
                if (DropDownListSponsor.SelectedIndex != 0)
                {
                    ds = new DataSet();
                    ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
                    dt = ds.Tables["sponsor"];

                    foreach (DataRow dr in dt.Select("id = " + Convert.ToInt32(DropDownListSponsor.SelectedValue)))
                    {
                        TextBoxID.Text = dr["id"].ToString();
                        TextBoxCompanyName.Text = dr["companyname"].ToString();
                        TextBoxWebsite.Text = dr["website"].ToString();
                        TextBoxPicture.Text = dr["picture"].ToString();                  
                    }

                    LabelMessage.Text = TextBoxCompanyName.Text + " has been selected";

                    // selected index must be set back to 0 to avoid old data to be read back to the drop
                    DropDownListSponsor.SelectedIndex = 0;
                    ButtonCreate.Enabled = false;
                    ButtonUpdate.Enabled = true;
                    ButtonDelete.Enabled = true;
                }
            }

        }

        private void UpdatePage()
        {
            //populate dropdownlist
            DropDownListSponsor.AutoPostBack = true;
            DropDownListSponsor.Items.Clear();

            try
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
                dt = ds.Tables["sponsor"];

                DropDownListSponsor.DataSource = dt;
                DropDownListSponsor.DataTextField = dt.Columns[1].ToString();
                DropDownListSponsor.DataValueField = dt.Columns[0].ToString();
                DropDownListSponsor.DataBind();
            }
            catch
            {
                // XML file does not exist or empty
                // dt made for display of repeater heading
                MakeNewDataSetAndDataTable();
            }
            finally
            {
                RepeaterSponsor.DataSource = dt;
                RepeaterSponsor.DataBind();

                DropDownListSponsor.Items.Insert(0, "Select a sponsor");
            }

            TextBoxID.Text = "";
            TextBoxCompanyName.Text = "";
            TextBoxWebsite.Text = "";
            TextBoxPicture.Text = "";

            ButtonCreate.Enabled = true;
            ButtonUpdate.Enabled = false;
            ButtonDelete.Enabled = false;
        }

        private void MakeNewDataSetAndDataTable()
        {
            ds = new DataSet("sponsors");  //root tag
            dt = ds.Tables.Add("sponsor");
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("companyname", typeof(String));
            dt.Columns.Add("website", typeof(String));
            dt.Columns.Add("picture", typeof(String));
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
                dt = ds.Tables["sponsor"];
            }
            catch
            {
                // XML file does not exits
                MakeNewDataSetAndDataTable();
            }

            int maxsponsorid = 0;

            if (dt == null)
            {
                // XML file exist but is empty
                MakeNewDataSetAndDataTable();
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr["id"].ToString()) > maxsponsorid) maxsponsorid = Convert.ToInt32(dr["id"].ToString());
                }
            }

            DataRow newrow = dt.NewRow();
            newrow["id"] = maxsponsorid + 1;
            newrow["companyname"] = TextBoxCompanyName.Text;
            newrow["website"] = TextBoxWebsite.Text;
            newrow["picture"] = TextBoxPicture.Text;
            dt.Rows.Add(newrow);

            ds.WriteXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
            LabelMessage.Text = TextBoxCompanyName.Text + " has been created";
            UpdatePage();
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
            dt = ds.Tables["sponsor"];

            foreach (DataRow dr in dt.Select("id =" + Convert.ToInt32(TextBoxID.Text)))
            {
                dr["id"] = Convert.ToInt32(TextBoxID.Text);
                dr["companyname"] = TextBoxCompanyName.Text;
                dr["website"] = TextBoxWebsite.Text;
                dr["picture"] = TextBoxPicture.Text;
            }

            ds.WriteXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));

            LabelMessage.Text = TextBoxCompanyName.Text + " has been updated";
            UpdatePage();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
            dt = ds.Tables["sponsor"];

            foreach (DataRow dr in dt.Select("id =" + Convert.ToInt32(TextBoxID.Text)))
            {
                dr.Delete();
            }

            ds.WriteXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));

            LabelMessage.Text = TextBoxCompanyName.Text + " has been deleted";
            UpdatePage();
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            LabelMessage.Text = "Input values has been cleared";
            UpdatePage();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // Specify the path
            String savePath = @"C:\Users\Sorenbj\Documents\WEBSTUD - 1\Database\HandIn3\HandIn3\Pictures - sponsor\";

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