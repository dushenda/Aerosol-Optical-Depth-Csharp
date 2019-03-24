namespace ObjectDemo
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNum = new System.Windows.Forms.Button();
            this.lblNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNum
            // 
            this.btnNum.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNum.Location = new System.Drawing.Point(224, 86);
            this.btnNum.Name = "btnNum";
            this.btnNum.Size = new System.Drawing.Size(133, 60);
            this.btnNum.TabIndex = 0;
            this.btnNum.Text = "Click";
            this.btnNum.UseVisualStyleBackColor = true;
            this.btnNum.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNum.Location = new System.Drawing.Point(222, 210);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(181, 21);
            this.lblNum.TabIndex = 1;
            this.lblNum.Text = "你已经点击了0次按钮";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.btnNum);
            this.Name = "Form1";
            this.Text = "一对一对象组合";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNum;
        private System.Windows.Forms.Label lblNum;
    }
}

