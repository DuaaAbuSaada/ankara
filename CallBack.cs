using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Spatial_Analysis_On_Housing_Prices_Ankara
{
    [ComVisible(true)]
    public class CallBack
    {
        Form1 f1;
        public CallBack(Form1 _f1)
        {
            f1 = _f1;
        }
        public void info(string a)
        {
            int k = Convert.ToInt32(Form1.mi.Eval("searchpoint(frontwindow(),commandinfo(1),commandinfo(2))"));
            string tabloadi = "";
            for (int i = 1; i <= k; i++)
            {
                tabloadi = Form1.mi.Eval("SearchInfo(" + i.ToString() + ",1)");
                String row_id = Form1.mi.Eval("SearchInfo(" + i.ToString() + ",2)");
                Form1.mi.Do("Fetch rec " + row_id + " From " + tabloadi);
                if ((tabloadi == "Thiessen_all"))
                {
                    f1.Invoke(new mapinfo(f1.f3.fill_form));
                    
                }

            }


        }
        delegate void mapinfo();
    }
}


