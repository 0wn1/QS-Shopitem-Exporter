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

namespace Quasar_Shoptable_Itemcreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
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
                MessageBox.Show("Não há valor para o campo 'Item'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            richTextBox1.AppendText(luaTable + Environment.NewLine);
            numericUpDown3.UpButton();
            numericUpDown4.UpButton();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            richTextBox1.ForeColor = System.Drawing.Color.AntiqueWhite;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
            MessageBox.Show("Não há o que copiar para área de transferência", "Aviso",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
            }
            else
            {
            StringBuilder sb = new StringBuilder();

            foreach (string line in richTextBox1.Lines)
            sb.AppendLine(line);
            Clipboard.SetText(sb.ToString());

            MessageBox.Show("Copiado para área de transferência", "Sucesso",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
