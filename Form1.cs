using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace Captions_Hide
{
    public partial class Form1 : Form
    {
        //鼠标点击坐标位置
        int X, Y;        
        private const long WM_GETMINMAXINFO = 0x24;

        public struct PointAPI
        {
            public int x;
            public int y;
        }

        public struct MinMaxInfo
        {
            public PointAPI ptReserved;
            public PointAPI ptMaxSize;
            public PointAPI ptMaxPosition;
            public PointAPI ptMinTrackSize;
            public PointAPI ptMaxTrackSize;
        }

        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }

        //[DllImport("User32.dll", CharSet = CharSet.Auto)]
        //public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        //[DllImport("User32.dll")]
        //private static extern IntPtr GetWindowDC(IntPtr hWnd);

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            //const int WM_NCPAINT = 0x85;
            //if (m.Msg == WM_NCPAINT)
            //{
            //    IntPtr hdc = GetWindowDC(m.HWnd);
            //    if ((int)hdc != 0)
            //    {
            //        Graphics g = Graphics.FromHdc(hdc);
            //        g.FillRectangle(Brushes.Red, new Rectangle(0, 0, 300, 23));
            //        g.Flush();
            //        ReleaseDC(m.HWnd, hdc);
            //    }
            //}
            if (m.Msg == WM_GETMINMAXINFO)
            {
                MinMaxInfo mmi = (MinMaxInfo)m.GetLParam(typeof(MinMaxInfo));
                mmi.ptMinTrackSize.x = this.MinimumSize.Width;
                mmi.ptMinTrackSize.y = this.MinimumSize.Height;
                if (this.MaximumSize.Width != 0 || this.MaximumSize.Height != 0)
                {
                    mmi.ptMaxTrackSize.x = this.MaximumSize.Width;
                    mmi.ptMaxTrackSize.y = 150;
                    //this.FormBorderStyle = FormBorderStyle.None;
                }
                mmi.ptMaxPosition.x = 1;
                mmi.ptMaxPosition.y = 800;
                System.Runtime.InteropServices.Marshal.StructureToPtr(mmi, m.LParam, true);
            }
        }

        private void searchbar_KeyPrress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            ColorDialog colorDia = new ColorDialog();

            if (colorDia.ShowDialog() == DialogResult.OK)
            {
                //获取所选择的颜色
                Color colorChoosed = colorDia.Color;
                //改变panel的背景色
                this.BackColor = colorChoosed;
                
                SearchBar.BackColor = colorChoosed;

            }
        }

        //鼠标按下监听事件，记录鼠标按下时的坐标

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                X = e.X;
                Y = e.Y;
            }
        }
        //鼠标移动监听事件，改变窗体坐标位置，实现窗体移动效果

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (e.X - X), this.Location.Y + (e.Y - Y));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {               
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序


                byte[] encodeBytes = System.Text.Encoding.UTF8.GetBytes(SearchBar.Text);

                string inputString= System.Text.Encoding.UTF8.GetString(encodeBytes);
                string strCMD = @"E:\SKILL_INSTALL\Python35\Python.exe E:\SKILL_PROJECT\GITHUB\ECDICT\stardict.py --queryString=" + inputString;

                //向cmd窗口发送输入信息
                p.StandardInput.WriteLine(strCMD + "&exit");

                p.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息
                string output = p.StandardOutput.ReadToEnd();
                string resultStr = string.Empty;
                this.Controls.RemoveByKey("SearchResult");
                var x = SearchBar.Location.X + 150;
                var y = SearchBar.Location.Y;
                Label lab = new Label();
                lab.Name = "SearchResult";
                lab.Font = new Font("微软雅黑", 10, FontStyle.Italic);
                lab.Location = new Point(x, y);
                this.Controls.Add(lab);
                if (output.IndexOf('{') > 0 && output.LastIndexOf('}') > 0)
                {
                    resultStr = output.Substring(output.IndexOf('{'), output.LastIndexOf('}') - output.IndexOf('{') + 1);
                    resultStr = JsonConvert.DeserializeObject<Payload>(resultStr).translation.Replace('\n', '\t');
                }
                else
                {
                    resultStr = "没找到哦~";
                }

                lab.Size = new Size(resultStr.Length * 20, 30);
                lab.Text = resultStr;


                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
    }
}
