using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sh_cgxt
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void 库存信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 入库ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            commodity_add commodity_insert = new commodity_add();
            bool flag = false;
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == commodity_insert.Name)
                {
                    flag = true;
                }
            }
            if (flag == false)
            {
                commodity_insert.MdiParent = this;
                commodity_insert.Show();
            }
        }

        private void 添加员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee_add emadd = new employee_add();
            bool flag = false;
            for (int i=0;i<this.MdiChildren.Length;i++)
            {
                if(this.MdiChildren[i].Name==emadd.Name)
                {
                    flag = true;
                }
            }
            if (flag == false)
            {
                emadd.MdiParent = this;
                emadd.Show();
            }
        }
    }
}
