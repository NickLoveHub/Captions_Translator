namespace Captions_Hide
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.colorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SearchBar
            // 
            this.SearchBar.BackColor = System.Drawing.SystemColors.Window;
            this.SearchBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchBar.CausesValidation = false;
            this.SearchBar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.SearchBar.Location = new System.Drawing.Point(117, 12);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(117, 26);
            this.SearchBar.TabIndex = 0;
            this.SearchBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchbar_KeyPrress);
            // 
            // colorButton
            // 
            this.colorButton.FlatAppearance.BorderSize = 0;
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.Location = new System.Drawing.Point(34, 12);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(62, 26);
            this.colorButton.TabIndex = 1;
            this.colorButton.Text = "color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 201);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.SearchBar);
            this.Name = "Form1";
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Button colorButton;
    }
}

