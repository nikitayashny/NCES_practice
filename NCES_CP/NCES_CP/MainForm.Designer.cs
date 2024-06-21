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
            this.radioButton_idCard = new System.Windows.Forms.RadioButton();
            this.radioButton_flash = new System.Windows.Forms.RadioButton();
            this.button_sign = new System.Windows.Forms.Button();
            this.button_Check_Signature = new System.Windows.Forms.Button();
            this.label_result = new System.Windows.Forms.Label();
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
            this.ChooseFileButton.Size = new System.Drawing.Size(164, 39);
            this.ChooseFileButton.TabIndex = 0;
            this.ChooseFileButton.Text = "Выбрать файл";
            this.ChooseFileButton.UseVisualStyleBackColor = true;
            this.ChooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(182, 96);
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
            // radioButton_idCard
            // 
            this.radioButton_idCard.AutoSize = true;
            this.radioButton_idCard.Location = new System.Drawing.Point(16, 33);
            this.radioButton_idCard.Name = "radioButton_idCard";
            this.radioButton_idCard.Size = new System.Drawing.Size(68, 20);
            this.radioButton_idCard.TabIndex = 3;
            this.radioButton_idCard.TabStop = true;
            this.radioButton_idCard.Text = "IdCard";
            this.radioButton_idCard.UseVisualStyleBackColor = true;
            this.radioButton_idCard.CheckedChanged += new System.EventHandler(this.radioButton_idCard_CheckedChanged);
            // 
            // radioButton_flash
            // 
            this.radioButton_flash.AutoSize = true;
            this.radioButton_flash.Location = new System.Drawing.Point(16, 59);
            this.radioButton_flash.Name = "radioButton_flash";
            this.radioButton_flash.Size = new System.Drawing.Size(61, 20);
            this.radioButton_flash.TabIndex = 4;
            this.radioButton_flash.TabStop = true;
            this.radioButton_flash.Text = "Flash";
            this.radioButton_flash.UseVisualStyleBackColor = true;
            this.radioButton_flash.CheckedChanged += new System.EventHandler(this.radioButton_flesh_CheckedChanged);
            // 
            // button_sign
            // 
            this.button_sign.Location = new System.Drawing.Point(12, 130);
            this.button_sign.Name = "button_sign";
            this.button_sign.Size = new System.Drawing.Size(164, 39);
            this.button_sign.TabIndex = 5;
            this.button_sign.Text = "Подписать файл";
            this.button_sign.UseVisualStyleBackColor = true;
            this.button_sign.Click += new System.EventHandler(this.button_sign_Click);
            // 
            // button_Check_Signature
            // 
            this.button_Check_Signature.Location = new System.Drawing.Point(12, 175);
            this.button_Check_Signature.Name = "button_Check_Signature";
            this.button_Check_Signature.Size = new System.Drawing.Size(164, 39);
            this.button_Check_Signature.TabIndex = 6;
            this.button_Check_Signature.Text = "Проверить подпись";
            this.button_Check_Signature.UseVisualStyleBackColor = true;
            this.button_Check_Signature.Click += new System.EventHandler(this.button_Check_Signature_Click);
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Location = new System.Drawing.Point(13, 217);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(39, 16);
            this.label_result.TabIndex = 7;
            this.label_result.Text = "result";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 611);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.button_Check_Signature);
            this.Controls.Add(this.button_sign);
            this.Controls.Add(this.radioButton_flash);
            this.Controls.Add(this.radioButton_idCard);
            this.Controls.Add(this.label_choose_type);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.ChooseFileButton);
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
        private System.Windows.Forms.RadioButton radioButton_idCard;
        private System.Windows.Forms.RadioButton radioButton_flash;
        private System.Windows.Forms.Button button_sign;
        private System.Windows.Forms.Button button_Check_Signature;
        private System.Windows.Forms.Label label_result;
    }
}

