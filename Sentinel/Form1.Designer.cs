namespace Sentinel {
    partial class Sentinel {
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gui_packetNumberBox = new System.Windows.Forms.TextBox();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.gui_btn_stop = new System.Windows.Forms.Button();
            this.gui_btn_start = new System.Windows.Forms.Button();
            this.gui_ComboAdapter = new System.Windows.Forms.ComboBox();
            this.hexDetails = new System.Windows.Forms.RichTextBox();
            this.asciiDetails = new System.Windows.Forms.RichTextBox();
            this.gui_label_calc = new System.Windows.Forms.Label();
            this.hexContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.decodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gui_bytes_selected = new System.Windows.Forms.Label();
            this.packetListView = new ListViewNF();
            this.noHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sourceHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.destinationheader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.protoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.payloadHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.hexContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.gui_packetNumberBox);
            this.panel1.Controls.Add(this.filterBox);
            this.panel1.Controls.Add(this.gui_btn_stop);
            this.panel1.Controls.Add(this.gui_btn_start);
            this.panel1.Controls.Add(this.gui_ComboAdapter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 36);
            this.panel1.TabIndex = 1;
            // 
            // gui_packetNumberBox
            // 
            this.gui_packetNumberBox.Location = new System.Drawing.Point(669, 11);
            this.gui_packetNumberBox.Name = "gui_packetNumberBox";
            this.gui_packetNumberBox.Size = new System.Drawing.Size(26, 20);
            this.gui_packetNumberBox.TabIndex = 5;
            this.gui_packetNumberBox.Text = "20";
            // 
            // filterBox
            // 
            this.filterBox.Location = new System.Drawing.Point(420, 10);
            this.filterBox.Multiline = true;
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(243, 20);
            this.filterBox.TabIndex = 4;
            this.filterBox.Text = "tcp && dst port 27000";
            // 
            // gui_btn_stop
            // 
            this.gui_btn_stop.Location = new System.Drawing.Point(760, 8);
            this.gui_btn_stop.Name = "gui_btn_stop";
            this.gui_btn_stop.Size = new System.Drawing.Size(53, 23);
            this.gui_btn_stop.TabIndex = 3;
            this.gui_btn_stop.Text = "Stop";
            this.gui_btn_stop.UseVisualStyleBackColor = true;
            this.gui_btn_stop.Click += new System.EventHandler(this.gui_btn_stop_Click);
            // 
            // gui_btn_start
            // 
            this.gui_btn_start.Location = new System.Drawing.Point(698, 8);
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
            // hexDetails
            // 
            this.hexDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hexDetails.ContextMenuStrip = this.hexContextStrip;
            this.hexDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexDetails.HideSelection = false;
            this.hexDetails.Location = new System.Drawing.Point(0, 341);
            this.hexDetails.Name = "hexDetails";
            this.hexDetails.ReadOnly = true;
            this.hexDetails.Size = new System.Drawing.Size(446, 159);
            this.hexDetails.TabIndex = 3;
            this.hexDetails.Text = "";
            this.hexDetails.SelectionChanged += new System.EventHandler(this.hexDetails_SelectionChanged);
            this.hexDetails.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // asciiDetails
            // 
            this.asciiDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.asciiDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asciiDetails.HideSelection = false;
            this.asciiDetails.Location = new System.Drawing.Point(446, 341);
            this.asciiDetails.Name = "asciiDetails";
            this.asciiDetails.ReadOnly = true;
            this.asciiDetails.Size = new System.Drawing.Size(439, 159);
            this.asciiDetails.TabIndex = 4;
            this.asciiDetails.Text = "";
            // 
            // gui_label_calc
            // 
            this.gui_label_calc.AutoSize = true;
            this.gui_label_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gui_label_calc.Location = new System.Drawing.Point(152, 324);
            this.gui_label_calc.Name = "gui_label_calc";
            this.gui_label_calc.Size = new System.Drawing.Size(149, 17);
            this.gui_label_calc.TabIndex = 5;
            this.gui_label_calc.Text = "Select text in hexview..";
            // 
            // hexContextStrip
            // 
            this.hexContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decodeToolStripMenuItem});
            this.hexContextStrip.Name = "hexContextStrip";
            this.hexContextStrip.Size = new System.Drawing.Size(115, 26);
            // 
            // decodeToolStripMenuItem
            // 
            this.decodeToolStripMenuItem.Name = "decodeToolStripMenuItem";
            this.decodeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.decodeToolStripMenuItem.Text = "Decode";
            this.decodeToolStripMenuItem.Click += new System.EventHandler(this.decodeToolStripMenuItem_Click);
            // 
            // gui_bytes_selected
            // 
            this.gui_bytes_selected.AutoSize = true;
            this.gui_bytes_selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gui_bytes_selected.Location = new System.Drawing.Point(12, 324);
            this.gui_bytes_selected.Name = "gui_bytes_selected";
            this.gui_bytes_selected.Size = new System.Drawing.Size(111, 17);
            this.gui_bytes_selected.TabIndex = 7;
            this.gui_bytes_selected.Text = "0 bytes selected";
            // 
            // packetListView
            // 
            this.packetListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packetListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.noHeader,
            this.dateHeader,
            this.sourceHeader,
            this.destinationheader,
            this.protoHeader,
            this.sizeHeader,
            this.payloadHeader});
            this.packetListView.FullRowSelect = true;
            this.packetListView.Location = new System.Drawing.Point(0, 36);
            this.packetListView.MultiSelect = false;
            this.packetListView.Name = "packetListView";
            this.packetListView.Size = new System.Drawing.Size(882, 287);
            this.packetListView.TabIndex = 2;
            this.packetListView.UseCompatibleStateImageBehavior = false;
            this.packetListView.View = System.Windows.Forms.View.Details;
            this.packetListView.SelectedIndexChanged += new System.EventHandler(this.packetListView_SelectedIndexChanged);
            // 
            // noHeader
            // 
            this.noHeader.Text = "No.";
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 155;
            // 
            // sourceHeader
            // 
            this.sourceHeader.Text = "Source";
            this.sourceHeader.Width = 133;
            // 
            // destinationheader
            // 
            this.destinationheader.Text = "Destination";
            this.destinationheader.Width = 143;
            // 
            // protoHeader
            // 
            this.protoHeader.Text = "Protocol";
            // 
            // sizeHeader
            // 
            this.sizeHeader.Text = "Size";
            // 
            // payloadHeader
            // 
            this.payloadHeader.Text = "Payload";
            this.payloadHeader.Width = 209;
            // 
            // Sentinel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 500);
            this.Controls.Add(this.gui_bytes_selected);
            this.Controls.Add(this.gui_label_calc);
            this.Controls.Add(this.asciiDetails);
            this.Controls.Add(this.packetListView);
            this.Controls.Add(this.hexDetails);
            this.Controls.Add(this.panel1);
            this.Name = "Sentinel";
            this.Text = "Sentinel";
            this.Load += new System.EventHandler(this.Sentinel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.hexContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button gui_btn_stop;
        private System.Windows.Forms.Button gui_btn_start;
        private System.Windows.Forms.ComboBox gui_ComboAdapter;
        private ListViewNF packetListView;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ColumnHeader sourceHeader;
        private System.Windows.Forms.ColumnHeader destinationheader;
        private System.Windows.Forms.ColumnHeader sizeHeader;
        private System.Windows.Forms.ColumnHeader payloadHeader;
        private System.Windows.Forms.ColumnHeader protoHeader;
        private System.Windows.Forms.ColumnHeader noHeader;
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.TextBox gui_packetNumberBox;
        private System.Windows.Forms.RichTextBox hexDetails;
        private System.Windows.Forms.RichTextBox asciiDetails;
        private System.Windows.Forms.Label gui_label_calc;
        private System.Windows.Forms.ContextMenuStrip hexContextStrip;
        private System.Windows.Forms.ToolStripMenuItem decodeToolStripMenuItem;
        private System.Windows.Forms.Label gui_bytes_selected;

    }
}

