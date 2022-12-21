namespace prog13form
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.DataBox = new System.Windows.Forms.TextBox();
			this.resBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.fileBox = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(258, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Введите дату по которой будете искать клиентов";
			// 
			// DataBox
			// 
			this.DataBox.Location = new System.Drawing.Point(278, 49);
			this.DataBox.Name = "DataBox";
			this.DataBox.Size = new System.Drawing.Size(510, 20);
			this.DataBox.TabIndex = 1;
			// 
			// resBox
			// 
			this.resBox.Location = new System.Drawing.Point(16, 133);
			this.resBox.Multiline = true;
			this.resBox.Name = "resBox";
			this.resBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.resBox.Size = new System.Drawing.Size(772, 397);
			this.resBox.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(183, 537);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(445, 55);
			this.button1.TabIndex = 3;
			this.button1.Text = "Пуск";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(147, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Введите путь к файлу (C:\\..)";
			// 
			// fileBox
			// 
			this.fileBox.Location = new System.Drawing.Point(170, 13);
			this.fileBox.Name = "fileBox";
			this.fileBox.Size = new System.Drawing.Size(618, 20);
			this.fileBox.TabIndex = 5;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(19, 76);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(225, 51);
			this.button2.TabIndex = 6;
			this.button2.Text = "Поиск";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 604);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.fileBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.resBox);
			this.Controls.Add(this.DataBox);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox DataBox;
		private System.Windows.Forms.TextBox resBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox fileBox;
		private System.Windows.Forms.Button button2;
	}
}

