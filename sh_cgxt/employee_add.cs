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
    public partial class employee_add : Form
    {
        public employee_add()
        {
            InitializeComponent();
        }
        struct employee
        {
            public string Father_ID;
            public  string ID;
            public string Name;
            public string Combo_Text;
        };
        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            Father_Combo.SelectedIndex = 0;
            Name_Text.Text = "";
            Password_Text.Text = "";
        }
        employee[] em;
        private void employee_add_Load(object sender, EventArgs e)
        {
            Combo_Load();
        }
        private void Combo_Load()
        {
            MySqlHelper msh = new MySqlHelper();
            DataTable dt = msh.GetDataTable("select * from employee");
            Father_Combo.Items.Clear();
            Father_Combo.Items.Add("根目录");
            em = new employee[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr = dt.Rows[i];
                em[i].Father_ID = dr["Father_ID"].ToString();
                em[i].ID = dr["ID"].ToString();
                em[i].Name = dr["name"].ToString();
                em[i].Combo_Text = "";
            }
            em = Combo_sort(dt, em);
            foreach (employee temp in em)
            {
                Father_Combo.Items.Add(temp.Combo_Text);
            }
            Father_Combo.SelectedIndex = 0;
        }
        private employee[] Combo_sort(DataTable dt,employee[] em)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (em[i].Father_ID != "0")
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (em[j].ID == em[i].Father_ID)
                        {
                            employee temp = em[i];
                            for (int k = i - 1; k > j; k--)
                            {
                                em[k + 1] = em[k];
                            }
                            int space = em[j].Combo_Text.Length - em[j].Name.Length;
                            temp.Combo_Text = " ".PadLeft(space) + "|-" + temp.Name;
                            em[j + 1] = temp;
                        }
                    }
                }
                else
                {
                    em[i].Combo_Text = "  |-" + em[i].Name;
                }
            }
            return em;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlHelper msh = new MySqlHelper();
            string Name = Name_Text.Text;
            string Password = Password_Text.Text;
            string Father_ID = "";
            if (Father_Combo.SelectedIndex == 0)
            {
                Father_ID = "0";
            }
            else
            {
                Father_ID = em[Father_Combo.SelectedIndex - 1].ID;
            }
            long employee_ID = employee_insert(msh, Name, Password, Father_ID);
            long employee_log_ID = employee_log_insert(msh, employee_ID);
            MessageBox.Show("员工编号为:" + employee_ID + "\r\n" + "事件编号为:" + employee_log_ID);
            reset();
            
        }
        private long employee_insert(MySqlHelper msh,string Name,string Password,string Father_ID)
        {
            MySqlParameter[] msp = new MySqlParameter[3];
            msp[0] = new MySqlParameter("?name", MySqlDbType.VarChar, 60);
            msp[0].Value = Name;
            msp[1] = new MySqlParameter("?password", MySqlDbType.VarChar, 60);
            msp[1].Value = Password;
            msp[2] = new MySqlParameter("?father_ID", MySqlDbType.Int32);
            msp[2].Value = Father_ID;
            long employee_ID = msh.ExecuteLastID("insert into employee values(null,?name,?password,?father_ID)", msp);
            return employee_ID;
        }
        private long employee_log_insert(MySqlHelper msh, long employee_ID)
        {
            MySqlParameter[] msp = new MySqlParameter[3];
            msp[0] = new MySqlParameter("?employee_ID", MySqlDbType.Int32);
            msp[0].Value = employee_ID;
            msp[1] = new MySqlParameter("?event", MySqlDbType.VarChar, 60);
            msp[1].Value = "添加用户";
            msp[2] = new MySqlParameter("?datetime", MySqlDbType.DateTime);
            msp[2].Value = DateTime.Now.ToLocalTime().ToString();
            long employee_log_ID = msh.ExecuteLastID("insert into employee_log values(null,?employee_ID,?event,?datetime)", msp);
            return employee_log_ID;
        }
    }
}
