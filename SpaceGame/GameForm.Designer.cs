namespace SpaceGame
{
    partial class GameForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.moveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fuelLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.engine3FuelLabel = new System.Windows.Forms.Label();
            this.engine3Label = new System.Windows.Forms.Label();
            this.engine2FuelLabel = new System.Windows.Forms.Label();
            this.engine2Label = new System.Windows.Forms.Label();
            this.engine1FuelLabel = new System.Windows.Forms.Label();
            this.engine1Label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 300);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // moveButton
            // 
            this.moveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveButton.AutoSize = true;
            this.moveButton.Location = new System.Drawing.Point(513, 269);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(95, 36);
            this.moveButton.TabIndex = 1;
            this.moveButton.Text = "Сделать ход";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кол-во топлива в хранилище:";
            // 
            // fuelLabel
            // 
            this.fuelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fuelLabel.AutoSize = true;
            this.fuelLabel.Location = new System.Drawing.Point(573, 12);
            this.fuelLabel.Name = "fuelLabel";
            this.fuelLabel.Size = new System.Drawing.Size(31, 13);
            this.fuelLabel.TabIndex = 3;
            this.fuelLabel.Text = "1000";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.engine3FuelLabel);
            this.groupBox1.Controls.Add(this.engine3Label);
            this.groupBox1.Controls.Add(this.engine2FuelLabel);
            this.groupBox1.Controls.Add(this.engine2Label);
            this.groupBox1.Controls.Add(this.engine1FuelLabel);
            this.groupBox1.Controls.Add(this.engine1Label);
            this.groupBox1.Location = new System.Drawing.Point(414, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Двигатели";
            // 
            // engine3FuelLabel
            // 
            this.engine3FuelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engine3FuelLabel.AutoSize = true;
            this.engine3FuelLabel.Location = new System.Drawing.Point(73, 63);
            this.engine3FuelLabel.Name = "engine3FuelLabel";
            this.engine3FuelLabel.Size = new System.Drawing.Size(31, 13);
            this.engine3FuelLabel.TabIndex = 8;
            this.engine3FuelLabel.Text = "1000";
            this.engine3FuelLabel.Visible = false;
            // 
            // engine3Label
            // 
            this.engine3Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engine3Label.AutoSize = true;
            this.engine3Label.Location = new System.Drawing.Point(6, 63);
            this.engine3Label.Name = "engine3Label";
            this.engine3Label.Size = new System.Drawing.Size(43, 13);
            this.engine3Label.TabIndex = 9;
            this.engine3Label.Text = "Третий";
            this.engine3Label.Visible = false;
            // 
            // engine2FuelLabel
            // 
            this.engine2FuelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engine2FuelLabel.AutoSize = true;
            this.engine2FuelLabel.Location = new System.Drawing.Point(73, 39);
            this.engine2FuelLabel.Name = "engine2FuelLabel";
            this.engine2FuelLabel.Size = new System.Drawing.Size(31, 13);
            this.engine2FuelLabel.TabIndex = 6;
            this.engine2FuelLabel.Text = "1000";
            this.engine2FuelLabel.Visible = false;
            // 
            // engine2Label
            // 
            this.engine2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engine2Label.AutoSize = true;
            this.engine2Label.Location = new System.Drawing.Point(6, 39);
            this.engine2Label.Name = "engine2Label";
            this.engine2Label.Size = new System.Drawing.Size(43, 13);
            this.engine2Label.TabIndex = 7;
            this.engine2Label.Text = "Второй";
            this.engine2Label.Visible = false;
            // 
            // engine1FuelLabel
            // 
            this.engine1FuelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engine1FuelLabel.AutoSize = true;
            this.engine1FuelLabel.Location = new System.Drawing.Point(73, 16);
            this.engine1FuelLabel.Name = "engine1FuelLabel";
            this.engine1FuelLabel.Size = new System.Drawing.Size(31, 13);
            this.engine1FuelLabel.TabIndex = 5;
            this.engine1FuelLabel.Text = "1000";
            // 
            // engine1Label
            // 
            this.engine1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engine1Label.AutoSize = true;
            this.engine1Label.Location = new System.Drawing.Point(6, 16);
            this.engine1Label.Name = "engine1Label";
            this.engine1Label.Size = new System.Drawing.Size(47, 13);
            this.engine1Label.TabIndex = 5;
            this.engine1Label.Text = "Первый";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(620, 317);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fuelLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fuelLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label engine1FuelLabel;
        private System.Windows.Forms.Label engine1Label;
        private System.Windows.Forms.Label engine2FuelLabel;
        private System.Windows.Forms.Label engine2Label;
        private System.Windows.Forms.Label engine3FuelLabel;
        private System.Windows.Forms.Label engine3Label;
    }
}