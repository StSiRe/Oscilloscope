namespace Hooli.Graph
{
    partial class Form1
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
            this.BoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonRefreshPorts = new System.Windows.Forms.Button();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.BoxPortSpeed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonDisconnect = new System.Windows.Forms.Button();
            this.PicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BoxSerialPorts
            // 
            this.BoxSerialPorts.FormattingEnabled = true;
            this.BoxSerialPorts.Location = new System.Drawing.Point(103, 19);
            this.BoxSerialPorts.Name = "BoxSerialPorts";
            this.BoxSerialPorts.Size = new System.Drawing.Size(86, 21);
            this.BoxSerialPorts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial port: ";
            // 
            // ButtonRefreshPorts
            // 
            this.ButtonRefreshPorts.Location = new System.Drawing.Point(195, 19);
            this.ButtonRefreshPorts.Name = "ButtonRefreshPorts";
            this.ButtonRefreshPorts.Size = new System.Drawing.Size(75, 21);
            this.ButtonRefreshPorts.TabIndex = 2;
            this.ButtonRefreshPorts.Text = "Refresh";
            this.ButtonRefreshPorts.UseVisualStyleBackColor = true;
            this.ButtonRefreshPorts.Click += new System.EventHandler(this.ButtonRefreshPorts_Click);
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(551, 9);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(118, 39);
            this.ButtonConnect.TabIndex = 3;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // BoxPortSpeed
            // 
            this.BoxPortSpeed.Location = new System.Drawing.Point(371, 19);
            this.BoxPortSpeed.Name = "BoxPortSpeed";
            this.BoxPortSpeed.Size = new System.Drawing.Size(133, 20);
            this.BoxPortSpeed.TabIndex = 4;
            this.BoxPortSpeed.Text = "\r\n115200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(307, 18);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Speed: ";
            // 
            // ButtonDisconnect
            // 
            this.ButtonDisconnect.Location = new System.Drawing.Point(675, 9);
            this.ButtonDisconnect.Name = "ButtonDisconnect";
            this.ButtonDisconnect.Size = new System.Drawing.Size(111, 38);
            this.ButtonDisconnect.TabIndex = 6;
            this.ButtonDisconnect.Text = "Disconnect";
            this.ButtonDisconnect.UseVisualStyleBackColor = true;
            this.ButtonDisconnect.Click += new System.EventHandler(this.ButtonDisconnect_Click);
            // 
            // PicBox
            // 
            this.PicBox.Location = new System.Drawing.Point(13, 62);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(773, 382);
            this.PicBox.TabIndex = 7;
            this.PicBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.PicBox);
            this.Controls.Add(this.ButtonDisconnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BoxPortSpeed);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.ButtonRefreshPorts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoxSerialPorts);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BoxSerialPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonRefreshPorts;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.TextBox BoxPortSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonDisconnect;
        private System.Windows.Forms.PictureBox PicBox;
    }
}

