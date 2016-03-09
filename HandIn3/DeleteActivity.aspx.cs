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
    public partial class DeleteActivity : System.Web.UI.Page
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

            DropDownListActivity.AutoPostBack = true;
        }

        public void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select activitynumber as [Activity Number], Title, Description, Weekday, Time, picturelink as Picture, coach.name as [Coach Name] from activities, coach where coachid = coachnumber";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewActivity.DataSource = rdr;
                GridViewActivity.DataBind();

                rdr.Close();
                rdr = cmd.ExecuteReader();

                DropDownListActivity.DataSource = rdr;
                DropDownListActivity.DataTextField = "Title";
                DropDownListActivity.DataValueField = "Activity Number";
                DropDownListActivity.DataBind();
                DropDownListActivity.Items.Insert(0, "Select an Activity");
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

        protected void DropDownListActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListActivity.SelectedIndex != 0)
            {
                LabelMessage.Text = "You chose activity " + DropDownListActivity.SelectedValue;
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
            string sqlDel = "delete from activities where ActivityNumber = @ActivityNumber";
            // remember where : else every row will be deleted

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlDel, conn);
                cmd.Parameters.Add("@ActivityNumber", SqlDbType.Int);

                cmd.Parameters["@ActivityNumber"].Value = Convert.ToInt32(DropDownListActivity.SelectedValue);

                cmd.ExecuteNonQuery();

                ButtonDelete.Enabled = false;
                LabelMessage.Text = "The activity " + DropDownListActivity.SelectedValue + " has been deleted";
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