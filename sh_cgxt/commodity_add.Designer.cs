namespace sh_cgxt
{
    partial class commodity_add
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Name_Text = new System.Windows.Forms.TextBox();
            this.Amount_Text = new System.Windows.Forms.TextBox();
            this.Price_Text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(82, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(82, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(82, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "价钱";
            // 
            // Name_Text
            // 
            this.Name_Text.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Name_Text.Location = new System.Drawing.Point(161, 43);
            this.Name_Text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name_Text.Name = "Name_Text";
            this.Name_Text.Size = new System.Drawing.Size(198, 34);
            this.Name_Text.TabIndex = 3;
            // 
            // Amount_Text
            // 
            this.Amount_Text.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Amount_Text.Location = new System.Drawing.Point(161, 141);
            this.Amount_Text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Amount_Text.Name = "Amount_Text";
            this.Amount_Text.Size = new System.Drawing.Size(198, 34);
            this.Amount_Text.TabIndex = 4;
            // 
            // Price_Text
            // 
            this.Price_Text.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Price_Text.Location = new System.Drawing.Point(161, 232);
            this.Price_Text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Price_Text.Name = "Price_Text";
            this.Price_Text.Size = new System.Drawing.Size(198, 34);
            this.Price_Text.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button1.Location = new System.Drawing.Point(87, 337);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "入库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button2.Location = new System.Drawing.Point(250, 337);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 46);
            this.button2.TabIndex = 7;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // commodity_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 516);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Price_Text);
            this.Controls.Add(this.Amount_Text);
            this.Controls.Add(this.Name_Text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "commodity_add";
            this.Text = "入库";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Name_Text;
        private System.Windows.Forms.TextBox Amount_Text;
        private System.Windows.Forms.TextBox Price_Text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}