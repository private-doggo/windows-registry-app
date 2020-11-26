
namespace WindowsRegistryApp
{
    partial class parCreationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_parCreate = new System.Windows.Forms.Button();
            this.comboBox_parData = new System.Windows.Forms.ComboBox();
            this.textBox_parName = new System.Windows.Forms.TextBox();
            this.textBox_parValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_parCreate
            // 
            this.button_parCreate.Location = new System.Drawing.Point(109, 179);
            this.button_parCreate.Name = "button_parCreate";
            this.button_parCreate.Size = new System.Drawing.Size(75, 30);
            this.button_parCreate.TabIndex = 0;
            this.button_parCreate.Text = "Create";
            this.button_parCreate.UseVisualStyleBackColor = true;
            this.button_parCreate.Click += new System.EventHandler(this.button_parCreate_Click);
            // 
            // comboBox_parData
            // 
            this.comboBox_parData.FormattingEnabled = true;
            this.comboBox_parData.Location = new System.Drawing.Point(121, 27);
            this.comboBox_parData.Name = "comboBox_parData";
            this.comboBox_parData.Size = new System.Drawing.Size(121, 24);
            this.comboBox_parData.TabIndex = 1;
            // 
            // textBox_parName
            // 
            this.textBox_parName.Location = new System.Drawing.Point(121, 73);
            this.textBox_parName.Name = "textBox_parName";
            this.textBox_parName.Size = new System.Drawing.Size(121, 22);
            this.textBox_parName.TabIndex = 2;
            // 
            // textBox_parValue
            // 
            this.textBox_parValue.Location = new System.Drawing.Point(121, 120);
            this.textBox_parValue.Name = "textBox_parValue";
            this.textBox_parValue.Size = new System.Drawing.Size(121, 22);
            this.textBox_parValue.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Value";
            // 
            // parCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 232);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_parValue);
            this.Controls.Add(this.textBox_parName);
            this.Controls.Add(this.comboBox_parData);
            this.Controls.Add(this.button_parCreate);
            this.Name = "parCreationForm";
            this.Text = "parCreationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_parCreate;
        private System.Windows.Forms.ComboBox comboBox_parData;
        private System.Windows.Forms.TextBox textBox_parName;
        private System.Windows.Forms.TextBox textBox_parValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}