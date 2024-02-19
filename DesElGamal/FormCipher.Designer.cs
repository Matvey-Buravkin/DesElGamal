namespace DesElGamal
{
    partial class FormCipher
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLoadMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLoadMessage = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLoadKey = new System.Windows.Forms.TextBox();
            this.buttonGenerateKey = new System.Windows.Forms.Button();
            this.buttonCipherMessage = new System.Windows.Forms.Button();
            this.buttonSaveCipherMessage = new System.Windows.Forms.Button();
            this.textBoxCipherMessage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDecryptMessage = new System.Windows.Forms.TextBox();
            this.buttonDecryptMessage = new System.Windows.Forms.Button();
            this.labelP = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelG = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.buttonEnterSms = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCipherKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Отправитель";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(506, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Получатель";
            // 
            // textBoxLoadMessage
            // 
            this.textBoxLoadMessage.Location = new System.Drawing.Point(17, 111);
            this.textBoxLoadMessage.Multiline = true;
            this.textBoxLoadMessage.Name = "textBoxLoadMessage";
            this.textBoxLoadMessage.Size = new System.Drawing.Size(325, 68);
            this.textBoxLoadMessage.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(14, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Передаваемое сообщение:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(507, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Передаваемое сообщение:";
            // 
            // buttonLoadMessage
            // 
            this.buttonLoadMessage.Location = new System.Drawing.Point(17, 82);
            this.buttonLoadMessage.Name = "buttonLoadMessage";
            this.buttonLoadMessage.Size = new System.Drawing.Size(325, 23);
            this.buttonLoadMessage.TabIndex = 5;
            this.buttonLoadMessage.Text = "Загрузить из файла";
            this.buttonLoadMessage.UseVisualStyleBackColor = true;
            this.buttonLoadMessage.Click += new System.EventHandler(this.buttonLoadMessage_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(14, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ключ 64 бит:";
            // 
            // textBoxLoadKey
            // 
            this.textBoxLoadKey.Location = new System.Drawing.Point(17, 211);
            this.textBoxLoadKey.Multiline = true;
            this.textBoxLoadKey.Name = "textBoxLoadKey";
            this.textBoxLoadKey.Size = new System.Drawing.Size(325, 43);
            this.textBoxLoadKey.TabIndex = 7;
            // 
            // buttonGenerateKey
            // 
            this.buttonGenerateKey.Location = new System.Drawing.Point(17, 269);
            this.buttonGenerateKey.Name = "buttonGenerateKey";
            this.buttonGenerateKey.Size = new System.Drawing.Size(325, 23);
            this.buttonGenerateKey.TabIndex = 8;
            this.buttonGenerateKey.Text = "Загрузить ключ из файла";
            this.buttonGenerateKey.UseVisualStyleBackColor = true;
            this.buttonGenerateKey.Click += new System.EventHandler(this.buttonGenerateKey_Click);
            // 
            // buttonCipherMessage
            // 
            this.buttonCipherMessage.Location = new System.Drawing.Point(17, 322);
            this.buttonCipherMessage.Name = "buttonCipherMessage";
            this.buttonCipherMessage.Size = new System.Drawing.Size(325, 36);
            this.buttonCipherMessage.TabIndex = 9;
            this.buttonCipherMessage.Text = "Зашифровать";
            this.buttonCipherMessage.UseVisualStyleBackColor = true;
            this.buttonCipherMessage.Click += new System.EventHandler(this.buttonCipherMessage_Click);
            // 
            // buttonSaveCipherMessage
            // 
            this.buttonSaveCipherMessage.Location = new System.Drawing.Point(510, 82);
            this.buttonSaveCipherMessage.Name = "buttonSaveCipherMessage";
            this.buttonSaveCipherMessage.Size = new System.Drawing.Size(325, 23);
            this.buttonSaveCipherMessage.TabIndex = 10;
            this.buttonSaveCipherMessage.Text = "Сохранить в файл";
            this.buttonSaveCipherMessage.UseVisualStyleBackColor = true;
            this.buttonSaveCipherMessage.Click += new System.EventHandler(this.buttonSaveCipherMessage_Click);
            // 
            // textBoxCipherMessage
            // 
            this.textBoxCipherMessage.Location = new System.Drawing.Point(510, 111);
            this.textBoxCipherMessage.Multiline = true;
            this.textBoxCipherMessage.Name = "textBoxCipherMessage";
            this.textBoxCipherMessage.Size = new System.Drawing.Size(325, 68);
            this.textBoxCipherMessage.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(507, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Дешифрованное сообщение:";
            // 
            // textBoxDecryptMessage
            // 
            this.textBoxDecryptMessage.Location = new System.Drawing.Point(509, 331);
            this.textBoxDecryptMessage.Multiline = true;
            this.textBoxDecryptMessage.Name = "textBoxDecryptMessage";
            this.textBoxDecryptMessage.Size = new System.Drawing.Size(325, 47);
            this.textBoxDecryptMessage.TabIndex = 13;
            // 
            // buttonDecryptMessage
            // 
            this.buttonDecryptMessage.Location = new System.Drawing.Point(509, 289);
            this.buttonDecryptMessage.Name = "buttonDecryptMessage";
            this.buttonDecryptMessage.Size = new System.Drawing.Size(325, 30);
            this.buttonDecryptMessage.TabIndex = 14;
            this.buttonDecryptMessage.Text = "Дешифровать";
            this.buttonDecryptMessage.UseVisualStyleBackColor = true;
            this.buttonDecryptMessage.Click += new System.EventHandler(this.buttonDecryptMessage_Click);
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Location = new System.Drawing.Point(17, 380);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(64, 13);
            this.labelP.TabIndex = 15;
            this.labelP.Text = "Значение p";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(17, 440);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(63, 13);
            this.labelY.TabIndex = 16;
            this.labelY.Text = "Значение y";
            // 
            // labelG
            // 
            this.labelG.AutoSize = true;
            this.labelG.Location = new System.Drawing.Point(17, 412);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(64, 13);
            this.labelG.TabIndex = 17;
            this.labelG.Text = "Значение g";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(17, 493);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(64, 13);
            this.labelB.TabIndex = 18;
            this.labelB.Text = "Значение b";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(17, 469);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(64, 13);
            this.labelA.TabIndex = 19;
            this.labelA.Text = "Значение a";
            // 
            // buttonEnterSms
            // 
            this.buttonEnterSms.Location = new System.Drawing.Point(145, 184);
            this.buttonEnterSms.Name = "buttonEnterSms";
            this.buttonEnterSms.Size = new System.Drawing.Size(197, 23);
            this.buttonEnterSms.TabIndex = 20;
            this.buttonEnterSms.Text = "Подтвердить ввод смс";
            this.buttonEnterSms.UseVisualStyleBackColor = true;
            this.buttonEnterSms.Click += new System.EventHandler(this.buttonEnterSms_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(507, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Зашифрованный ключ:";
            // 
            // textBoxCipherKey
            // 
            this.textBoxCipherKey.Location = new System.Drawing.Point(510, 211);
            this.textBoxCipherKey.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCipherKey.Multiline = true;
            this.textBoxCipherKey.Name = "textBoxCipherKey";
            this.textBoxCipherKey.Size = new System.Drawing.Size(327, 37);
            this.textBoxCipherKey.TabIndex = 22;
            // 
            // FormCipher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 515);
            this.Controls.Add(this.textBoxCipherKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonEnterSms);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelG);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.buttonDecryptMessage);
            this.Controls.Add(this.textBoxDecryptMessage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCipherMessage);
            this.Controls.Add(this.buttonSaveCipherMessage);
            this.Controls.Add(this.buttonCipherMessage);
            this.Controls.Add(this.buttonGenerateKey);
            this.Controls.Add(this.textBoxLoadKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonLoadMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLoadMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCipher";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLoadMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLoadMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLoadKey;
        private System.Windows.Forms.Button buttonGenerateKey;
        private System.Windows.Forms.Button buttonCipherMessage;
        private System.Windows.Forms.Button buttonSaveCipherMessage;
        private System.Windows.Forms.TextBox textBoxCipherMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDecryptMessage;
        private System.Windows.Forms.Button buttonDecryptMessage;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Button buttonEnterSms;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCipherKey;
    }
}

