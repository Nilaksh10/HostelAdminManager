namespace AdminHostelManager
{
    partial class RoomAllocationList
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
            this.button1 = new System.Windows.Forms.Button();
            this.RoomAlloDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.RoomAlloDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "ROOM ALLOCATION LIST";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(674, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back to Dashboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RoomAlloDataGrid
            // 
            this.RoomAlloDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomAlloDataGrid.Location = new System.Drawing.Point(31, 93);
            this.RoomAlloDataGrid.Margin = new System.Windows.Forms.Padding(6);
            this.RoomAlloDataGrid.Name = "RoomAlloDataGrid";
            this.RoomAlloDataGrid.RowHeadersWidth = 62;
            this.RoomAlloDataGrid.RowTemplate.Height = 28;
            this.RoomAlloDataGrid.Size = new System.Drawing.Size(880, 404);
            this.RoomAlloDataGrid.TabIndex = 4;
            this.RoomAlloDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomAlloDataGrid_CellContentClick);
            // 
            // RoomAllocationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 573);
            this.Controls.Add(this.RoomAlloDataGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "RoomAllocationList";
            this.Text = "RoomAllocationList";
            ((System.ComponentModel.ISupportInitialize)(this.RoomAlloDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView RoomAlloDataGrid;
    }
}