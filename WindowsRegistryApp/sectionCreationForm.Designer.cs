
namespace WindowsRegistryApp
{
    partial class sectionCreationForm
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
            this.textBox_sectionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_createSection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_sectionName
            // 
            this.textBox_sectionName.Location = new System.Drawing.Point(191, 36);
            this.textBox_sectionName.Name = "textBox_sectionName";
            this.textBox_sectionName.Size = new System.Drawing.Size(100, 22);
            this.textBox_sectionName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Section name";
            // 
            // button_createSection
            // 
            this.button_createSection.Location = new System.Drawing.Point(154, 86);
            this.button_createSection.Name = "button_createSection";
            this.button_createSection.Size = new System.Drawing.Size(75, 30);
            this.button_createSection.TabIndex = 2;
            this.button_createSection.Text = "Create";
            this.button_createSection.UseVisualStyleBackColor = true;
            this.button_createSection.Click += new System.EventHandler(this.button_createSection_Click);
            // 
            // sectionCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 153);
            this.Controls.Add(this.button_createSection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_sectionName);
            this.Name = "sectionCreationForm";
            this.Text = "sectionCreationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_sectionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_createSection;
    }
}