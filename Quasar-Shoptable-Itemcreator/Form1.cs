using FastColoredTextBoxNS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quasar_Shoptable_Itemcreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fastColoredTextBox1.Language = Language.Lua;
            //fastColoredTextBox1.Font = new Font("Consolas", 12F);
            //fastColoredTextBox1.ForeColor = Color.AntiqueWhite;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tableNumber = (int)numericUpDown4.Value;
            string name = textBox1.Text ?? string.Empty;
            int price = (int)numericUpDown1.Value;
            int amount = (int)numericUpDown2.Value;
            string item;
            int slot = (int)numericUpDown3.Value;

            if (checkBox1.Checked == true)
            {
                item = checkBox1.Text;
            }
            else
            {
                item = checkBox2.Text;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("There is no value for the 'Item' field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string luaTable = string.Format(
                "[{0}] = {{\n" +
                "    name = '{1}',\n" +
                "    price = {2},\n" +
                "    amount = {3},\n" +
                "    info = {{}},\n" +
                "    type = '{4}',\n" +
                "    slot = {5}\n" +
                "}},",
                tableNumber, name, price, amount, item, slot);

            fastColoredTextBox1.AppendText(luaTable + Environment.NewLine);
            numericUpDown3.UpButton();
            numericUpDown4.UpButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            fastColoredTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fastColoredTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            fastColoredTextBox1.Font = new Font("Consolas", 12F);
            fastColoredTextBox1.ForeColor = Color.AntiqueWhite;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox1.Text == "")
            {
                MessageBox.Show("There is nothing to copy to clipboard", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Clipboard.SetText(fastColoredTextBox1.Text);
                MessageBox.Show("Copied to clipboard", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
