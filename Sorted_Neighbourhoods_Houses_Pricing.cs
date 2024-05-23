using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spatial_Analysis_On_Housing_Prices_Ankara
{
    public partial class Sorted_Neighbourhoods_Houses_Pricing : Form
    {
        public static MapInfo.MapInfoApplication mi;
        public Sorted_Neighbourhoods_Houses_Pricing()
        {
            InitializeComponent();
        }

       

        private void Sorted_Neighbourhoods_Houses_Pricing_Load(object sender, EventArgs e)
        {
            //string ADI = string.Empty;
            //string AvG_Price_Per_Sq_meter = string.Empty;
            //string AMedian_Of_Prices_Per_Sq_meter = string.Empty;

            Form1.mi.Do("select Name , AvG_Price_Per_Sq_meter , Median_Of_Prices_Per_Sq_meter from Neighbourhoods order by AvG_Price_Per_Sq_meter desc into sel noselect ");

            int range = Convert.ToInt16(Form1.mi.Eval("int(tableinfo(sel,8)/" + Convert.ToString("9") + ")"));
         
            Form1.mi.Do("fetch first from sel");

            string r1 = null; // Convert.ToString(Form1.mi.Eval("sel.col1"));
            string r2 = null; //Convert.ToString(Form1.mi.Eval("sel.col2"));
            string r3 =  null; //Convert.ToString(Form1.mi.Eval("sel.col3"));
            int Cvalues = (range * 9) + 1;

            //listBox1.Items.Clear();

            for (int i = 1; i < Cvalues; i++)
            {
                Form1.mi.Do("fetch rec " + Convert.ToString(i ) + " from sel");
                r1 = Convert.ToString(Form1.mi.Eval("sel.col1"));
                r2 = Convert.ToString(Form1.mi.Eval("sel.col2"));
                r3 = Convert.ToString(Form1.mi.Eval("sel.col3"));

                string[] row = new string[] { r1, r2, r3 };
                dataGridView1.Rows.Add(row);

                //listBox1.Items.Add(r1 + "  " + r2+"   "+r3);
            }

         
        }

       
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridViewRow dr  = dataGridView1.CurrentRow;
            //string ADI = dr.Cells[0].Value.ToString();
            //string AVG = dr.Cells[1].Value.ToString();
            //string Median = dr.Cells[2].Value.ToString();

            //mi = new MapInfo.MapInfoApplication();
            //int p = panel1.Handle.ToInt32();
            //mi.Do("set next document parent " + p.ToString() + "style 1");
            //mi.Do("set application window " + p.ToString());
            //mi.Do("run application \"" + "C:/Users/Toshiba/Desktop/GGIT-1ST/3rd_semester/Thesis/Work/MapInfo/Spatial_Analysis_on_Housing_Prices_Ankara_City.WOR" + "\"");
            
            //Form1.mi.Do("select * from Neighbourhoods where ADI = \"" + ADI + "\" into sel2");
            //Form1.mi.Do("add map layer sel2 set map zoom entire layer sel2");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            string NAME = dr.Cells[0].Value.ToString();
            string AVG = dr.Cells[1].Value.ToString();
            string Median = dr.Cells[2].Value.ToString();
            Form1.mi.Do("select * from Neighbourhoods where Name = \"" + NAME + "\" into sel2");
            Form1.mi.Do("add map layer sel2 set map zoom entire layer sel2");
        }



        //listBox1.Items.Clear();
        //listBox1.Items.Add(ADI+"  "+ AVG+"  "+ Median);



    }




}

