using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Running_game
{
    public partial class Form3 : Form
    {
        Student std = new Student();
        const string fname = "data.csv";
        public Form3()
        {
            InitializeComponent();
        }

        public void formClear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        public void AddMember(Student std)
        {
            string[] sitems = new string[] { std.Id, std.Name, std.Score };
            ListViewItem lvi = new ListViewItem(sitems);
            listView1.Items.Add(lvi);
            listView1.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            std.Id = textBox1.Text.ToString();
            std.Name = textBox2.Text.ToString();
            std.Score = textBox3.Text.ToString();
            AddMember(std);
            formClear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
                listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text;
                listView1.SelectedItems[0].SubItems[2].Text = textBox3.Text;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void btnFileSave_Click(object sender, EventArgs e)
        {
            FileStream fs = File.Create(fname);
            StreamWriter sw = new StreamWriter(fs);

            foreach(ListViewItem lvi in listView1.Items)
            {
                std.Id = lvi.SubItems[0].Text;
                std.Name = lvi.SubItems[1].Text;
                std.Score = lvi.SubItems[2].Text;
                sw.WriteLine("{0},{1},{2}", std.Id, std.Name, std.Score);
            }
            sw.Close();
            fs.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Score { get; set; }
    }
}
