namespace moudle1
{
    partial class lab1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(955, 128);
            button1.Name = "button1";
            button1.Size = new Size(129, 50);
            button1.TabIndex = 0;
            button1.Text = "старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // button2
            // 
            button2.Location = new Point(955, 12);
            button2.Name = "button2";
            button2.Size = new Size(129, 55);
            button2.TabIndex = 1;
            button2.Text = "create figure";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(955, 73);
            button3.Name = "button3";
            button3.Size = new Size(129, 49);
            button3.TabIndex = 2;
            button3.Text = "create route";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 4);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 4;
            label1.Text = "скорость вращения фигуры";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(235, 20);
            label2.TabIndex = 7;
            label2.Text = "скорость передвижения фигуры";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 27);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 8;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(12, 85);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 27);
            numericUpDown2.TabIndex = 9;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // button4
            // 
            button4.Location = new Point(955, 184);
            button4.Name = "button4";
            button4.Size = new Size(129, 53);
            button4.TabIndex = 10;
            button4.Text = "стоп";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // lab1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(40, 40);
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1096, 559);
            Controls.Add(button4);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Cursor = Cursors.Arrow;
            ImeMode = ImeMode.Off;
            Name = "lab1";
            Text = "Form1";
            AutoSizeChanged += Form1_Load;
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            MouseMove += DrawPoligon_MouseMove;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private System.Windows.Forms.Timer timer1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Button button4;
    }
}