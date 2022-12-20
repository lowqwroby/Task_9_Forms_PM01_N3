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

namespace Task_9_1_Forms_PM01_N3
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				string[] temp = textBox1.Text.Split(' ');
				double[] numbers = new double[temp.Length];

				for(int i = 0; i < temp.Length; i++)
				{
					numbers[i] = double.Parse(temp[i]);
				}

				FileStream f = new FileStream("t.dat", FileMode.Open);
				BinaryWriter fOut = new BinaryWriter(f);

				for (int i = 0; i < numbers.Length; i++)
				{
					fOut.Write(numbers[i]);
				}

				fOut.Close();
				f = new FileStream("t.dat", FileMode.OpenOrCreate);
				BinaryReader fIn = new BinaryReader(f);
				long m = f.Length;

				double num = double.Parse(textBox2.Text);

				using (StreamWriter sw = new StreamWriter(File.Open("t.txt", FileMode.Create)))
				{
					for (long i = 0; i < m; i += 16)
					{
						f.Seek(i, SeekOrigin.Begin);
						double a = fIn.ReadDouble();
						if (a <= num)
						{
							textBox3.Text += string.Format(a + " ");
							sw.Write(a + " ");
						}
					}
				}

				fIn.Close();
				f.Close();
			}
			catch (FormatException)
			{
				MessageBox.Show("Введены неверные параметры!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch
			{
				MessageBox.Show("Неизвестная ошибка!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
