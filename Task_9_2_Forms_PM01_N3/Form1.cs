using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_9_2_Forms_PM01_N3
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
				textBox1.Text = "";
				StreamReader fileIn = new StreamReader("text.txt");
				string text = fileIn.ReadToEnd();
				fileIn.Close();
				string[] newText = Regex.Split(text, "[\n]+");
				
				for(int i = 0; i < newText.Length; i++)
				{
					for(int j = 0; j < newText[i].Length; j++)
					{
						if (newText[i][j] == ' ')
						{
							textBox1.Text += string.Format(newText[i] + "\n");
							break;
						}
					}
				}
			}
			catch
			{
				textBox2.Text = string.Format("Ошибка. Вероятно, указанный файл не найден.");
			}
		}
	}
}
