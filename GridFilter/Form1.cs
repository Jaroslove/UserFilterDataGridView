using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridFilter
{
    public partial class Form1 : Form
    {
        private Dictionary<ComboBox, int> dic;
        private AdvanceFilter filter;
        private bool formLoad = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Model1 db = new Model1())
            {
                var source = db.Messages.ToList();
                dataGridView1.DataSource = source;
            }
            InitCombo();
            filter.Init();
            formLoad = true;
        }
        private void InitCombo()
        {
            dic = new Dictionary<ComboBox, int>();
            dic[comboBox1] = 1;
            dic[comboBox2] = 2;
            filter = new AdvanceFilter(dic, dataGridView1);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(formLoad)
            filter.Filtering(dic[(sender as ComboBox)]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formLoad)
                filter.Filtering(dic[(sender as ComboBox)]);
        }
    }
}
