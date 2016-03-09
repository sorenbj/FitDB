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
    public partial class Welcome : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = MyFitnessDB");
            SqlDataReader rdr = null;
            SqlCommand cmd = null;
            string sqlsel = "select Title, Weekday, Time, Picturelink from activities";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                rdr.Close();

                rdr = cmd.ExecuteReader();

                RepeaterWelcome.DataSource = rdr;
                RepeaterWelcome.DataBind();

                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
                dt = ds.Tables["sponsor"];

                RepeaterSponsor.DataSource = dt;
                RepeaterSponsor.DataBind();

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
    }
}