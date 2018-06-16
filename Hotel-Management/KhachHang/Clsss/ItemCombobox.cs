using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management
{
    class ItemCombobox
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
        public ItemCombobox(String text, Object value)
        {
            this.Text = text;
            this.Value = value;
        }
    }
}
