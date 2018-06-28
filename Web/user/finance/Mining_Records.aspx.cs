using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;
using System.Data.SqlClient;

namespace Web.user.finance
{
    public partial class Mining_Records : PageCore
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
          
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            bind_repeater(GetData(), Repeater1, "GiveTime desc", tr1, AspNetPager1);
        }
        private DataSet GetData()
        { 
            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("select RandMoney,GiveTime from tb_Rand where Flag=2 and  UserID =" + getLoginID());
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            DataSet DS = new DataSet();
            DS.Tables.Add(dt);
            return DS;  
        }

    }
}