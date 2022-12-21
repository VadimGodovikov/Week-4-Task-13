using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Variant9
{
	abstract class Client
	{
		static public string[] CLdate = new string[3] { "Investor", "Creditor", "Organization" };
		static public void GetAllClInfo(Client[] cl)
		{
			for (int i = 0; i < cl.Length; i++)
			{
				cl[i].PrintInfo();
			}
		}
		abstract public void PrintInfo();
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

		public override void PrintInfo()
		{
			Console.WriteLine($"Фамилия: {surname}\nДата открытия вклада: {investorDate}\nРазмер вклада: {investorAmount}\nПроцент по вкладу: {invesotrProc}\n");
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

		public override void PrintInfo()
		{
			Console.WriteLine($"Фамилия: {surname}\nДата взятия кредита: {creditorDate}\nРазмер кредита: {creditorAmount}\nПроцент по кредиту: {creditorProc}\nОстаток по кредиту: {creditOst}\n");
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

		public override void PrintInfo()
		{
			Console.WriteLine($"Фамилия: {name}\nДата открытия счёта: {orgDate}\nНомер счёта: {orgNum}\nСумма на счету: {orgAmount}\n");
		}
		public override bool SearchDate(DateTime date)
		{
			if (orgDate == date) return true;
			return false;
		}
	}
	class Program
	{
		static string[] ReadFile(FileStream fileStream)
		{
			byte[] buf = new byte[fileStream.Length];
			fileStream.Read(buf, 0, buf.Length);
			string textFromFile = Encoding.Default.GetString(buf);
			string[] textSplit = textFromFile.Split('\n');

			for (int i = 0; i < textSplit.Length; i++) textSplit[i] = textSplit[i].Trim();
			return textSplit;
		}

		static Client[] SetCLFromFile()
		{
			Client[] cl = null;
			FileStream filecl;
			string filePath;
			Console.WriteLine("Введите путь к файлу через \"C:\\...\"");
			while (true)
			{
				filePath = Console.ReadLine();
				filecl = new FileStream(filePath, FileMode.Open, FileAccess.Read);

				if (filecl.CanRead) break;
				Console.WriteLine("Введен некорректный путь.");
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
				else Console.WriteLine("Не получилось добавить ПО по индексу.");
			}
			Console.WriteLine("Данные о клиентах записаны");
			return cl;
		}

		static void Main()
		{
			try
			{
				Client[] client = SetCLFromFile();
				
				if (client == null)
				{
					Console.WriteLine("Данные из файла не записаны");
					return;
				}
				Console.WriteLine("Вывод всех клиентов");
				Console.WriteLine();
				Client.GetAllClInfo(client);

				Console.WriteLine("Введите дату начала сотрудничества: ");
				DateTime askDate = DateTime.Parse(Console.ReadLine());
				int foundClients = 0;
				foreach(Client clients in client)
				{
					if (clients.SearchDate(askDate))
					{
						clients.PrintInfo();
						foundClients++;
						Console.WriteLine();
					}
				}
				Console.WriteLine();
				if(foundClients == 0)
				{
					Console.WriteLine("Клиенты по данной дате не найдены");
				}
				Console.WriteLine();
				
			}
			catch (FormatException)
			{
				Console.WriteLine("Ошибка. Введены неверные значения");
			}
			catch
			{
				Console.WriteLine("Ошибка. Вероятно, введены неверные параметры");
			}
		}
	}
}