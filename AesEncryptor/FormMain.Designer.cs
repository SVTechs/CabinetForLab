namespace AesEncryptor
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tbIniResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.tbPlain = new System.Windows.Forms.TextBox();
            this.tbPrivateKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPublicKey = new System.Windows.Forms.TextBox();
            this.lbPublicKey = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbIniResult
            // 
            this.tbIniResult.Location = new System.Drawing.Point(101, 146);
            this.tbIniResult.Name = "tbIniResult";
            this.tbIniResult.Size = new System.Drawing.Size(352, 21);
            this.tbIniResult.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "结果(INI)";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(260, 183);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 24);
            this.btnDecrypt.TabIndex = 16;
            this.btnDecrypt.Text = "解密";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "密码";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(102, 107);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(351, 21);
            this.tbResult.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "结果";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "内容";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(102, 65);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(351, 21);
            this.tbPassword.TabIndex = 10;
            this.tbPassword.Text = "CabinetForLab";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(162, 184);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 15;
            this.btnEncrypt.Text = "加密";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // tbPlain
            // 
            this.tbPlain.Location = new System.Drawing.Point(102, 26);
            this.tbPlain.Name = "tbPlain";
            this.tbPlain.Size = new System.Drawing.Size(351, 21);
            this.tbPlain.TabIndex = 9;
            // 
            // tbPrivateKey
            // 
            this.tbPrivateKey.Location = new System.Drawing.Point(101, 262);
            this.tbPrivateKey.Name = "tbPrivateKey";
            this.tbPrivateKey.Size = new System.Drawing.Size(352, 21);
            this.tbPrivateKey.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "PrivateKey";
            // 
            // tbPublicKey
            // 
            this.tbPublicKey.Location = new System.Drawing.Point(102, 223);
            this.tbPublicKey.Name = "tbPublicKey";
            this.tbPublicKey.Size = new System.Drawing.Size(351, 21);
            this.tbPublicKey.TabIndex = 20;
            // 
            // lbPublicKey
            // 
            this.lbPublicKey.AutoSize = true;
            this.lbPublicKey.Location = new System.Drawing.Point(27, 226);
            this.lbPublicKey.Name = "lbPublicKey";
            this.lbPublicKey.Size = new System.Drawing.Size(59, 12);
            this.lbPublicKey.TabIndex = 21;
            this.lbPublicKey.Text = "PublicKey";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(212, 298);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 24;
            this.btnGenerate.Text = "生成";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 333);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tbPrivateKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPublicKey);
            this.Controls.Add(this.lbPublicKey);
            this.Controls.Add(this.tbIniResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.tbPlain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "数据加解密";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIniResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox tbPlain;
        private System.Windows.Forms.TextBox tbPrivateKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPublicKey;
        private System.Windows.Forms.Label lbPublicKey;
        private System.Windows.Forms.Button btnGenerate;
    }
}

