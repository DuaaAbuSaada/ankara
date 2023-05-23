using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapInfo;
using System.Runtime.InteropServices;
using System.Diagnostics;




namespace Spatial_Analysis_On_Housing_Prices_Ankara
{
    public partial class Form1 : Form
    {
        public static MapInfo.MapInfoApplication mi;

        public static string win_id;
        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        
        CallBack callb;
        public Ankara_Neighbourhood_Histogram f3 = new Ankara_Neighbourhood_Histogram();

        public Form1()
        {
            InitializeComponent();
            callb = new CallBack(this);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Process[] _proceses = null;
            _proceses = Process.GetProcessesByName("MapInfo");
            foreach (Process proces in _proceses)
            {
                proces.Kill();
            }

            mi = new MapInfo.MapInfoApplication();
            int p = Ankara_Map.Handle.ToInt32();
            mi.Do("set next document parent " + p.ToString() + "style 1");
            mi.Do("set application window " + p.ToString());
            mi.Do("run application \"" + "C:/Users/Toshiba/Desktop/GGIT-1ST/3rd_semester/Thesis/Work/MapInfo/Spatial_Analysis_on_Housing_Prices_Ankara_City.WOR" + "\"");
            mi.SetCallback(callb);
            mi.Do("create buttonpad \"a\" as toolbutton calling OLE \"info\" id 2001");
            win_id = mi.Eval("frontwindow()");

        }

      

        private void neighboursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ankara_Neighborhood_Thematic f2 = new Ankara_Neighborhood_Thematic();
            f2.Show();
        }

        private void Info_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command id 2001");

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (mi != null)
            {
                // The form has been resized. 
                if (mi.Eval("WindowID(0)") != "")
                {
                    // Update the map to match the current size of the panel. 
                    MoveWindow((System.IntPtr)long.Parse(mi.Eval("WindowInfo(FrontWindow(),12)")), 0, 0, this.Ankara_Map.Width, this.Ankara_Map.Height, false);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sorted_Neighbourhoods_Houses_Pricing f5 = new Sorted_Neighbourhoods_Houses_Pricing();
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command  1705");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command  1706");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command 1702");
        }
    }
}
