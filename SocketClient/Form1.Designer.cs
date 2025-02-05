namespace SocketClient
{
    partial class Form1
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
            this.Txt_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Port = new System.Windows.Forms.TextBox();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_Send = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Txt_IP
            // 
            this.Txt_IP.Location = new System.Drawing.Point(27, 37);
            this.Txt_IP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_IP.Name = "Txt_IP";
            this.Txt_IP.Size = new System.Drawing.Size(199, 22);
            this.Txt_IP.TabIndex = 0;
            this.Txt_IP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // Txt_Port
            // 
            this.Txt_Port.Location = new System.Drawing.Point(261, 37);
            this.Txt_Port.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Port.Name = "Txt_Port";
            this.Txt_Port.Size = new System.Drawing.Size(199, 22);
            this.Txt_Port.TabIndex = 2;
            this.Txt_Port.Text = "23";
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Connect.ForeColor = System.Drawing.Color.Black;
            this.Btn_Connect.Location = new System.Drawing.Point(545, 18);
            this.Btn_Connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(173, 43);
            this.Btn_Connect.TabIndex = 4;
            this.Btn_Connect.Text = "Connect";
            this.Btn_Connect.UseVisualStyleBackColor = true;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Send.ForeColor = System.Drawing.Color.Black;
            this.btn_Send.Location = new System.Drawing.Point(545, 106);
            this.btn_Send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(173, 43);
            this.btn_Send.TabIndex = 6;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txt_Send
            // 
            this.txt_Send.Location = new System.Drawing.Point(31, 118);
            this.txt_Send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Send.Name = "txt_Send";
            this.txt_Send.Size = new System.Drawing.Size(429, 22);
            this.txt_Send.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 182);
            this.Controls.Add(this.txt_Send);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_IP);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Port;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_Send;
    }
}

