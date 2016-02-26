using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace sh_cgxt
{
    public partial class commodity_add : Form
    {
        public commodity_add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            Name_Text.Text = "";
            Amount_Text.Text = "";
            Price_Text.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlHelper msh = new MySqlHelper();
            string DT = DateTime.Now.ToLocalTime().ToString();
            string insert_ID=commodity_insert(msh);
            string insert_log_ID = commodity_log_insert(msh, insert_ID, DT);
            MessageBox.Show("商品编号为:" + insert_ID + "\r\n" + "流水编号为:" + insert_log_ID);
            reset();
        }
        private string commodity_insert(MySqlHelper msh)
        {
            MySqlParameter[] commodity_msp = new MySqlParameter[3];
            commodity_msp[0] = new MySqlParameter("?name", MySqlDbType.VarChar, 60);
            commodity_msp[0].Value = Name_Text.Text;
            commodity_msp[1] = new MySqlParameter("?amount", MySqlDbType.Int32);
            commodity_msp[1].Value = Amount_Text.Text;
            commodity_msp[2] = new MySqlParameter("?price", MySqlDbType.Int32);
            commodity_msp[2].Value = Price_Text.Text;
            //DataTable dt = msh.ExecuteDataTable("INSERT into commodity(name,amount,price) VALUES(?name,?amount,?price);select LAST_INSERT_ID()");
            //string insert_ID = dt.Rows[0][0].ToString();
            //return insert_ID;
            string insert_ID = msh.ExecuteLastID("INSERT into commodity(name,amount,price) VALUES(?name,?amount,?price)", commodity_msp).ToString();
            return insert_ID;
            //msh.ExecuteNonQuery("INSERT into commodity(name,amount,price) VALUES(?name,?amount,?price)", commodity_msp);
            //return "";
        }
        private string commodity_log_insert(MySqlHelper msh,string insert_ID,string DT)
        {
            MySqlParameter[] commodity_msp = new MySqlParameter[6];
            commodity_msp[0] = new MySqlParameter("?commodity_ID",MySqlDbType.Int32);
            commodity_msp[0].Value = "34";
            commodity_msp[1] = new MySqlParameter("?commodity_Name", MySqlDbType.VarChar,60);
            commodity_msp[1].Value = Name_Text.Text;
            commodity_msp[2] = new MySqlParameter("?event", MySqlDbType.VarChar,60);
            commodity_msp[2].Value = "新增";
            commodity_msp[3] = new MySqlParameter("?amount_change", MySqlDbType.Int32);
            commodity_msp[3].Value = Amount_Text.Text;
            commodity_msp[4] = new MySqlParameter("?price_change", MySqlDbType.Int32);
            commodity_msp[4].Value = Price_Text.Text;
            commodity_msp[5] = new MySqlParameter("?datetime", MySqlDbType.DateTime);
            commodity_msp[5].Value = DT;
            string insert_log_ID = msh.ExecuteLastID("INSERT into commodity_log(commodity_ID,commodity_Name,event,amount_change,price_change,datetime) VALUES(?commodity_ID,?commodity_Name,?event,?amount_change,?price_change,?datetime)", commodity_msp).ToString();
            return insert_log_ID;
            //msh.ExecuteNonQuery("INSERT into commodity_log(commodity_ID,commodity_Name,event,amount_change,price_change,datetime) VALUES(?commodity_ID,?commodity_Name,?event,?amount_change,?price_change,?datetime)", commodity_msp);
            //return "";
        }
    }
}
