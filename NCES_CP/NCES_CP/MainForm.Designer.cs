namespace NCES_CP
{
    partial class MainForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ChooseFileButton = new System.Windows.Forms.Button();
            this.label_file = new System.Windows.Forms.Label();
            this.radioButton_Detached = new System.Windows.Forms.RadioButton();
            this.radioButton_NotDetached = new System.Windows.Forms.RadioButton();
            this.button_Check_Signature = new System.Windows.Forms.Button();
            this.button_calculate_hash = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.button_fullinfo = new System.Windows.Forms.Button();
            this.groupBox_signType = new System.Windows.Forms.GroupBox();
            this.groupBox_signMethod = new System.Windows.Forms.GroupBox();
            this.radioButton_idCard = new System.Windows.Forms.RadioButton();
            this.radioButton_AvPass = new System.Windows.Forms.RadioButton();
            this.groupBox_AtrrCert = new System.Windows.Forms.GroupBox();
            this.radioButton_yes = new System.Windows.Forms.RadioButton();
            this.radioButton_no = new System.Windows.Forms.RadioButton();
            this.button_SignFile = new System.Windows.Forms.Button();
            this.groupBox_signType.SuspendLayout();
            this.groupBox_signMethod.SuspendLayout();
            this.groupBox_AtrrCert.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // ChooseFileButton
            // 
            this.ChooseFileButton.Location = new System.Drawing.Point(12, 85);
            this.ChooseFileButton.Name = "ChooseFileButton";
            this.ChooseFileButton.Size = new System.Drawing.Size(164, 72);
            this.ChooseFileButton.TabIndex = 0;
            this.ChooseFileButton.Text = "Выбрать файл";
            this.ChooseFileButton.UseVisualStyleBackColor = true;
            this.ChooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(182, 113);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(0, 16);
            this.label_file.TabIndex = 1;
            // 
            // radioButton_Detached
            // 
            this.radioButton_Detached.AutoSize = true;
            this.radioButton_Detached.Checked = true;
            this.radioButton_Detached.Location = new System.Drawing.Point(6, 21);
            this.radioButton_Detached.Name = "radioButton_Detached";
            this.radioButton_Detached.Size = new System.Drawing.Size(123, 20);
            this.radioButton_Detached.TabIndex = 3;
            this.radioButton_Detached.TabStop = true;
            this.radioButton_Detached.Text = "Откреплённая";
            this.radioButton_Detached.UseVisualStyleBackColor = true;
            this.radioButton_Detached.CheckedChanged += new System.EventHandler(this.radioButton_Detached_CheckedChanged);
            // 
            // radioButton_NotDetached
            // 
            this.radioButton_NotDetached.AutoSize = true;
            this.radioButton_NotDetached.Location = new System.Drawing.Point(6, 46);
            this.radioButton_NotDetached.Name = "radioButton_NotDetached";
            this.radioButton_NotDetached.Size = new System.Drawing.Size(132, 20);
            this.radioButton_NotDetached.TabIndex = 4;
            this.radioButton_NotDetached.Text = "Прикреплённая";
            this.radioButton_NotDetached.UseVisualStyleBackColor = true;
            this.radioButton_NotDetached.CheckedChanged += new System.EventHandler(this.radioButton_NotDetached_CheckedChanged);
            // 
            // button_Check_Signature
            // 
            this.button_Check_Signature.Location = new System.Drawing.Point(182, 163);
            this.button_Check_Signature.Name = "button_Check_Signature";
            this.button_Check_Signature.Size = new System.Drawing.Size(164, 72);
            this.button_Check_Signature.TabIndex = 6;
            this.button_Check_Signature.Text = "Проверить подпись";
            this.button_Check_Signature.UseVisualStyleBackColor = true;
            this.button_Check_Signature.Click += new System.EventHandler(this.button_Check_Signature_Click);
            // 
            // button_calculate_hash
            // 
            this.button_calculate_hash.Location = new System.Drawing.Point(352, 163);
            this.button_calculate_hash.Name = "button_calculate_hash";
            this.button_calculate_hash.Size = new System.Drawing.Size(164, 72);
            this.button_calculate_hash.TabIndex = 8;
            this.button_calculate_hash.Text = "Посчитать хеш";
            this.button_calculate_hash.UseVisualStyleBackColor = true;
            this.button_calculate_hash.Click += new System.EventHandler(this.button_calculate_hash_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(12, 241);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_result.Size = new System.Drawing.Size(677, 284);
            this.textBox_result.TabIndex = 11;
            this.textBox_result.TextChanged += new System.EventHandler(this.textBox_result_TextChanged);
            // 
            // button_fullinfo
            // 
            this.button_fullinfo.Location = new System.Drawing.Point(12, 531);
            this.button_fullinfo.Name = "button_fullinfo";
            this.button_fullinfo.Size = new System.Drawing.Size(209, 23);
            this.button_fullinfo.TabIndex = 12;
            this.button_fullinfo.Text = "Подробная информация";
            this.button_fullinfo.UseVisualStyleBackColor = true;
            this.button_fullinfo.Visible = false;
            this.button_fullinfo.Click += new System.EventHandler(this.button_fullinfo_Click);
            // 
            // groupBox_signType
            // 
            this.groupBox_signType.Controls.Add(this.radioButton_Detached);
            this.groupBox_signType.Controls.Add(this.radioButton_NotDetached);
            this.groupBox_signType.Location = new System.Drawing.Point(12, 12);
            this.groupBox_signType.Name = "groupBox_signType";
            this.groupBox_signType.Size = new System.Drawing.Size(175, 66);
            this.groupBox_signType.TabIndex = 14;
            this.groupBox_signType.TabStop = false;
            this.groupBox_signType.Text = "Тип подписи";
            // 
            // groupBox_signMethod
            // 
            this.groupBox_signMethod.Controls.Add(this.radioButton_idCard);
            this.groupBox_signMethod.Controls.Add(this.radioButton_AvPass);
            this.groupBox_signMethod.Location = new System.Drawing.Point(193, 12);
            this.groupBox_signMethod.Name = "groupBox_signMethod";
            this.groupBox_signMethod.Size = new System.Drawing.Size(198, 66);
            this.groupBox_signMethod.TabIndex = 15;
            this.groupBox_signMethod.TabStop = false;
            this.groupBox_signMethod.Text = "Способ подписи";
            // 
            // radioButton_idCard
            // 
            this.radioButton_idCard.AutoSize = true;
            this.radioButton_idCard.Location = new System.Drawing.Point(6, 21);
            this.radioButton_idCard.Name = "radioButton_idCard";
            this.radioButton_idCard.Size = new System.Drawing.Size(80, 20);
            this.radioButton_idCard.TabIndex = 3;
            this.radioButton_idCard.Text = "id карта";
            this.radioButton_idCard.UseVisualStyleBackColor = true;
            this.radioButton_idCard.CheckedChanged += new System.EventHandler(this.radioButton_idCard_CheckedChanged);
            // 
            // radioButton_AvPass
            // 
            this.radioButton_AvPass.AutoSize = true;
            this.radioButton_AvPass.Checked = true;
            this.radioButton_AvPass.Location = new System.Drawing.Point(6, 46);
            this.radioButton_AvPass.Name = "radioButton_AvPass";
            this.radioButton_AvPass.Size = new System.Drawing.Size(75, 20);
            this.radioButton_AvPass.TabIndex = 4;
            this.radioButton_AvPass.TabStop = true;
            this.radioButton_AvPass.Text = "AvPass";
            this.radioButton_AvPass.UseVisualStyleBackColor = true;
            this.radioButton_AvPass.CheckedChanged += new System.EventHandler(this.radioButton_AvPass_CheckedChanged);
            // 
            // groupBox_AtrrCert
            // 
            this.groupBox_AtrrCert.Controls.Add(this.radioButton_yes);
            this.groupBox_AtrrCert.Controls.Add(this.radioButton_no);
            this.groupBox_AtrrCert.Location = new System.Drawing.Point(397, 12);
            this.groupBox_AtrrCert.Name = "groupBox_AtrrCert";
            this.groupBox_AtrrCert.Size = new System.Drawing.Size(198, 66);
            this.groupBox_AtrrCert.TabIndex = 16;
            this.groupBox_AtrrCert.TabStop = false;
            this.groupBox_AtrrCert.Text = "Атрибутный сертификат";
            // 
            // radioButton_yes
            // 
            this.radioButton_yes.AutoSize = true;
            this.radioButton_yes.Location = new System.Drawing.Point(6, 21);
            this.radioButton_yes.Name = "radioButton_yes";
            this.radioButton_yes.Size = new System.Drawing.Size(45, 20);
            this.radioButton_yes.TabIndex = 3;
            this.radioButton_yes.Text = "Да";
            this.radioButton_yes.UseVisualStyleBackColor = true;
            this.radioButton_yes.CheckedChanged += new System.EventHandler(this.radioButton_yes_CheckedChanged);
            // 
            // radioButton_no
            // 
            this.radioButton_no.AutoSize = true;
            this.radioButton_no.Checked = true;
            this.radioButton_no.Location = new System.Drawing.Point(6, 46);
            this.radioButton_no.Name = "radioButton_no";
            this.radioButton_no.Size = new System.Drawing.Size(53, 20);
            this.radioButton_no.TabIndex = 4;
            this.radioButton_no.TabStop = true;
            this.radioButton_no.Text = "Нет";
            this.radioButton_no.UseVisualStyleBackColor = true;
            this.radioButton_no.CheckedChanged += new System.EventHandler(this.radioButton_no_CheckedChanged);
            // 
            // button_SignFile
            // 
            this.button_SignFile.Location = new System.Drawing.Point(12, 163);
            this.button_SignFile.Name = "button_SignFile";
            this.button_SignFile.Size = new System.Drawing.Size(164, 72);
            this.button_SignFile.TabIndex = 17;
            this.button_SignFile.Text = "Подписать файл";
            this.button_SignFile.UseVisualStyleBackColor = true;
            this.button_SignFile.Click += new System.EventHandler(this.button_SignFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 603);
            this.Controls.Add(this.button_SignFile);
            this.Controls.Add(this.groupBox_AtrrCert);
            this.Controls.Add(this.groupBox_signMethod);
            this.Controls.Add(this.groupBox_signType);
            this.Controls.Add(this.button_fullinfo);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.button_calculate_hash);
            this.Controls.Add(this.button_Check_Signature);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.ChooseFileButton);
            this.MaximumSize = new System.Drawing.Size(720, 650);
            this.MinimumSize = new System.Drawing.Size(720, 650);
            this.Name = "MainForm";
            this.Text = "NCES_CP";
            this.groupBox_signType.ResumeLayout(false);
            this.groupBox_signType.PerformLayout();
            this.groupBox_signMethod.ResumeLayout(false);
            this.groupBox_signMethod.PerformLayout();
            this.groupBox_AtrrCert.ResumeLayout(false);
            this.groupBox_AtrrCert.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button ChooseFileButton;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.RadioButton radioButton_Detached;
        private System.Windows.Forms.RadioButton radioButton_NotDetached;
        private System.Windows.Forms.Button button_Check_Signature;
        private System.Windows.Forms.Button button_calculate_hash;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Button button_fullinfo;
        private System.Windows.Forms.GroupBox groupBox_signType;
        private System.Windows.Forms.GroupBox groupBox_signMethod;
        private System.Windows.Forms.RadioButton radioButton_idCard;
        private System.Windows.Forms.RadioButton radioButton_AvPass;
        private System.Windows.Forms.GroupBox groupBox_AtrrCert;
        private System.Windows.Forms.RadioButton radioButton_yes;
        private System.Windows.Forms.RadioButton radioButton_no;
        private System.Windows.Forms.Button button_SignFile;
    }
}

