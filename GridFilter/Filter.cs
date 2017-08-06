using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridFilter
{
    class Filter
    {
        ComboBox comboBox;
        int numberColumn;
        DataGridView grid;
        BindingList<string> sourceForComboBox;
        public Filter(ComboBox comboBox, int numberColumn, DataGridView grid)
        {
            this.comboBox = comboBox;
            this.numberColumn = numberColumn;
            this.grid = grid;
        }
        public void Init()
        {
            //sourceForComboBox = new BindingList<string>();
            //foreach (DataGridViewRow row in grid.Rows)
            //{                            
            //    if (row.Visible)
            //    {
            //        sourceForComboBox.Add(row.Cells[numberColumn].Value.ToString());
            //    }
            //}            
            //sourceForComboBox.Insert(0, "Все");
            //comboBox.DataSource = sourceForComboBox.Distinct().ToList();
            //comboBox.SelectedItem = 0;
            List<string> list = new List<string>();
            //comboBox.Sorted = true;
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Visible)
                {
                    list.Add(row.Cells[numberColumn].Value.ToString());
                }
            }
            List<string>lst = list.Distinct().OrderBy(a => a).ToList();
            //comboBox.Sorted = false;
            foreach (string item in lst)
            {
                comboBox.Items.Add(item);
            }
            comboBox.Items.Insert(0, "Все");
            comboBox.SelectedIndex = 0;
        }
        private void GetSourceForCombo()
        {
            try
            {
                List<string> list = new List<string>();
                string current = comboBox.SelectedItem.ToString();
                comboBox.Items.Clear();
                list = grid.Rows.Cast<DataGridViewRow>()
                    .Where(a => a.Visible == true)
                    .Select(a => a.Cells[numberColumn].Value.ToString())
                    .Distinct()
                    .OrderBy(a => a)
                    .ToList();
                list.Insert(0, "Все");
                list.ForEach(a => comboBox.Items.Add(a));
                int number = list.FindIndex(a => a == current);
                //comboBox.SelectedIndex = number;
            }
            catch { }
        }
        public void Filtering()
        {
            grid.CurrentCell = null;          
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Visible = IsVisibleRow(row);
            }
        }
        private bool IsVisibleRow(DataGridViewRow row)
        {
            //try
            //{
                Seaker.Set(numberColumn, comboBox.SelectedItem.ToString());
        
                grid.CurrentCell = null;
                bool temp = false;
                foreach (int item in Seaker.Get().Keys)
                {
                    string str = Seaker.Get()[item];                
                    if(str == "Все")
                    {
                        temp = true;
                    }
                    else
                    {
                        if(row.Cells[item].Value.ToString() == str)
                        {
                            temp = true;
                        }else{ temp = false; return false; }
                    }
            }
            return temp;
        //}
            //catch { return true; }
        }
        public string GetValueOfFilter()
        {
            return comboBox.SelectedValue.ToString();
        }
        public int GetNumberOfColumnOfFilter()
        {
            return numberColumn;
        }
        public void UsetInit()
        {
            GetSourceForCombo();
        }
    }
}
