using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using Ionic.Zlib;
using System.Windows;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<string> Files = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {  foreach(object files in openFileDialog1.FileNames)
                {
                    textBox1.Enabled = true;
                    textBox1.Text = files.ToString();
                    listBox1.Items.Add(files);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count!=0)
            {
                while(listBox1.SelectedIndex!=-1)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string password = textBox2.Text;
            textBox2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                label2.Visible = false;
                textBox3.Enabled = true;
                textBox3.Visible = true;
                textBox3.Text = folderBrowserDialog1.SelectedPath.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {   

            string a = textBox4.Text;
            string b = textBox3.Text;
            if(!checkBox1.Checked)
            {
                foreach (object item in listBox1.Items)
                {
                    try
                    {
                        Files.Add(item.ToString());
                        using (ZipFile DocZip = new ZipFile(System.Text.Encoding.Default))
                        {
                            if (Files.Count > 0)
                            {                             
                                DocZip.AddFiles(Files, false, "");
                                DocZip.Save(b + "\\" + a + ".ZIP");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The files are Zipped to:" + b + "\\" + a);
                        Process.Start(b);
                        Application.Restart();
                        throw ex;
                    }
                }

                }
                else{
                    foreach (object item in listBox1.Items)
                    {
                        try
                        {
                            Files.Add(item.ToString());
                            using (ZipFile DocZip = new ZipFile())
                            {
                                if (Files.Count > 0)
                                {
                                     DocZip.Password = textBox2.Text;
                                     DocZip.AddFiles(Files, false, "");
                                     DocZip.Save(b + "\\" + a + ".ZIP");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The files are Zipped to:" + b + "\\" + a);
                            Process.Start(b);
                            Application.Restart();
                            throw ex;
                        }

                    }
            
            }
            MessageBox.Show("The files are Zipped to:" + b + "\\" + a);
            Process.Start(b );
            Application.Restart();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string a = textBox4.Text;
            string b = textBox3.Text;
            foreach (object item in listBox1.Items)
            {
                try
                {
                    using (Ionic.Zip.ZipFile zip1 = Ionic.Zip.ZipFile.Read(item.ToString()))
                    {
                        zip1.ExtractAll(b + "\\" + a, Ionic.Zip.ExtractExistingFileAction.DoNotOverwrite);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The files are Extracted to:" + b + "\\" + a);
                    Process.Start(b);
                    Application.Restart();
                    throw ex;
                }
            }
            MessageBox.Show("The files are Extracted to:" + b + "\\" + a);
            Process.Start(b);
            Application.Restart();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.Visible = true;
                button3.Enabled = true;
                textBox2.Enabled = true;
                button3.Visible = true;
            }
            else
            {
                textBox2.Visible = false;
                button3.Enabled = false;
                textBox2.Enabled = false;
                button3.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button5.Enabled = true;
                button5.Visible = true;
                textBox4.Visible = true;
                textBox4.Enabled= true;
            }
            else
            {
                button5.Enabled = false;
                button5.Visible = false;
                textBox4.Visible = false;
                textBox4.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                button6.Enabled = true;
                button6.Visible = true;
                textBox4.Visible = true;
                textBox4.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
                button6.Visible = false;
                textBox4.Visible = false;
                textBox4.Enabled = false;
            }

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if(textBox4.Text== "Enter the folder Name.")
            {
                textBox4.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Enter the folder Name.";
                textBox1.ForeColor = Color.Silver;
            }

        }
    }
}
