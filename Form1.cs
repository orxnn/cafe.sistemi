using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace cafesistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Click += pictureBox1_Click;
            pictureBox2.Click += pictureBox2_Click;
            pictureBox3.Click += pictureBox3_Click;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox5.Click += pictureBox5_Click;
            pictureBox4.Click += pictureBox4_Click;
            pictureBox9.Click += pictureBox9_Click;
            pictureBox8.Click += pictureBox8_Click;
            pictureBox7.Click += pictureBox7_Click;

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Cay ile keks - 3.0");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Amerikano  - 4.0");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Latte - 3.50");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Merci supu - 5.0");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Yumurta qayganaq- 5.00");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Kabab - 12.00");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Isgender Doner - 7.00");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Cay ile murebbe - 4.00");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Cola - 2.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hesabMetni = textBox4.Text.Replace(',', '.').Trim();
            string meblegMetni = textBox3.Text.Replace(',', '.').Trim();

            if (string.IsNullOrWhiteSpace(hesabMetni) ||
                !double.TryParse(hesabMetni, NumberStyles.Any, CultureInfo.InvariantCulture, out double hesab))
            {
                MessageBox.Show("Zehmet olmasa 'Yekun hesab' düyməsinə basın!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(meblegMetni) ||
                !double.TryParse(meblegMetni, NumberStyles.Any, CultureInfo.InvariantCulture, out double mebleg) ||
                mebleg < 0)
            {
                MessageBox.Show("Zehmet olmasa 'Məbləğ' xanasına keçərli ədəd daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mebleg < hesab)
            {
                MessageBox.Show("Daxil edilən məbləğ hesabdan azdır!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Clear();
            }
            else
            {
                double qaliq = mebleg - hesab;
                textBox2.Text = qaliq.ToString("0.00", CultureInfo.InvariantCulture);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string silinenYemek = listBox1.SelectedItem.ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                MessageBox.Show($"{silinenYemek} səbətdən silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (listBox1.Items.Count > 0)
            {
                string silinenYemek = listBox1.Items[listBox1.Items.Count - 1].ToString();
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                MessageBox.Show($"{silinenYemek} səbətdən silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Səbətdə silinəsi yemək yoxdur!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cavab = MessageBox.Show("Xanalar sıfırlansınmı?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cavab == DialogResult.Yes)
            {
                listBox1.Items.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Səbətdə yemək yoxdur!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double umumiHesab = 0;

                foreach (var item in listBox1.Items)
                {
                    string line = item.ToString();
                    string[] hisseler = line.Split('-');
                    if (hisseler.Length > 1)
                    {
                        string qiymetStr = hisseler[1].Trim().Replace(',', '.');
                        if (double.TryParse(qiymetStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double qiymet))
                        {
                            umumiHesab += qiymet;
                        }
                    }
                }

                textBox4.Text = umumiHesab.ToString("0.00", CultureInfo.InvariantCulture);
            }
        }
    }
}
