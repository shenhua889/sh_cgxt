using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace SH_Wxcl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 读取Excel数据返回DataTable
        /// </summary>
        /// <param name="Excel_File">Excel的路径</param>
        /// <returns></returns>
        private DataTable GetExcel(string Excel_File)
        {
            string connStr = "";
            string FileType = System.IO.Path.GetExtension(Excel_File);
            if (string.IsNullOrEmpty(FileType)) return null;
            if (FileType == ".xls")
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Excel_File + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            else
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Excel_File + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            string sql_F = "select * from [{0}]";
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;
            DataTable dtSheetName = null;
            try
            {
                conn = new OleDbConnection(connStr);
                conn.Open();
                string SheetName = "";
                dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                da = new OleDbDataAdapter();
                for (int i = 0; i < dtSheetName.Rows.Count; i++)
                {
                    SheetName = dtSheetName.Rows[i]["TABLE_NAME"].ToString();
                    if (SheetName.Contains("$") && !SheetName.Replace("'", "").EndsWith("$"))
                    {
                        continue;
                    }
                    da.SelectCommand = new OleDbCommand(string.Format(sql_F, SheetName), conn);

                    DataSet ds = new DataSet();
                    da.Fill(ds, SheetName);
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

                conn.Close();
                da.Dispose();
                conn.Dispose();
            }
            return null;
        }
        /// <summary>
        /// 读取Csv数据返回表格
        /// </summary>
        /// <param name="FilePath">路径</param>
        /// <returns></returns>
        private DataTable GetCsv(string FilePath)
        {
            DataTable dt = new DataTable();
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(FilePath, FileMode.OpenOrCreate);
                sr = new StreamReader(new BufferedStream(fs), System.Text.Encoding.Default);
                string[] columns = sr.ReadLine().Split('\t');
                string[] Datas = null;

                foreach (string column in columns)
                {
                    dt.Columns.Add(column);
                }
                while (!sr.EndOfStream)
                {
                    DataRow dr = dt.NewRow();
                    Datas = sr.ReadLine().Split('\t');
                    dr.ItemArray = Datas;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                fs.Close();
                sr.Close();
            }
            return null;
        }
        /// <summary>
        /// 追加输入到Csv中
        /// </summary>
        /// <param name="NewSelect">新的数据</param>
        /// <param name="FilePath">路径</param>
        private void AppendOrCreateToCsv(List<string> NewSelect, string FilePath)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                fs = new FileStream(FilePath, FileMode.OpenOrCreate);
                sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);
                foreach (string each in NewSelect)
                {
                    sb.Append(each + "/n");
                }
                sw.Write(sb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
        /// <summary>
        /// 把DataTable表格保存城Csv
        /// </summary>
        /// <param name="dt">需要保存的表格</param>
        /// <param name="FilePath">保存路径</param>
        private void DataTableToCsv(DataTable dt, string FilePath)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                fs = new FileStream(FilePath, FileMode.OpenOrCreate);
                sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(dt.Columns[i].ColumnName + "\t");//"\t"切换到同行的下一个单元格
                }
                sb = sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");//"\n"切换到下一行
                sw.Write(sb);
                sb = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sb.Append(dt.Rows[i][j].ToString() + "\t");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\n");
                }
                sw.Write(sb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
        /// <summary>
        /// Form清空
        /// </summary>
        private void Clear()
        {
            dataGridView1.DataSource = null;
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
        }
        /// <summary>
        /// 获取表中的商品编码
        /// 赋值到列表中
        /// </summary>
        /// <param name="list">去重之后的商品编码</param>
        private void ListToCheckedListBox(List<string> list)
        {
            foreach (string each in list)
            {
                checkedListBox1.Items.Add(each);
            }
        }
        private void ListToCheckedListBox2(List<string> list)
        {
            foreach (string each in list)
            {
                checkedListBox2.Items.Add(each);
            }
        }
        /// <summary>
        /// 把上次选择的选项 选上
        /// </summary>
        /// <param name="list">上次选上的选项</param>
        private void SetCheckListBox(List<string> list)
        {
            foreach (string each in list)
            {
                if (checkedListBox1.Items.Contains(each))
                {
                    checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(each), true);
                }
            }
        }
        /// <summary>
        /// 对表格中重复的订单编号合并
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable Table_HB(DataTable dt)
        {
            DataTable dt_HB = dt.Clone();
            List<string> DDBH = new List<string>();//订单编号
            List<string> BZ = new List<string>();//备注
            List<string> SP = new List<string>();//商品编号和数量
            foreach (DataRow dr in dt.Rows)
            {
                //订单编号没有存在
                if (!DDBH.Contains(dr["订单编号"].ToString()))
                {
                    DataRow temp_dr = dt_HB.NewRow();
                    temp_dr.ItemArray = dr.ItemArray;
                    dt_HB.Rows.Add(temp_dr);
                    DDBH.Add(dr["订单编号"].ToString());
                    BZ.Add(dr["用户留言"].ToString());
                    SP.Add(dr["商品编号"].ToString() + "*" + dr["数量"].ToString() + "册");
                }
                else
                {
                    int i = DDBH.IndexOf(dr["订单编号"].ToString());
                    BZ[i] = BZ[i] + dr["用户留言"].ToString() + "  ";
                    SP[i] = SP[i] + "  " + dr["商品编号"].ToString() + "*" + dr["数量"].ToString() + "册";
                }
            }
            //添加备注字段
            dt_HB.Columns.Add("备注");
            for (int i = 0; i < dt_HB.Rows.Count; i++)
            {
                dt_HB.Rows[i]["备注"] = BZ[i] + SP[i];
            }
            return dt_HB;
        }
        private DataTable Table_SX(DataTable dt)
        {
            List<string> SPBM_True = new List<string>();
            List<string> YF_True = new List<string>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    SPBM_True.Add(checkedListBox1.Items[i].ToString());
                }
            }
            for (int j = 0; j < checkedListBox2.Items.Count; j++)
            {
                if (checkedListBox2.GetItemChecked(j))
                {
                    YF_True.Add(checkedListBox2.Items[j].ToString());
                }
            }
            DataTable dt_SX = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                if (SPBM_True.Contains(dr["商品编码"].ToString()) && !YF_True.Contains(dr["运费(自提)"].ToString()))
                {
                    DataRow Temp_dr = dt_SX.NewRow();
                    Temp_dr.ItemArray = dr.ItemArray;
                    dt_SX.Rows.Add(Temp_dr);
                }
            }
            return dt_SX;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            Clear();
            DataTable dt = new DataTable();
            List<string> SPBM = new List<string>();
            List<string> YF = new List<string>();
            string dataFile = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string[] arrystring = dataFile.Split('.');
            if (arrystring[arrystring.Length - 1].ToLower() == "xls" || arrystring[arrystring.Length - 1].ToLower() == "xlsx")
            {
                dt = GetExcel(@dataFile);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                //商品编码显示
                foreach (DataRow dr in dt.Rows)
                {
                    if (!SPBM.Contains(dr["商品编码"].ToString()))
                    {
                        SPBM.Add(dr["商品编码"].ToString());
                    }
                    if (!YF.Contains(dr["运费(自提)"].ToString()))
                    {
                        YF.Add(dr["运费(自提)"].ToString());
                    }
                }
                SPBM.Sort();
                ListToCheckedListBox(SPBM);
                ListToCheckedListBox2(YF);
                checkedListBox2.SetItemChecked(checkedListBox2.Items.IndexOf("自提"), true);
                //商品编号打勾
                if (System.IO.File.Exists(@"F:\SH_Wxcl\1.csv"))//判断是否有该文件
                {
                    DataTable Table_SetSPBM = GetCsv(@"F:\SH_Wxcl\1.csv");
                    List<string> SetSPBM = new List<string>();
                    List<string> SPDW = new List<string>();
                    foreach (DataRow dr in Table_SetSPBM.Rows)
                    {
                        SetSPBM.Add(dr[0].ToString());
                        SPDW.Add(dr[0].ToString());
                    }
                    SetCheckListBox(SetSPBM);
                }
                else
                    MessageBox.Show("文件  \rF:/SH_Wxcl/1.csv \r 不存在需手动选择商品编码");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataTable dt_New = Table_HB(Table_SX(dt));
            string Csv_name = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
            string File = @"F:\SH_Wxcl\out\" + Csv_name + ".xls";
            if (!Directory.Exists(@"F:\SH_Wxcl\out\"))
            {
                Directory.CreateDirectory(@"F:\SH_Wxcl\out\");
            }
            DataTableToCsv(dt_New, File);
            MessageBox.Show("文件已经保存在：\r" + File);
        }
    }
}
