namespace WordFind
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            txtSelectedFile = new TextBox();
            txtSearchBar = new TextBox();
            cmbFileType = new ComboBox();
            BtnFindAll = new Button();
            gridResult = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            pbStatus = new ProgressBar();
            TopBar = new DataGridView();
            label3 = new Label();
            searchIcon = new PictureBox();
            label4 = new Label();
            BtnDownload = new Button();
            saveFile = new SaveFileDialog();
            BrowseButton = new Button();
            ((System.ComponentModel.ISupportInitialize)gridResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TopBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchIcon).BeginInit();
            SuspendLayout();
            // 
            // txtSelectedFile
            // 
            txtSelectedFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSelectedFile.Location = new Point(35, 171);
            txtSelectedFile.Name = "txtSelectedFile";
            txtSelectedFile.Size = new Size(1355, 31);
            txtSelectedFile.TabIndex = 0;
            // 
            // txtSearchBar
            // 
            txtSearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchBar.Location = new Point(35, 317);
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.Size = new Size(1355, 31);
            txtSearchBar.TabIndex = 3;
            // 
            // cmbFileType
            // 
            cmbFileType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFileType.FormattingEnabled = true;
            cmbFileType.Location = new Point(1465, 315);
            cmbFileType.Name = "cmbFileType";
            cmbFileType.Size = new Size(138, 33);
            cmbFileType.TabIndex = 4;
            // 
            // BtnFindAll
            // 
            BtnFindAll.Anchor = AnchorStyles.Top;
            BtnFindAll.BackColor = SystemColors.ActiveCaption;
            BtnFindAll.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnFindAll.Location = new Point(732, 393);
            BtnFindAll.Name = "BtnFindAll";
            BtnFindAll.Size = new Size(221, 56);
            BtnFindAll.TabIndex = 5;
            BtnFindAll.Text = "Find All";
            BtnFindAll.UseVisualStyleBackColor = false;
            // 
            // gridResult
            // 
            gridResult.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridResult.Location = new Point(0, 633);
            gridResult.Name = "gridResult";
            gridResult.RowHeadersWidth = 62;
            gridResult.Size = new Size(1711, 469);
            gridResult.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 121);
            label1.Name = "label1";
            label1.Size = new Size(166, 29);
            label1.TabIndex = 7;
            label1.Text = "Enter Path";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 267);
            label2.Name = "label2";
            label2.Size = new Size(265, 29);
            label2.TabIndex = 8;
            label2.Text = "Enter Search Item";
            // 
            // pbStatus
            // 
            pbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbStatus.Location = new Point(239, 479);
            pbStatus.Name = "pbStatus";
            pbStatus.Size = new Size(1180, 37);
            pbStatus.TabIndex = 10;
            // 
            // TopBar
            // 
            TopBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TopBar.BackgroundColor = Color.Gold;
            TopBar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TopBar.GridColor = SystemColors.WindowText;
            TopBar.Location = new Point(-5, -2);
            TopBar.Name = "TopBar";
            TopBar.RowHeadersWidth = 62;
            TopBar.Size = new Size(1721, 86);
            TopBar.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Snap ITC", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 14);
            label3.Name = "label3";
            label3.Size = new Size(338, 57);
            label3.TabIndex = 12;
            label3.Text = "WORD FIND";
            // 
            // searchIcon
            // 
            searchIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchIcon.BackgroundImage = (Image)resources.GetObject("searchIcon.BackgroundImage");
            searchIcon.BackgroundImageLayout = ImageLayout.Zoom;
            searchIcon.ErrorImage = null;
            searchIcon.Image = (Image)resources.GetObject("searchIcon.Image");
            searchIcon.InitialImage = null;
            searchIcon.Location = new Point(1602, 14);
            searchIcon.Name = "searchIcon";
            searchIcon.Size = new Size(122, 62);
            searchIcon.TabIndex = 13;
            searchIcon.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoEllipsis = true;
            label4.AutoSize = true;
            label4.Font = new Font("Stencil", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(1471, 274);
            label4.Name = "label4";
            label4.Size = new Size(126, 26);
            label4.TabIndex = 14;
            label4.Text = "File Type";
            // 
            // BtnDownload
            // 
            BtnDownload.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnDownload.BackColor = Color.Lime;
            BtnDownload.Location = new Point(780, 534);
            BtnDownload.Name = "BtnDownload";
            BtnDownload.Size = new Size(112, 34);
            BtnDownload.TabIndex = 15;
            BtnDownload.Text = "Download";
            BtnDownload.UseVisualStyleBackColor = false;
            // 
            // BrowseButton
            // 
            BrowseButton.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BrowseButton.Location = new Point(1471, 168);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(132, 34);
            BrowseButton.TabIndex = 16;
            BrowseButton.Text = "BROWSE";
            BrowseButton.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 210, 62);
            ClientSize = new Size(1707, 1100);
            Controls.Add(BrowseButton);
            Controls.Add(BtnDownload);
            Controls.Add(label4);
            Controls.Add(searchIcon);
            Controls.Add(label3);
            Controls.Add(TopBar);
            Controls.Add(pbStatus);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gridResult);
            Controls.Add(BtnFindAll);
            Controls.Add(cmbFileType);
            Controls.Add(txtSearchBar);
            Controls.Add(txtSelectedFile);
            Name = "Main";
            Text = "Word Find";
            TopMost = true;
            TransparencyKey = Color.Navy;
            ((System.ComponentModel.ISupportInitialize)gridResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)TopBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSelectedFile;
        private TextBox txtSearchBar;
        private ComboBox cmbFileType;
        private Button BtnFindAll;
        private DataGridView gridResult;
        private Label label1;
        private Label label2;
        private ProgressBar pbStatus;
        private DataGridView TopBar;
        private Label label3;
        private PictureBox searchIcon;
        private Label label4;
        private Button BtnDownload;
        private SaveFileDialog saveFile;
        private Button BrowseButton;
    }
}
