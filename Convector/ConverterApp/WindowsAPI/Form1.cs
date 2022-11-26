using PhysicValuesLib;

namespace WindowsAPI
{
    public partial class Form1 : Form
    {
        private ConverterManager _manager;

        public Form1()
        {
            InitializeComponent();
            _manager = new ConverterManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(_manager.GetPhysicValuesList().ToArray());
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox2.Items.AddRange(_manager.GetMeasureList(listBox1.SelectedItem.ToString()).ToArray());
            listBox3.Items.AddRange(_manager.GetMeasureList(listBox1.SelectedItem.ToString()).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(textBox1.Text);
                string physicValue = listBox1.SelectedItem.ToString();
                string from = listBox2.SelectedItem.ToString();
                string to = listBox3.SelectedItem.ToString();
                double result = _manager.GetConvertedValue(physicValue, value, from, to);
                textBox2.Text = result.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox1.Text = "";
        }
    }
}