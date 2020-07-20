using RestReminder.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestReminder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            setVisibleOpacity();
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            setMinimumOpacity();
        }

        private void setMinimumOpacity()
        {
            this.Opacity = 0.2;
        }
        private void setVisibleOpacity()
        {
            this.Opacity = 0.4;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //if (File.Exists(("C:/Users/Administrator/Documents/PERSONAL/REPOSITORY/RestReminder/RestReminder/settings.ini")) == false)
            //    MessageBox.Show("false");

            Settings.getSetting().getSettings("App", "literal2", "0");



            //Settings.initializeSettings(@"C:/Users/Administrator/Documents/PERSONAL/REPOSITORY/RestReminder/RestReminder/settings.ini");
            //MessageBox.Show(Settings.getSetting().getSettings("App", "literal", "1"));
        }
    }
}
