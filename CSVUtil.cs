using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Running_game
{
    public static class CSVUtil
    {
        public static List<ListViewItem> LoadCSV()
        {
            ListViewItem item;

            List<ListViewItem> list = new List<ListViewItem>();

            string[] buff = File.ReadAllLines("test.csv", Encoding.UTF8);
      

            foreach (string d in buff)
            {
                string[] split = d.Split(',');

                if (split.Length > 0)
                {
                    if(split[0] != "닉네임")
                    {
                        item = new ListViewItem(split);
                        list.Add(item); 
                    }
                    
                }
            }

            return list;
        }

        public static bool SaveCSV(List<ListViewItem> items)
        {
            List<string> buff = new List<string>();

            buff.Add("닉네임,점수");

            foreach (ListViewItem item in items)
            {
                buff.Add(item.SubItems[0].Text +","+ item.SubItems[1].Text);
            }

            File.WriteAllLines("test.csv", buff.ToArray(), Encoding.UTF8);


            return true;
        }

    }
}
