using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusterGrowthModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            EC obj = new EC();
            obj.Seed();

            while(true)
            {
                obj.PerimeterDecide();
                obj.occupiedDecidedECGM(this);
            }
        }
    }
}
