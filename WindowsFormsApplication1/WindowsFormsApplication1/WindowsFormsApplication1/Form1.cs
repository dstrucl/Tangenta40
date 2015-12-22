using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            fux.invoiceRequest1 inv = new fux.invoiceRequest1() ;
            fux.echoRequest echo = new fux.echoRequest("tutu");

            fux.echoResponse echoRsp = new fux.echoResponse();

        }
    }
}
