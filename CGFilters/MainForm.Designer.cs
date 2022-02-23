namespace CGFilters
{
    partial class MainForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.embossingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.perfectReflectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expansionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 42);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(851, 662);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(875, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.открытьToolStripMenuItem.Text = "Open...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inversionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.embossingToolStripMenuItem,
            this.motionBlurToolStripMenuItem,
            this.grayWorldToolStripMenuItem,
            this.toolStripMenuItem6,
            this.perfectReflectionToolStripMenuItem,
            this.expansionToolStripMenuItem,
            this.toolStripMenuItem7,
            this.medianToolStripMenuItem,
            this.sobelFilterToolStripMenuItem,
            this.toolStripMenuItem8});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // inversionToolStripMenuItem
            // 
            this.inversionToolStripMenuItem.Name = "inversionToolStripMenuItem";
            this.inversionToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.inversionToolStripMenuItem.Text = "1 - Inversion";
            this.inversionToolStripMenuItem.Click += new System.EventHandler(this.inversionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem2.Text = "2 - Shades of gray";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.grayShadesStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem3.Text = "3 - Sepia";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.sepiatoolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem4.Text = "5 - Increase bringhtness";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.increaseBrightnesstoolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem5.Text = "6 - Shift";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.shiftToolStripMenuItem_Click);
            // 
            // embossingToolStripMenuItem
            // 
            this.embossingToolStripMenuItem.Name = "embossingToolStripMenuItem";
            this.embossingToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.embossingToolStripMenuItem.Text = "7 - Embossing";
            // 
            // motionBlurToolStripMenuItem
            // 
            this.motionBlurToolStripMenuItem.Name = "motionBlurToolStripMenuItem";
            this.motionBlurToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.motionBlurToolStripMenuItem.Text = "8 - Motion blur";
            // 
            // grayWorldToolStripMenuItem
            // 
            this.grayWorldToolStripMenuItem.Name = "grayWorldToolStripMenuItem";
            this.grayWorldToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.grayWorldToolStripMenuItem.Text = "9 - Gray world";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem6.Text = "10 - Autolevels";
            // 
            // perfectReflectionToolStripMenuItem
            // 
            this.perfectReflectionToolStripMenuItem.Name = "perfectReflectionToolStripMenuItem";
            this.perfectReflectionToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.perfectReflectionToolStripMenuItem.Text = "11 - Perfect reflection";
            // 
            // expansionToolStripMenuItem
            // 
            this.expansionToolStripMenuItem.Name = "expansionToolStripMenuItem";
            this.expansionToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.expansionToolStripMenuItem.Text = "12 - Expansion";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem7.Text = "13 - Narrow filter";
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.medianToolStripMenuItem.Text = "14 - Median";
            // 
            // sobelFilterToolStripMenuItem
            // 
            this.sobelFilterToolStripMenuItem.Name = "sobelFilterToolStripMenuItem";
            this.sobelFilterToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.sobelFilterToolStripMenuItem.Text = "15 - Sobel filter";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem8.Text = "16 - Scharr filter";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 724);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filters";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inversionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem embossingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motionBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem perfectReflectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expansionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
    }
}

