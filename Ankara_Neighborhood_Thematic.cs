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


namespace Spatial_Analysis_On_Housing_Prices_Ankara
{
    public partial class Ankara_Neighborhood_Thematic : Form
    {

        public Ankara_Neighborhood_Thematic()
        {
            InitializeComponent();
        }

        public void removetematik()
        {
            for (int k = Convert.ToInt16(Form1.mi.Eval("mapperinfo(" + Form1.win_id + ",9)")); k > 0; k = k - 1)
            {
                if (Convert.ToInt16(Form1.mi.Eval("layerinfo(" + Form1.win_id + "," + Convert.ToString(k) + ",24)")) == 3)
                {
                    Form1.mi.Do("remove map layer \"" + Form1.mi.Eval("layerinfo(" + Form1.win_id + "," + Convert.ToString(k) + ",1)") + "\"");
                }
            }
        }


        private void Ankara_Neighborhood_Thematic_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
        }


        private void thematic_Click_1(object sender, EventArgs e)
        {
            int n = Convert.ToInt16(textBox1.Text);
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            removetematik();



            thematic_column = listBox1.Text;

            //Select Max(AvG_Price_Per_Sq_meter) from Neighbourhoods into Selectionv

            Form1.mi.Do("select Max(" + thematic_column + ") from Neighbourhoods  into maxselect");
            Double maxx = Convert.ToDouble(Form1.mi.Eval("maxselect.col1"));
            Form1.mi.Do("select Min(" + thematic_column + ") from Neighbourhoods  into minselect");
            Double minn = Convert.ToDouble(Form1.mi.Eval("minselect.col1"));


            Form1.mi.Do("select " + thematic_column + " from Neighbourhoods order by " + thematic_column + " into sel noselect");

            int diff = Convert.ToInt32(maxx - minn);
            int range = diff / n;


            //int range = Convert.ToInt16(Form1.mi.Eval("int(tableinfo(sel,8)/" + Convert.ToString(n) + ")"));
            int c_range = Convert.ToInt16(255 / n);


            Form1.mi.Do("fetch first from sel");
            string r1 = Convert.ToString(Form1.mi.Eval("sel.col1"));
            string r2 = string.Empty;
            string cmstr = string.Empty;

            for (int i = 1; i < n; i++)
            {

                int temp = Convert.ToInt32(r1) + range;
                r2 = temp.ToString();

                //Form1.mi.Do("fetch rec " + Convert.ToString(i * range) + " from sel");
                string rgb = Convert.ToString(Form1.mi.Eval("RGB(255," + Convert.ToString((n - i) * c_range) + "," + Convert.ToString((n - i) * c_range) + ")"));
                cmstr = cmstr + r1 + ":" + r2 + " brush(2," + rgb + ",16777215), ";
                r1 = r2;

            }

            Form1.mi.Do("fetch last from sel");
            r2 = Convert.ToString(Form1.mi.Eval("sel.col1"));
            cmstr = cmstr + r1 + ":" + r2 + " brush(2,16711680,16777215)";

            Form1.mi.Do("shade window " + Form1.win_id + " Neighbourhoods with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);

            Form1.mi.Do("Set Next Document Parent " + p + " Style 1");
            Form1.mi.Do("Create Cartographic Legend From Window " + Form1.win_id + " Behind Frame From Layer 3");


        }


    }
}
