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
    public partial class DeleteCoach : System.Web.UI.Page
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
                ButtonDelete.Enabled = false;
                UpdateGridView();
            }

            DropDownListCoach.AutoPostBack = true;
        }

        public void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select Coachnumber as [Coach Number], Name, phonenumber as Phone, email as [E-mail], Gender from coach";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewCoaches.DataSource = rdr;
                GridViewCoaches.DataBind();

                rdr.Close();
                rdr = cmd.ExecuteReader();

                DropDownListCoach.DataSource = rdr;
                DropDownListCoach.DataTextField = "Name";
                DropDownListCoach.DataValueField = "Coach Number";
                DropDownListCoach.DataBind();
                DropDownListCoach.Items.Insert(0, "Select a Coach");
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

        protected void DropDownListCoaches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCoach.SelectedIndex != 0)
            {
                LabelMessage.Text = "You chose coach " + DropDownListCoach.SelectedValue;
                ButtonDelete.Enabled = true;
            }
            else
            {
                LabelMessage.Text = "You chose none";
                ButtonDelete.Enabled = false;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            string sqlDel = "delete from coach where CoachNumber = @CoachNumber";
            // remember where : else every row will be deleted

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlDel, conn);
                cmd.Parameters.Add("@CoachNumber", SqlDbType.Int);

                cmd.Parameters["@CoachNumber"].Value = Convert.ToInt32(DropDownListCoach.SelectedValue);

                cmd.ExecuteNonQuery();

                ButtonDelete.Enabled = false;
                LabelMessage.Text = "The Coach " + DropDownListCoach.SelectedValue + " has been deleted";
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