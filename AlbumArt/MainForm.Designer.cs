namespace AlbumArt
{
    partial class MainForm
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
            System.Windows.Forms.TableLayoutPanel gridBaseLayout;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TableLayoutPanel verticalHeatMapLayout;
            System.Windows.Forms.TableLayoutPanel horizontalHeatMapButtonsLayout;
            System.Windows.Forms.TableLayoutPanel verticalLeftLayout;
            System.Windows.Forms.FlowLayoutPanel verticalButtonsFlowLayout;
            this.readoutLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.heatMapDisplay = new System.Windows.Forms.PictureBox();
            this.previousYearButton = new System.Windows.Forms.Button();
            this.nextYearButton = new System.Windows.Forms.Button();
            this.currentYearLabel = new System.Windows.Forms.Label();
            this.spotifyConnectButton = new System.Windows.Forms.Button();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            gridBaseLayout = new System.Windows.Forms.TableLayoutPanel();
            verticalHeatMapLayout = new System.Windows.Forms.TableLayoutPanel();
            horizontalHeatMapButtonsLayout = new System.Windows.Forms.TableLayoutPanel();
            verticalLeftLayout = new System.Windows.Forms.TableLayoutPanel();
            verticalButtonsFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            gridBaseLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            verticalHeatMapLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heatMapDisplay)).BeginInit();
            horizontalHeatMapButtonsLayout.SuspendLayout();
            verticalLeftLayout.SuspendLayout();
            verticalButtonsFlowLayout.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBaseLayout
            // 
            gridBaseLayout.AutoScroll = true;
            gridBaseLayout.AutoSize = true;
            gridBaseLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            gridBaseLayout.BackColor = System.Drawing.Color.Green;
            gridBaseLayout.ColumnCount = 1;
            gridBaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            gridBaseLayout.Controls.Add(this.readoutLabel, 0, 1);
            gridBaseLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            gridBaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            gridBaseLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            gridBaseLayout.Location = new System.Drawing.Point(0, 24);
            gridBaseLayout.Margin = new System.Windows.Forms.Padding(5);
            gridBaseLayout.Name = "gridBaseLayout";
            gridBaseLayout.RowCount = 2;
            gridBaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            gridBaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            gridBaseLayout.Size = new System.Drawing.Size(970, 643);
            gridBaseLayout.TabIndex = 0;
            // 
            // readoutLabel
            // 
            this.readoutLabel.AutoSize = true;
            this.readoutLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.readoutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readoutLabel.Location = new System.Drawing.Point(5, 533);
            this.readoutLabel.Margin = new System.Windows.Forms.Padding(5);
            this.readoutLabel.MaximumSize = new System.Drawing.Size(0, 200);
            this.readoutLabel.MinimumSize = new System.Drawing.Size(1, 1);
            this.readoutLabel.Name = "readoutLabel";
            this.readoutLabel.Size = new System.Drawing.Size(3487, 105);
            this.readoutLabel.TabIndex = 4;
            this.readoutLabel.Text = resources.GetString("readoutLabel.Text");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(verticalHeatMapLayout, 1, 0);
            this.tableLayoutPanel1.Controls.Add(verticalLeftLayout, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(3491, 522);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // verticalHeatMapLayout
            // 
            verticalHeatMapLayout.AutoSize = true;
            verticalHeatMapLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            verticalHeatMapLayout.ColumnCount = 1;
            verticalHeatMapLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            verticalHeatMapLayout.Controls.Add(this.heatMapDisplay, 0, 0);
            verticalHeatMapLayout.Controls.Add(horizontalHeatMapButtonsLayout, 0, 1);
            verticalHeatMapLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            verticalHeatMapLayout.Location = new System.Drawing.Point(198, 3);
            verticalHeatMapLayout.Name = "verticalHeatMapLayout";
            verticalHeatMapLayout.RowCount = 2;
            verticalHeatMapLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            verticalHeatMapLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            verticalHeatMapLayout.Size = new System.Drawing.Size(3290, 516);
            verticalHeatMapLayout.TabIndex = 3;
            // 
            // heatMapDisplay
            // 
            this.heatMapDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.heatMapDisplay.Enabled = false;
            this.heatMapDisplay.Location = new System.Drawing.Point(5, 5);
            this.heatMapDisplay.Margin = new System.Windows.Forms.Padding(5);
            this.heatMapDisplay.Name = "heatMapDisplay";
            this.heatMapDisplay.Size = new System.Drawing.Size(500, 462);
            this.heatMapDisplay.TabIndex = 2;
            this.heatMapDisplay.TabStop = false;
            // 
            // horizontalHeatMapButtonsLayout
            // 
            horizontalHeatMapButtonsLayout.AutoSize = true;
            horizontalHeatMapButtonsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            horizontalHeatMapButtonsLayout.ColumnCount = 3;
            horizontalHeatMapButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            horizontalHeatMapButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            horizontalHeatMapButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            horizontalHeatMapButtonsLayout.Controls.Add(this.previousYearButton, 0, 0);
            horizontalHeatMapButtonsLayout.Controls.Add(this.nextYearButton, 2, 0);
            horizontalHeatMapButtonsLayout.Controls.Add(this.currentYearLabel, 1, 0);
            horizontalHeatMapButtonsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            horizontalHeatMapButtonsLayout.Location = new System.Drawing.Point(3, 475);
            horizontalHeatMapButtonsLayout.Name = "horizontalHeatMapButtonsLayout";
            horizontalHeatMapButtonsLayout.RowCount = 1;
            horizontalHeatMapButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            horizontalHeatMapButtonsLayout.Size = new System.Drawing.Size(3284, 38);
            horizontalHeatMapButtonsLayout.TabIndex = 3;
            // 
            // previousYearButton
            // 
            this.previousYearButton.AutoSize = true;
            this.previousYearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.previousYearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.previousYearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previousYearButton.Location = new System.Drawing.Point(3, 3);
            this.previousYearButton.Name = "previousYearButton";
            this.previousYearButton.Size = new System.Drawing.Size(1603, 32);
            this.previousYearButton.TabIndex = 0;
            this.previousYearButton.Text = "Previous Year";
            this.previousYearButton.UseVisualStyleBackColor = true;
            this.previousYearButton.Click += new System.EventHandler(this.previousYearButton_Click);
            // 
            // nextYearButton
            // 
            this.nextYearButton.AutoSize = true;
            this.nextYearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextYearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextYearButton.Location = new System.Drawing.Point(1678, 3);
            this.nextYearButton.Name = "nextYearButton";
            this.nextYearButton.Size = new System.Drawing.Size(1603, 32);
            this.nextYearButton.TabIndex = 1;
            this.nextYearButton.Text = "Next Year";
            this.nextYearButton.UseVisualStyleBackColor = true;
            // 
            // currentYearLabel
            // 
            this.currentYearLabel.AutoSize = true;
            this.currentYearLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.currentYearLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentYearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentYearLabel.Location = new System.Drawing.Point(1612, 0);
            this.currentYearLabel.Name = "currentYearLabel";
            this.currentYearLabel.Size = new System.Drawing.Size(60, 38);
            this.currentYearLabel.TabIndex = 2;
            this.currentYearLabel.Text = "1999";
            this.currentYearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // verticalLeftLayout
            // 
            verticalLeftLayout.AutoSize = true;
            verticalLeftLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            verticalLeftLayout.ColumnCount = 1;
            verticalLeftLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            verticalLeftLayout.Controls.Add(verticalButtonsFlowLayout, 0, 0);
            verticalLeftLayout.Controls.Add(this.startButton, 0, 1);
            verticalLeftLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            verticalLeftLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            verticalLeftLayout.Location = new System.Drawing.Point(3, 3);
            verticalLeftLayout.MinimumSize = new System.Drawing.Size(0, 500);
            verticalLeftLayout.Name = "verticalLeftLayout";
            verticalLeftLayout.RowCount = 2;
            verticalLeftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.19048F));
            verticalLeftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            verticalLeftLayout.Size = new System.Drawing.Size(189, 516);
            verticalLeftLayout.TabIndex = 5;
            // 
            // verticalButtonsFlowLayout
            // 
            verticalButtonsFlowLayout.AutoSize = true;
            verticalButtonsFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            verticalButtonsFlowLayout.BackColor = System.Drawing.Color.Purple;
            verticalButtonsFlowLayout.Controls.Add(this.spotifyConnectButton);
            verticalButtonsFlowLayout.Controls.Add(this.folderSelectButton);
            verticalButtonsFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            verticalButtonsFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            verticalButtonsFlowLayout.Location = new System.Drawing.Point(3, 3);
            verticalButtonsFlowLayout.Name = "verticalButtonsFlowLayout";
            verticalButtonsFlowLayout.Size = new System.Drawing.Size(183, 387);
            verticalButtonsFlowLayout.TabIndex = 0;
            // 
            // spotifyConnectButton
            // 
            this.spotifyConnectButton.AutoSize = true;
            this.spotifyConnectButton.Location = new System.Drawing.Point(5, 5);
            this.spotifyConnectButton.Margin = new System.Windows.Forms.Padding(5);
            this.spotifyConnectButton.Name = "spotifyConnectButton";
            this.spotifyConnectButton.Size = new System.Drawing.Size(173, 35);
            this.spotifyConnectButton.TabIndex = 1;
            this.spotifyConnectButton.Text = "Connect to Spotify";
            this.spotifyConnectButton.UseVisualStyleBackColor = true;
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.AutoSize = true;
            this.folderSelectButton.Location = new System.Drawing.Point(5, 50);
            this.folderSelectButton.Margin = new System.Windows.Forms.Padding(5);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(132, 35);
            this.folderSelectButton.TabIndex = 0;
            this.folderSelectButton.Text = "Select Folder";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.AutoSize = true;
            this.startButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startButton.Location = new System.Drawing.Point(3, 396);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(183, 117);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start Process";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(970, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Tag = "";
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFolderToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadFolderToolStripMenuItem
            // 
            this.loadFolderToolStripMenuItem.Name = "loadFolderToolStripMenuItem";
            this.loadFolderToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadFolderToolStripMenuItem.Text = "Load Folder";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(970, 667);
            this.Controls.Add(gridBaseLayout);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Album Art";
            this.Load += new System.EventHandler(this.mainFormLoad);
            gridBaseLayout.ResumeLayout(false);
            gridBaseLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            verticalHeatMapLayout.ResumeLayout(false);
            verticalHeatMapLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heatMapDisplay)).EndInit();
            horizontalHeatMapButtonsLayout.ResumeLayout(false);
            horizontalHeatMapButtonsLayout.PerformLayout();
            verticalLeftLayout.ResumeLayout(false);
            verticalLeftLayout.PerformLayout();
            verticalButtonsFlowLayout.ResumeLayout(false);
            verticalButtonsFlowLayout.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox heatMapDisplay;
        private System.Windows.Forms.Label readoutLabel;
        private System.Windows.Forms.Button previousYearButton;
        private System.Windows.Forms.Button nextYearButton;
        private System.Windows.Forms.Label currentYearLabel;
        private System.Windows.Forms.Button spotifyConnectButton;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

