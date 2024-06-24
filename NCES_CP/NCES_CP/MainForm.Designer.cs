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
            this.label_choose_type = new System.Windows.Forms.Label();
            this.radioButton_Detached = new System.Windows.Forms.RadioButton();
            this.radioButton_NotDetached = new System.Windows.Forms.RadioButton();
            this.button_sign = new System.Windows.Forms.Button();
            this.button_Check_Signature = new System.Windows.Forms.Button();
            this.button_calculate_hash = new System.Windows.Forms.Button();
            this.button_sign_attr = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
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
            // label_choose_type
            // 
            this.label_choose_type.AutoSize = true;
            this.label_choose_type.Location = new System.Drawing.Point(13, 13);
            this.label_choose_type.Name = "label_choose_type";
            this.label_choose_type.Size = new System.Drawing.Size(98, 16);
            this.label_choose_type.TabIndex = 2;
            this.label_choose_type.Text = "Выберите тип";
            // 
            // radioButton_Detached
            // 
            this.radioButton_Detached.AutoSize = true;
            this.radioButton_Detached.Checked = true;
            this.radioButton_Detached.Location = new System.Drawing.Point(16, 33);
            this.radioButton_Detached.Name = "radioButton_Detached";
            this.radioButton_Detached.Size = new System.Drawing.Size(87, 20);
            this.radioButton_Detached.TabIndex = 3;
            this.radioButton_Detached.TabStop = true;
            this.radioButton_Detached.Text = "Detached";
            this.radioButton_Detached.UseVisualStyleBackColor = true;
            this.radioButton_Detached.CheckedChanged += new System.EventHandler(this.radioButton_Detached_CheckedChanged);
            // 
            // radioButton_NotDetached
            // 
            this.radioButton_NotDetached.AutoSize = true;
            this.radioButton_NotDetached.Location = new System.Drawing.Point(16, 59);
            this.radioButton_NotDetached.Name = "radioButton_NotDetached";
            this.radioButton_NotDetached.Size = new System.Drawing.Size(109, 20);
            this.radioButton_NotDetached.TabIndex = 4;
            this.radioButton_NotDetached.Text = "Not detached";
            this.radioButton_NotDetached.UseVisualStyleBackColor = true;
            this.radioButton_NotDetached.CheckedChanged += new System.EventHandler(this.radioButton_NotDetached_CheckedChanged);
            // 
            // button_sign
            // 
            this.button_sign.Location = new System.Drawing.Point(12, 163);
            this.button_sign.Name = "button_sign";
            this.button_sign.Size = new System.Drawing.Size(164, 72);
            this.button_sign.TabIndex = 5;
            this.button_sign.Text = "Подписать файл";
            this.button_sign.UseVisualStyleBackColor = true;
            this.button_sign.Click += new System.EventHandler(this.button_sign_Click);
            // 
            // button_Check_Signature
            // 
            this.button_Check_Signature.Location = new System.Drawing.Point(355, 163);
            this.button_Check_Signature.Name = "button_Check_Signature";
            this.button_Check_Signature.Size = new System.Drawing.Size(164, 72);
            this.button_Check_Signature.TabIndex = 6;
            this.button_Check_Signature.Text = "Проверить подпись";
            this.button_Check_Signature.UseVisualStyleBackColor = true;
            this.button_Check_Signature.Click += new System.EventHandler(this.button_Check_Signature_Click);
            // 
            // button_calculate_hash
            // 
            this.button_calculate_hash.Location = new System.Drawing.Point(525, 163);
            this.button_calculate_hash.Name = "button_calculate_hash";
            this.button_calculate_hash.Size = new System.Drawing.Size(164, 72);
            this.button_calculate_hash.TabIndex = 8;
            this.button_calculate_hash.Text = "Посчитать хеш";
            this.button_calculate_hash.UseVisualStyleBackColor = true;
            this.button_calculate_hash.Click += new System.EventHandler(this.button_calculate_hash_Click);
            // 
            // button_sign_attr
            // 
            this.button_sign_attr.Location = new System.Drawing.Point(185, 163);
            this.button_sign_attr.Name = "button_sign_attr";
            this.button_sign_attr.Size = new System.Drawing.Size(164, 72);
            this.button_sign_attr.TabIndex = 10;
            this.button_sign_attr.Text = "Подписать файл атрибутным сертификатом";
            this.button_sign_attr.UseVisualStyleBackColor = true;
            this.button_sign_attr.Click += new System.EventHandler(this.button_sign_attr_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(12, 241);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_result.Size = new System.Drawing.Size(677, 358);
            this.textBox_result.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 603);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.button_sign_attr);
            this.Controls.Add(this.button_calculate_hash);
            this.Controls.Add(this.button_Check_Signature);
            this.Controls.Add(this.button_sign);
            this.Controls.Add(this.radioButton_NotDetached);
            this.Controls.Add(this.radioButton_Detached);
            this.Controls.Add(this.label_choose_type);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.ChooseFileButton);
            this.MaximumSize = new System.Drawing.Size(720, 650);
            this.MinimumSize = new System.Drawing.Size(720, 650);
            this.Name = "MainForm";
            this.Text = "NCES_CP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button ChooseFileButton;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.Label label_choose_type;
        private System.Windows.Forms.RadioButton radioButton_Detached;
        private System.Windows.Forms.RadioButton radioButton_NotDetached;
        private System.Windows.Forms.Button button_sign;
        private System.Windows.Forms.Button button_Check_Signature;
        private System.Windows.Forms.Button button_calculate_hash;
        private System.Windows.Forms.Button button_sign_attr;
        private System.Windows.Forms.TextBox textBox_result;
    }
}

