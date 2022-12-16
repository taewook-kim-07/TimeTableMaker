namespace TimeTableMaker
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.convertIMG = new System.Windows.Forms.Button();
            this.ListLabel = new System.Windows.Forms.Label();
            this.TimeTableView = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListText = new System.Windows.Forms.TextBox();
            this.RightBtn = new System.Windows.Forms.Button();
            this.LeftBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.PWTextBox = new System.Windows.Forms.TextBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.EmptyClassDayList = new System.Windows.Forms.CheckedListBox();
            this.saveOptionBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxRelayTime = new System.Windows.Forms.ComboBox();
            this.minRelayTime = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.시간표생성ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dB업데이트ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearbox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeTableView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 26);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 363);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "FRE161\r\nDEE205\r\nDEE300";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1011, 795);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.yearbox);
            this.tabPage1.Controls.Add(this.convertIMG);
            this.tabPage1.Controls.Add(this.ListLabel);
            this.tabPage1.Controls.Add(this.TimeTableView);
            this.tabPage1.Controls.Add(this.ListText);
            this.tabPage1.Controls.Add(this.RightBtn);
            this.tabPage1.Controls.Add(this.LeftBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1003, 769);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "시간표 뷰";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // convertIMG
            // 
            this.convertIMG.Location = new System.Drawing.Point(864, 7);
            this.convertIMG.Name = "convertIMG";
            this.convertIMG.Size = new System.Drawing.Size(131, 33);
            this.convertIMG.TabIndex = 10;
            this.convertIMG.Text = "이미지 저장";
            this.convertIMG.UseVisualStyleBackColor = true;
            this.convertIMG.Click += new System.EventHandler(this.convertIMG_Click);
            // 
            // ListLabel
            // 
            this.ListLabel.AutoSize = true;
            this.ListLabel.Location = new System.Drawing.Point(159, 6);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(41, 12);
            this.ListLabel.TabIndex = 9;
            this.ListLabel.Text = "대기중";
            // 
            // TimeTableView
            // 
            this.TimeTableView.AllowUserToAddRows = false;
            this.TimeTableView.AllowUserToDeleteRows = false;
            this.TimeTableView.AllowUserToResizeColumns = false;
            this.TimeTableView.AllowUserToResizeRows = false;
            this.TimeTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeTableView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TimeTableView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.TimeTableView.ColumnHeadersHeight = 20;
            this.TimeTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TimeTableView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TimeTableView.DefaultCellStyle = dataGridViewCellStyle5;
            this.TimeTableView.Location = new System.Drawing.Point(3, 46);
            this.TimeTableView.Name = "TimeTableView";
            this.TimeTableView.ReadOnly = true;
            this.TimeTableView.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TimeTableView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.TimeTableView.RowTemplate.Height = 23;
            this.TimeTableView.Size = new System.Drawing.Size(997, 720);
            this.TimeTableView.TabIndex = 8;
            this.TimeTableView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TimeTableView_CellContentDoubleClick);
            // 
            // Column6
            // 
            this.Column6.Frozen = true;
            this.Column6.HeaderText = "시간";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "월";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 175;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "화";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 175;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "수";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 175;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "목";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 175;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "금";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 175;
            // 
            // ListText
            // 
            this.ListText.Location = new System.Drawing.Point(159, 19);
            this.ListText.Name = "ListText";
            this.ListText.Size = new System.Drawing.Size(117, 21);
            this.ListText.TabIndex = 7;
            this.ListText.Text = "1";
            this.ListText.TextChanged += new System.EventHandler(this.ListText_TextChanged);
            // 
            // RightBtn
            // 
            this.RightBtn.Location = new System.Drawing.Point(282, 6);
            this.RightBtn.Name = "RightBtn";
            this.RightBtn.Size = new System.Drawing.Size(145, 34);
            this.RightBtn.TabIndex = 6;
            this.RightBtn.Text = "다음";
            this.RightBtn.UseVisualStyleBackColor = true;
            this.RightBtn.Click += new System.EventHandler(this.RightBtn_Click);
            // 
            // LeftBtn
            // 
            this.LeftBtn.Location = new System.Drawing.Point(8, 6);
            this.LeftBtn.Name = "LeftBtn";
            this.LeftBtn.Size = new System.Drawing.Size(145, 34);
            this.LeftBtn.TabIndex = 5;
            this.LeftBtn.Text = "이전";
            this.LeftBtn.UseVisualStyleBackColor = true;
            this.LeftBtn.Click += new System.EventHandler(this.LeftBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Controls.Add(this.PWTextBox);
            this.tabPage2.Controls.Add(this.IDTextBox);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.EmptyClassDayList);
            this.tabPage2.Controls.Add(this.saveOptionBtn);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.maxRelayTime);
            this.tabPage2.Controls.Add(this.minRelayTime);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1003, 769);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "설정";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(908, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(87, 44);
            this.webBrowser1.TabIndex = 15;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // PWTextBox
            // 
            this.PWTextBox.Location = new System.Drawing.Point(712, 74);
            this.PWTextBox.Name = "PWTextBox";
            this.PWTextBox.PasswordChar = '*';
            this.PWTextBox.Size = new System.Drawing.Size(156, 21);
            this.PWTextBox.TabIndex = 14;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(712, 29);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(156, 21);
            this.IDTextBox.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(391, 26);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(313, 289);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "과목코드-분반\r\n* 분반 입력을 할 시 해당되는 시간을 찾습니다.\r\n* 분반 입력 시 중복되지 않는 시간으로만 작성해주세요.\r\n\r\n[!]예시\r\nD" +
    "EE302-01\r\nDEE300-02\r\nDEE205\r\nFRE161";
            // 
            // EmptyClassDayList
            // 
            this.EmptyClassDayList.CheckOnClick = true;
            this.EmptyClassDayList.FormattingEnabled = true;
            this.EmptyClassDayList.Items.AddRange(new object[] {
            "월 공강",
            "화 공강",
            "수 공강",
            "목 공강",
            "금 공강"});
            this.EmptyClassDayList.Location = new System.Drawing.Point(24, 138);
            this.EmptyClassDayList.Name = "EmptyClassDayList";
            this.EmptyClassDayList.Size = new System.Drawing.Size(122, 84);
            this.EmptyClassDayList.TabIndex = 12;
            // 
            // saveOptionBtn
            // 
            this.saveOptionBtn.Location = new System.Drawing.Point(24, 228);
            this.saveOptionBtn.Name = "saveOptionBtn";
            this.saveOptionBtn.Size = new System.Drawing.Size(121, 35);
            this.saveOptionBtn.TabIndex = 10;
            this.saveOptionBtn.Text = "조건 저장";
            this.saveOptionBtn.UseVisualStyleBackColor = true;
            this.saveOptionBtn.Click += new System.EventHandler(this.saveOptionBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "최대 연강 교시";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(710, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "비밀번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(710, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "학번";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "최소 연강 교시";
            // 
            // maxRelayTime
            // 
            this.maxRelayTime.Font = new System.Drawing.Font("돋움", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.maxRelayTime.FormattingEnabled = true;
            this.maxRelayTime.Items.AddRange(new object[] {
            "0분",
            "30분",
            "1시",
            "1시 30분",
            "2시",
            "2시 30분",
            "3시",
            "3시 30분",
            "4시",
            "4시 30분",
            "5시",
            "5시 30분",
            "6시",
            "6시 30분",
            "7시",
            "7시 30분",
            "8시",
            "8시 30분"});
            this.maxRelayTime.Location = new System.Drawing.Point(24, 98);
            this.maxRelayTime.Name = "maxRelayTime";
            this.maxRelayTime.Size = new System.Drawing.Size(121, 23);
            this.maxRelayTime.TabIndex = 9;
            this.maxRelayTime.Text = "1시";
            // 
            // minRelayTime
            // 
            this.minRelayTime.Font = new System.Drawing.Font("돋움", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.minRelayTime.FormattingEnabled = true;
            this.minRelayTime.Items.AddRange(new object[] {
            "0분",
            "30분",
            "1시",
            "1시 30분",
            "2시",
            "2시 30분",
            "3시",
            "3시 30분",
            "4시",
            "4시 30분",
            "5시",
            "5시 30분",
            "6시",
            "6시 30분",
            "7시",
            "7시 30분",
            "8시",
            "8시 30분"});
            this.minRelayTime.Location = new System.Drawing.Point(24, 47);
            this.minRelayTime.Name = "minRelayTime";
            this.minRelayTime.Size = new System.Drawing.Size(121, 23);
            this.minRelayTime.TabIndex = 6;
            this.minRelayTime.Text = "0분";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.시간표생성ToolStripMenuItem,
            this.dB업데이트ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1011, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 시간표생성ToolStripMenuItem
            // 
            this.시간표생성ToolStripMenuItem.Name = "시간표생성ToolStripMenuItem";
            this.시간표생성ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.시간표생성ToolStripMenuItem.Text = "시간표 생성";
            this.시간표생성ToolStripMenuItem.Click += new System.EventHandler(this.시간표생성ToolStripMenuItem_Click);
            // 
            // dB업데이트ToolStripMenuItem
            // 
            this.dB업데이트ToolStripMenuItem.Name = "dB업데이트ToolStripMenuItem";
            this.dB업데이트ToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.dB업데이트ToolStripMenuItem.Text = "DB 업데이트";
            this.dB업데이트ToolStripMenuItem.Click += new System.EventHandler(this.dB업데이트ToolStripMenuItem_Click);
            // 
            // yearbox
            // 
            this.yearbox.Location = new System.Drawing.Point(453, 14);
            this.yearbox.Name = "yearbox";
            this.yearbox.Size = new System.Drawing.Size(100, 21);
            this.yearbox.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1학기",
            "2학기"});
            this.comboBox1.Location = new System.Drawing.Point(569, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "1학기";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 819);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 시간표 생성기";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeTableView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 시간표생성ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dB업데이트ToolStripMenuItem;
        private System.Windows.Forms.TextBox ListText;
        private System.Windows.Forms.Button RightBtn;
        private System.Windows.Forms.Button LeftBtn;
        private System.Windows.Forms.DataGridView TimeTableView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label ListLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckedListBox EmptyClassDayList;
        private System.Windows.Forms.Button saveOptionBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox maxRelayTime;
        private System.Windows.Forms.ComboBox minRelayTime;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox PWTextBox;
        private System.Windows.Forms.Button convertIMG;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox yearbox;
    }
}

