using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Spatial_Analysis_On_Housing_Prices_Ankara
{
    public partial class Ankara_Neighbourhood_Histogram : Form
    {
        public static MapInfo.MapInfoApplication mi;
        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public Ankara_Neighbourhood_Histogram()
        {
            InitializeComponent();
        }

        public void fill_form()
        {
            label2.Text = Form1.mi.Eval("Thiessen_all.Ilcedi");
            //Form1.mi.Do("select * from Thiessen_all where Name=\"" + label2.Text + "\" into Sel1 noselect");
            if (label2.Text == "Cankaya")
            {
                Form1.mi.Do("select range_id, sum(No_Mall) from Thiessen_all where Ilcedi=\"" + label2.Text + "\" group by range_id order by range_id into Sel1 noselect");
                int p1 = tabPage4.Handle.ToInt32();
                Form1.mi.Do("set next document parent " + p1.ToString() + "style 1");
                Form1.mi.Do("Graph Range_id, COL2  From sel1 Using \"" + "C:/Users/Toshiba/Desktop/GGIT-1ST/3rd_semester/Thesis/Work/MapInfo/Graphs/No_Mall.3tf" + "\"Series In Columns");
                Form1.mi.Do("set graph title \"No_Mall\"");
            }
            else
            {
                Form1.mi.Do("select range_id, sum(No_Mall) from Thiessen_all where Ilcedi<>\"" + label2.Text + "\" group by range_id order by range_id into Sel2 noselect");
                int p1 = tabPage4.Handle.ToInt32();
                Form1.mi.Do("set next document parent " + p1.ToString() + "style 1");
                Form1.mi.Do("Graph Range_id, COL2  From sel2 Using \"" + "C:/Users/Toshiba/Desktop/GGIT-1ST/3rd_semester/Thesis/Work/MapInfo/Graphs/No_Mall_Rest.3tf" + "\"Series In Columns");
                Form1.mi.Do("set graph title \"No_Mall_Rest\"");
            }

            this.ShowDialog();
        }

    }
}


//Form1.mi.Do("select * from Neighbourhoods where ADI=\"" + label2.Text + "\" into Sel2 noselect");
//int p2 = tabPage2.Handle.ToInt32();
//Form1.mi.Do("set next document parent " + p2.ToString() + "style 1");
//Form1.mi.Do("Graph ADI,AvG_Price_Per_Sq_meter From Sel2 Using \"" + "C:/Users/Toshiba/Desktop/GGIT-1ST/3rd_semester/Thesis/Work/MapInfo/Graphs/AvG_Histogram.3tf" + "\"Series In Columns");
//Form1.mi.Do("set graph title \"Total Number of  Neighbourhoods within Each AvG Price Per m2\"");



//Form1.mi.Do("select * from Thiessen_all where Name=\"" + label2.Text + "\" into Sel noselect");
//int p = tabPage1.Handle.ToInt32();
//Form1.mi.Do("set next document parent " + p.ToString() + "style 1");
//Form1.mi.Do("Graph Name,AvG_Price_Per_Sq_meter, Max_Price_Per_Sq_meter From Sel Using \"" + "C:/Users/Toshiba/Desktop/GGIT-1ST/3rd_semester/Thesis/Work/MapInfo/Graphs/AvG_and_Max_Bar.3tf" + "\"");
//Form1.mi.Do("set graph title \"Average and Maximum Housing Prices Per Square Meter\"");


//Form1.mi.Do("select * from Thiessen_all where Name=\"" + label2.Text + "\" into Sel2 noselect");
//int p2 = tabPage2.Handle.ToInt32();
//Form1.mi.Do("set next document parent " + p2.ToString() + "style 1");
//Form1.mi.Do("Graph Name,AvG_Price_Per_Sq_meter, Min_Price_Per_Sq_meter From Sel2 Using \"" + "C:/Users/Toshiba/Desktop/GGIT-1ST/3rd_semester/Thesis/Work/MapInfo/Graphs/AvG_and_Min_Pie.3tf" + "\"");
//Form1.mi.Do("set graph title \"Average and Minimum Prices Per Square Meter\"");

//Form1.mi.Do("select * from Thiessen_all where Name=\"" + label2.Text + "\" into Sel3 noselect");
//int p3 = tabPage3.Handle.ToInt32();
//Form1.mi.Do("set next document parent " + p3.ToString() + "style 1");
//Form1.mi.Do("Graph Name, Area_m2, No_of_room, Floor, No_University, No_Hospital, No_Mall, No_Transportation, No_School, No_ATM, No_Bank, No_Migros, No_Budget_Supermarkets From sel3 Using \"" + "C:/Users/Toshiba/Desktop/GGIT-1ST/3rd_semester/Thesis/Work/MapInfo/Graphs/All_Categories.3tf" + "\"Series In Columns");
//Form1.mi.Do("set graph title \"All Categories\"");