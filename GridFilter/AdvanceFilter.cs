using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridFilter
{
    class AdvanceFilter
    {
        private Dictionary<Filter, int> comboNumber;
        private DataGridView grid;        
        public AdvanceFilter(Dictionary<ComboBox, int> dic, DataGridView grid)
        {
            this.grid = grid;
            comboNumber = new Dictionary<Filter, int>();
            foreach (ComboBox comboBox in dic.Keys)
            {
                comboNumber[new Filter(comboBox, dic[comboBox], grid)] = dic[comboBox];
                Seaker.Set(dic[comboBox], "Все");
            }
        }
        public void Init()
        {
            foreach (Filter filter in comboNumber.Keys)
            {
                filter.Init();
            }
        }
        public void Filtering(int comboBox)
        {
            comboNumber.FirstOrDefault(x => x.Value == comboBox).Key.Filtering();
            foreach (var item in comboNumber.Keys)
            {
                if(comboNumber[item] != comboBox)
                    item.UsetInit();
            }
        }
    }
}
