using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Running_game
{
    public partial class RankForm : Form
    {
        ExtendedStudent std = new ExtendedStudent();
        const string fname = "data.csv";

        public RankForm()
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

        private void rankForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(fname) == false)
                {
                    FileStream fs = new FileStream(fname, FileMode.OpenOrCreate);
                    fs.Close();
                }
                else
                {
                    FileStream fs = File.OpenRead(fname);
                    StreamReader sr = new StreamReader(fs);
                    while (sr.EndOfStream == false)
                    {
                        string data = sr.ReadLine();
                        if (data == null) { break; }
                        string[] sitems = data.Split(',');
                        std.Id = sitems[0].ToString();
                        std.Name = sitems[1].ToString();
                        std.Score = sitems[3].ToString();
                        AddMember(std);
                    }
                    sr.Close();
                    fs.Close();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("에러: " + e1.ToString());
            }
        }

        public void AddMember(IStudent std)
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

            foreach (ListViewItem lvi in listView1.Items)
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

        private void btnClear_Click_1(object sender, EventArgs e)
        {

        }
    }

    public interface IStudent
    {
        string Id { get; set; }
        string Name { get; set; }
        string Score { get; set; }
    }

    public class ExtendedStudent : IStudent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Score { get; set; }
    }
}
