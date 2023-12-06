using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Running_game
{
    public partial class RankForm : Form
    {
  
        public RankForm()
        {
            InitializeComponent();
            
            string[] sitems = new string[] { Program.userName, GameForm.collectedHeart.ToString() };
            ListViewItem lvi = new ListViewItem(sitems);
            listView1.Items.Add(lvi);
            List<ListViewItem> list = CSVUtil.LoadCSV();
            list.ForEach(item => { listView1.Items.Add(item); });

        }

       
        public void AddMember(string name , string score)
        {
            string[] sitems = new string[] { name, name };
            ListViewItem lvi = new ListViewItem(sitems);
            listView1.Items.Add(lvi);
            listView1.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            string name = textBox1.Text.ToString();
            string score = textBox2.Text.ToString();
     
            AddMember(name,score);
            //formClear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void btnFileSave_Click(object sender, EventArgs e)
        {
            List<ListViewItem> listViewItemsList = listView1.Items.Cast<ListViewItem>().ToList();
            CSVUtil.SaveCSV(listViewItemsList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
                listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text;
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].Text;
                textBox1.Text = listView1.SelectedItems[1].Text;
            }
        }

    }

   
}
