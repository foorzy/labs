using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab2_linearTable
{
	public partial class Form1 : Form
	{
		UnorderedTable table = new UnorderedTable();
		UnorderedTable tableCpy = new UnorderedTable();
		UnorderedTable HalfTable = new UnorderedTable();
		UnorderedTable arrOfSize = new UnorderedTable();
		int temp;

		int size;

		public Form1()
		{
			InitializeComponent();
		}

		private void Setup_Table(object sender, EventArgs e)
		{
			try
			{
				size = Convert.ToInt32(textBox1.Text);
			}
			catch {
				size = 10;
			}

			table = UnorderedTable.FillRandom(size);
			arrOfSize = UnorderedTable.FillSize(size);
            
            

        }

		private void Display_table(object sender, EventArgs e)
		{

			string strValue = "";

			for (int i = 0; i < size; i++)
			{
				strValue += Convert.ToString(table[i]) + "\n";
			}

			richTextBox2.Text = strValue;

			string strKey = "";

			for (int i = 0; i < size; i++)
			{
				strKey += arrOfSize[i] + "." + "\n";
			}

			richTextBox1.Text = strKey;
		}

		private void On_Find(object sender, EventArgs e)
		{
			int number;
			try
			{
				number = Convert.ToInt32(textBox2.Text);
			}
			catch {
				number = 1;
			}

			int result;
			result = UnorderedTable.FindElement(table, number-1, size);
			if (result >= 0)
				textBox3.Text = Convert.ToString(result);
			else
				textBox3.Text = "No element with that key";
		}

		private void Set_element(object sender, EventArgs e)
		{
			int number;
			try
			{
				number = Convert.ToInt32(textBox2.Text);
			}
			catch
			{
				number = 1;
			}

			int value;
			try
			{
				value = Convert.ToInt32(textBox4.Text);
			}
			catch
			{
				value = 1;
			}

			int result = UnorderedTable.SetElement(table, number-1, size, value);
			if (result >= 0) 
				textBox3.Text = "Value had changed";
			else
				textBox3.Text = "No element with that key";

			Display_table(sender, e);
		}

		private void Input_in_table(object sender, EventArgs e)
		{
			size += 1;
			int number;
			try
			{
				number = Convert.ToInt32(textBox6.Text);
			}
			catch
			{
				number = -1;
			}

			int value;
			try
			{
				value = Convert.ToInt32(textBox5.Text);
			}
			catch
			{
				value = 0;
			}

			if (number >= 0 && number <= size)
			{
				arrOfSize.Add(size);
				table = UnorderedTable.Add_For_Index(value, number, table, size);
				textBox7.Text = "Element had been inputed ";
			}
			else
				textBox7.Text = "Cant find your element ";
			Display_table(sender, e);
		}

		private void Delete_el(object sender, EventArgs e)
		{
			size -= 1;

			int number;
			try
			{
				number = Convert.ToInt32(textBox9.Text);
			}
			catch
			{
				number = -1;
			}
			if (number >= 0 && number <= size)
			{
				table = UnorderedTable.Delete_element(number, table, size);
				arrOfSize = UnorderedTable.Delete_element(number, arrOfSize, size);
				textBox10.Text = "Element had been deleted ";
			}
			else
				textBox10.Text = "Cant find your element ";
			
			Display_table(sender, e);
		}

		private void Combine(object sender, EventArgs e)
		{
			size = 2 * size;
			for (int i = size/2; i < size; i++)
			{
				arrOfSize.Add(i+1);
			}
			table = UnorderedTable.Join(table, tableCpy, size);
			tableCpy.Clear();
			Display_table(sender, e);
		}

		private void Copy_table(object sender, EventArgs e)
		{
			tableCpy = table.Clone();
		}

		private void Get_size(object sender, EventArgs e)
		{
			textBox8.Text = Convert.ToString(size);
		}

		private void Separate_table(object sender, EventArgs e)
		{
			temp = size;
			int halfsize = 0;
			if (size % 2 == 0)
				halfsize = size / 2;
			else
				halfsize = (size - 1) / 2;

			Copy_table(sender, e);

			table = UnorderedTable.CutTable1(table, size, halfsize);
			HalfTable = UnorderedTable.CutTable2(tableCpy, size, halfsize);

			if (size % 2 == 0)
				size = size / 2;
			else
				size = (size - 1) / 2;

			Display_table(sender, e);
			Display_tables1_2(sender, e);
		}

		private void Display_tables1_2(object sender, EventArgs e)
		{
			string strValue = "";

			for (int i = 0; i < size; i++)
			{
				strValue += Convert.ToString(table[i]) + "\n";
			}

			richTextBox3.Text = strValue;

			string strKey = "";

			for (int i = 0; i < size; i++)
			{
				strKey += arrOfSize[i] + "." + "\n";
			}


			if (temp % 2 == 0)
				temp = temp / 2;
			else
				temp = ((temp - 1) / 2) + 1;
			richTextBox4.Text = strKey;

			string strValue1 = "";

			for (int i = 0; i < temp; i++)
			{
				strValue1 += Convert.ToString(HalfTable[i]) + "\n";
			}

			richTextBox5.Text = strValue1;

			string strKey1 = "";

			for (int i = 0; i < temp; i++)
			{
				strKey1 += arrOfSize[i] + "." + "\n";
			}

			richTextBox6.Text = strKey1;
		}

		private void Sort_by_Value(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < size - 1; i++)
				{
					int min = i;
					for (int j = i + 1; j < size - 1; j++)
					{
						if (table[j] < table[min])
						{
							min = j;
						}
					}
					int temp = table[i];
					int temp1 = arrOfSize[i];
					arrOfSize[i] = arrOfSize[min];
					arrOfSize[min] = temp1;
					table[i] = table[min];
					table[min] = temp;
					min = i;
				}

				Display_table(sender, e);
				textBox13.Text = "Table had been sorted";

			}
			catch {
				textBox13.Text = "Cannot sort your table!";
			}
		}

		private void Find_for_Value(object sender, EventArgs e)
		{
			int result;
			int value;
			try
			{
				value = Convert.ToInt32(textBox12.Text);
			}
			catch
			{
				value = -1;
			}

			if (value > 0)
			{
				result = UnorderedTable.FindValue(table, size, value);
                if (result == -1)
                {
                    textBox14.Text = "Cannot find this element!";
                }
                else
                {
                    result = result + 1;
                    textBox14.Text = "Index = " + result;
                }
			}
			else {
				textBox14.Text = "Wrong inputed value";
			}
		}

		private void Clear_all(object sender, EventArgs e)
		{
			size = 0;
			table = UnorderedTable.ClearTable();

			richTextBox1.Clear();
			richTextBox2.Clear();
		}
	}
}
