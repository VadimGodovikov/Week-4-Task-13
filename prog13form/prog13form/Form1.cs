using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog13form
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		abstract class Client
		{
			static public string[] CLdate = new string[3] { "Investor", "Creditor", "Organization" };
			static public void GetAllClInfo(Client[] cl, TextBox textBox)
			{
				for (int i = 0; i < cl.Length; i++)
				{
					cl[i].PrintInfo(textBox);
				}
			}
			abstract public void PrintInfo(TextBox textBox);
			abstract public bool SearchDate(DateTime date);
		}

		class Investor : Client
		{
			string surname;
			DateTime investorDate;
			decimal investorAmount;
			decimal invesotrProc;

			public Investor(string surname, DateTime investorDate, decimal investorAmount, decimal invesotrProc)
			{
				this.surname = surname;
				this.investorDate = investorDate;
				this.investorAmount = investorAmount;
				this.invesotrProc = invesotrProc;
			}

			public override void PrintInfo(TextBox textBox)
			{
				textBox.Text += $"Фамилия: {surname}\r\nДата открытия вклада: {investorDate}\r\nРазмер вклада: {investorAmount}\r\nПроцент по вкладу: {invesotrProc}\r\n" + Environment.NewLine;
			}
			public override bool SearchDate(DateTime date)
			{
				if (investorDate == date) return true;
				return false;
			}
		}

		class Creditor : Client
		{
			string surname;
			DateTime creditorDate;
			decimal creditorAmount;
			decimal creditorProc;
			decimal creditOst;

			public Creditor(string surname, DateTime creditorDate, decimal creditorAmount, decimal creditorProc, decimal creditorOst)
			{
				this.surname = surname;
				this.creditorDate = creditorDate;
				this.creditorAmount = creditorAmount;
				this.creditorProc = creditorProc;
				this.creditOst = creditorOst;
			}

			public override void PrintInfo(TextBox textBox)
			{
				textBox.Text += $"Фамилия: {surname}\r\nДата взятия кредита: {creditorDate}\r\nРазмер кредита: {creditorAmount}\r\nПроцент по кредиту: {creditorProc}\r\nОстаток по кредиту: {creditOst}\r\n" + Environment.NewLine;
			}
			public override bool SearchDate(DateTime date)
			{
				if (creditorDate == date) return true;
				return false;
			}
		}
		class Organization : Client
		{
			string name;
			DateTime orgDate;
			int orgNum;
			decimal orgAmount;

			public Organization(string name, DateTime orgDate, int orgNum, decimal orgAmount)
			{
				this.name = name;
				this.orgDate = orgDate;
				this.orgNum = orgNum;
				this.orgAmount = orgAmount;
			}

			public override void PrintInfo(TextBox textBox)
			{
				textBox.Text += $"Фамилия: {name}\r\nДата открытия счёта: {orgDate}\r\nНомер счёта: {orgNum}\r\nСумма на счету: {orgAmount}\r\n" + Environment.NewLine;
			}
			public override bool SearchDate(DateTime date)
			{
				if (orgDate == date) return true;
				return false;
			}
		}

		static string[] ReadFile(FileStream fileStream)
		{
			byte[] buf = new byte[fileStream.Length];
			fileStream.Read(buf, 0, buf.Length);
			string textFromFile = Encoding.Default.GetString(buf);
			string[] textSplit = textFromFile.Split('\n');

			for (int i = 0; i < textSplit.Length; i++) textSplit[i] = textSplit[i].Trim();
			return textSplit;
		}

		static Client[] SetCLFromFile(TextBox fileBox)
		{
			Client[] cl = null;
			FileStream filecl;
			string filePath;
			filePath = fileBox.Text;
			filecl = new FileStream(filePath, FileMode.Open, FileAccess.Read);

			if (!filecl.CanRead)
			{
				MessageBox.Show("Введен некорректный путь.");
			}
			

			string[] textSplit = ReadFile(filecl);
			filecl.Close();

			int countcl = 0;

			for (int i = 0; i < textSplit.Length; i++)
			{
				if (textSplit[i] == Client.CLdate[0] || textSplit[i] == Client.CLdate[1] || textSplit[i] == Client.CLdate[2]) countcl++;
			}

			if (countcl == 0) throw new Exception("Ошибка. Вероятно файл заполнен неверно или файл пустой.");

			cl = new Client[countcl];
			string[] countstr = new string[5];

			int ifc = 0;
			int typeindex;

			for (int i = 0; i < cl.Length; i++)
			{
				typeindex = ifc;
				for (int j = ifc + 1; j < textSplit.Length; j++)
				{
					if (textSplit[j] == Client.CLdate[0] || textSplit[j] == Client.CLdate[1] || textSplit[j] == Client.CLdate[2])
					{
						ifc = j;
						break;
					}
					for (int l = 0; l < countstr.Length; l++)
					{
						if (l == 4 && (textSplit[ifc] == Client.CLdate[0] || textSplit[ifc] == Client.CLdate[2])) break;
						countstr[l] = textSplit[j];
						j++;
					}
					j--;
				}
				if (textSplit[typeindex] == "Investor") cl[i] = new Investor(countstr[0], Convert.ToDateTime(countstr[1]), Convert.ToDecimal(countstr[2]), Convert.ToDecimal(countstr[3]));
				else if (textSplit[typeindex] == "Creditor") cl[i] = new Creditor(countstr[0], Convert.ToDateTime(countstr[1]), Convert.ToDecimal(countstr[2]), Convert.ToDecimal(countstr[3]), Convert.ToDecimal(countstr[4]));
				else if (textSplit[typeindex] == "Organization") cl[i] = new Organization(countstr[0], Convert.ToDateTime(countstr[1]), Convert.ToInt32(countstr[2]), Convert.ToDecimal(countstr[3]));
				else MessageBox.Show("Не получилось добавить ПО по индексу.");
			}
			return cl;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				resBox.Text = "Результат программы: " + Environment.NewLine;
				Client[] client = SetCLFromFile(fileBox);

				if (client == null)
				{
					MessageBox.Show("Данные из файла не записаны");
					return;
				}
				resBox.Text += "Вывод всех клиентов" + Environment.NewLine;
				resBox.Text += "" + Environment.NewLine;
				Client.GetAllClInfo(client, resBox);

			}
			catch
			{
				MessageBox.Show("Ошибка. Вероятно, введены неверные параметры");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				Client[] client = SetCLFromFile(fileBox);
				DateTime askDate = DateTime.Parse(DataBox.Text);
				int foundClients = 0;
				resBox.Text += $"Поиск клиентов по дате: {askDate}" + Environment.NewLine;
				resBox.Text += "" + Environment.NewLine;
				foreach (Client clients in client)
				{
					if (clients.SearchDate(askDate))
					{
						clients.PrintInfo(resBox);
						foundClients++;
						resBox.Text += "" + Environment.NewLine;
					}
				}
				resBox.Text += "" + Environment.NewLine;
				if (foundClients == 0)
				{
					MessageBox.Show("Клиенты по данной дате не найдены");
				}
				resBox.Text += "" + Environment.NewLine;

			}
			catch (FormatException)
			{
				MessageBox.Show("Ошибка. Введены неверные значения");
			}
		}

	}
}

