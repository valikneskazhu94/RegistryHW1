using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
namespace RegistryD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Show()
        {
            listBox1.Items.Clear();
            RegistryKey currKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
            foreach (var items in currKey.GetValueNames())
            {
                listBox1.Items.Add(items);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            myKey.SetValue("Tvarb", Application.ExecutablePath);
            Show();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedIndex.ToString());
            RegistryKey myKey =Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
         
            myKey.DeleteValue(listBox1.SelectedItem.ToString());
            Show();
          
        }
    }
}
