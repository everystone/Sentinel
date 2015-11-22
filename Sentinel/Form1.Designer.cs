namespace Sentinel {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.gui_btn_stop = new System.Windows.Forms.Button();
            this.gui_btn_start = new System.Windows.Forms.Button();
            this.gui_ComboAdapter = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.gui_btn_stop);
            this.panel1.Controls.Add(this.gui_btn_start);
            this.panel1.Controls.Add(this.gui_ComboAdapter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 36);
            this.panel1.TabIndex = 1;
            // 
            // gui_btn_stop
            // 
            this.gui_btn_stop.Location = new System.Drawing.Point(494, 9);
            this.gui_btn_stop.Name = "gui_btn_stop";
            this.gui_btn_stop.Size = new System.Drawing.Size(53, 23);
            this.gui_btn_stop.TabIndex = 3;
            this.gui_btn_stop.Text = "Stop";
            this.gui_btn_stop.UseVisualStyleBackColor = true;
            // 
            // gui_btn_start
            // 
            this.gui_btn_start.Location = new System.Drawing.Point(432, 9);
            this.gui_btn_start.Name = "gui_btn_start";
            this.gui_btn_start.Size = new System.Drawing.Size(53, 23);
            this.gui_btn_start.TabIndex = 2;
            this.gui_btn_start.Text = "Start";
            this.gui_btn_start.UseVisualStyleBackColor = true;
            this.gui_btn_start.Click += new System.EventHandler(this.gui_btn_start_Click);
            // 
            // gui_ComboAdapter
            // 
            this.gui_ComboAdapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gui_ComboAdapter.FormattingEnabled = true;
            this.gui_ComboAdapter.Location = new System.Drawing.Point(17, 9);
            this.gui_ComboAdapter.Name = "gui_ComboAdapter";
            this.gui_ComboAdapter.Size = new System.Drawing.Size(397, 21);
            this.gui_ComboAdapter.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 384);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button gui_btn_stop;
        private System.Windows.Forms.Button gui_btn_start;
        private System.Windows.Forms.ComboBox gui_ComboAdapter;

    }
}

