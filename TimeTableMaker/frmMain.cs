using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace TimeTableMaker
{
    public partial class frmMain : Form
    {
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private Boolean TryLogin = false, Posted = false;
        private SQLiteConnection conn = null;
        public string DataDir = "TimeTablerMaker.ini";

        TimeTable TableMaker = new TimeTable();
        int MaxPage = 1;

        public frmMain()
        {
            InitializeComponent();
        }

        public bool DBCreate()
        {
            string sql = @"CREATE TABLE `course` (
	                        `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
	                        `Level` INTEGER NULL DEFAULT 0,
	                        `Division` VARCHAR(64) NULL DEFAULT '0',
	                        `Code` VARCHAR(64) NULL DEFAULT '0',
	                        `Class` INTEGER NULL DEFAULT 0,
	                        `Name` VARCHAR(64) NULL DEFAULT '0',
	                        `Credit` INTEGER NULL DEFAULT 0,
	                        `Professor` VARCHAR(64) NULL DEFAULT '0',
	                        `MaxStudent` INTEGER NULL DEFAULT 0,
	                        `Time` VARCHAR(64) NULL DEFAULT '0',
	                        `Classroom` VARCHAR(64) NULL DEFAULT '0',
	                        `Campus` VARCHAR(64) NULL DEFAULT '0',
	                        `Note` VARCHAR(64) NULL DEFAULT '0'
                        );";

            if (!File.Exists(Const.dbName))
            {
                SQLiteConnection.CreateFile(Const.dbName);
                conn = new SQLiteConnection("Data Source=" + Const.dbName + ";Version=3;");
                conn.Open();

                SQLiteCommand command = new SQLiteCommand(sql, conn);
                int result = command.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            return false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            yearbox.Text = DateTime.Now.ToString("yyyy");

            webBrowser1.Visible = false;
            webBrowser1.Dock = DockStyle.Fill;

            if (File.Exists(DataDir))
            {
                StringBuilder temp = new StringBuilder(256);
                GetPrivateProfileString("Account", "ID", "", temp, temp.Capacity, ".\\" + DataDir);
                IDTextBox.Text = temp.ToString();

                GetPrivateProfileString("Setting", "Course", "", temp, temp.Capacity, ".\\" + DataDir);
                textBox1.Text = temp.ToString().Replace("|", "\r\n");
                GetPrivateProfileString("Setting", "Min", "", temp, temp.Capacity, ".\\" + DataDir);
                minRelayTime.SelectedIndex = Convert.ToInt32(temp.ToString());
                GetPrivateProfileString("Setting", "Max", "", temp, temp.Capacity, ".\\" + DataDir);
                maxRelayTime.SelectedIndex = Convert.ToInt32(temp.ToString());
                for (int i = 0; i < 5; i++)
                {
                    GetPrivateProfileString("Setting", "Day" + i, "", temp, temp.Capacity, ".\\" + DataDir);
                    EmptyClassDayList.SetItemChecked(i, (temp.ToString() == "True") ? true : false);
                }
            }

            if (!DBCreate())
                TableMaker.LoadTimeTable();

            TimeTableView.Rows.Clear();
            for (int i = 0; i <= TableMaker.TimeRow.GetUpperBound(0); i++)
            {
                TimeTableView.Rows.Add(TableMaker.TimeRow[i, 0], TableMaker.TimeRow[i, 1], TableMaker.TimeRow[i, 2], TableMaker.TimeRow[i, 3], TableMaker.TimeRow[i, 4], TableMaker.TimeRow[i, 5]);
            }
        }

        private void 시간표생성ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(minRelayTime.SelectedIndex > maxRelayTime.SelectedIndex)
            {
                MessageBox.Show("최소 연강 시간은 최대 연강 시간보다 클 수 없습니다!", "에러", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(textBox1.Text.Length == 0)
            {
                MessageBox.Show("수강할 과목코드를 입력해주세요!", "에러", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool[] EmptyDays = new bool[] { 
                   EmptyClassDayList.GetItemChecked(0), EmptyClassDayList.GetItemChecked(1),
                    EmptyClassDayList.GetItemChecked(2), EmptyClassDayList.GetItemChecked(3),
                    EmptyClassDayList.GetItemChecked(4) 
            };
            if(TableMaker.CreateTimeTable(textBox1.Text, minRelayTime.SelectedIndex, maxRelayTime.SelectedIndex, EmptyDays))
            {
                MaxPage = TableMaker.GroupList.Count;
                TableViewerPage(1);
                ListText.Text = "1";
                ListLabel.Text = "조합 " + MaxPage.ToString() + "개 [학점: " + TableMaker.Credits + "]";
            }
            else
            {
                MessageBox.Show("조건에 부합하는 시간표들이 없습니다!", "에러", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool TableViewerPage(int page)
        {
            if(TableMaker.LoadPage(page))
            {
                TimeTableView.Rows.Clear();
                for (int i = 0; i <= TableMaker.TimeRow.GetUpperBound(0); i++)
                {
                    TimeTableView.Rows.Add(TableMaker.TimeRow[i, 0], TableMaker.TimeRow[i, 1], TableMaker.TimeRow[i, 2], TableMaker.TimeRow[i, 3], TableMaker.TimeRow[i, 4], TableMaker.TimeRow[i, 5]);
                    for (int j = 1; j <= 5; j++)
                    {
                        TimeTableView.Rows[i].Cells[j].Style.ForeColor = Color.FromArgb(255 - TableMaker.ColorRow[i, j].R, 255 - TableMaker.ColorRow[i, j].G, 255 - TableMaker.ColorRow[i, j].B);                        
                        TimeTableView.Rows[i].Cells[j].Style.BackColor = TableMaker.ColorRow[i, j];
                    }
                }
            }

            return false;
        }

        private void ListText_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ListText.Text) < 1)
            {
                ListText.Text = "1";
            }
            TableViewerPage(Convert.ToInt32(ListText.Text));
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            if (0 >= Convert.ToInt32(ListText.Text))
                return;

            ListText.Text = (Convert.ToInt32(ListText.Text) - 1).ToString();
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            if (MaxPage <= Convert.ToInt32(ListText.Text))
                return;

            ListText.Text = (Convert.ToInt32(ListText.Text) + 1).ToString();
        }

        private void dB업데이트ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Posted = false;
            TryLogin = false;
            webBrowser1.Visible = true;
            webBrowser1.Navigate("https://sugang.donga.ac.kr/login.aspx");
        }

        private void saveOptionBtn_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("Account", "ID", IDTextBox.Text, ".\\" + DataDir);
            WritePrivateProfileString("Setting", "Course", textBox1.Text.Replace("\r\n", "|"), ".\\" + DataDir);
            WritePrivateProfileString("Setting", "Min", minRelayTime.SelectedIndex.ToString(), ".\\" + DataDir);
            WritePrivateProfileString("Setting", "Max", maxRelayTime.SelectedIndex.ToString(), ".\\" + DataDir);
            for (int i = 0; i < 5; i++)
                WritePrivateProfileString("Setting", "Day" + i, EmptyClassDayList.GetItemChecked(i).ToString(), ".\\" + DataDir);
        }

        private void convertIMG_Click(object sender, EventArgs e)
        {
            int tmp_height = 0;
            int height = TimeTableView.Height;
            for (int i = 0; i < TimeTableView.RowCount; i++)
                tmp_height += TimeTableView.Rows[i].Height;
            TimeTableView.Height = tmp_height + TimeTableView.RowTemplate.Height;
            Bitmap bitmap = new Bitmap(this.TimeTableView.Width, this.TimeTableView.Height);
            TimeTableView.DrawToBitmap(bitmap, new Rectangle(0, 0, this.TimeTableView.Width, this.TimeTableView.Height));
            Console.WriteLine(TimeTableView.RowTemplate.Height);
            TimeTableView.Height = height;
            bitmap.Save(".\\output.png");
        }

        private void TimeTableView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] splitData = TimeTableView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if(splitData.Count() == 5)
            {
                string[] courseData = splitData[1].Split('-');
                System.Diagnostics.Process.Start("http://student.donga.ac.kr/Univ/SUE/SSUE0052.aspx?gd=01&year=" + yearbox.Text + "&smt=" + (comboBox1.SelectedIndex + 1) * 10 + "&cn=" + courseData[0] + "&cc=" + string.Format("{0:D2}", Convert.ToInt32(courseData[1])) + "&gbn=03");
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!TryLogin && e.Url.Equals("https://sugang.donga.ac.kr/login.aspx"))
            {
                int Flag = 2;
                foreach (HtmlElement item in webBrowser1.Document.GetElementsByTagName("input"))
                {
                    if (item != null && item.Name == "txtStudentCd")
                    {
                        item.SetAttribute("Value", IDTextBox.Text);
                        Flag--;
                    }
                    if (item != null && item.Name == "txtPasswd")
                    {
                        item.SetAttribute("Value", PWTextBox.Text);
                        Flag--;
                    }
                    if (Flag == 0)
                    {
                        webBrowser1.Document.GetElementById("ibtnLogin").InvokeMember("click");
                        TryLogin = true;
                        break;
                    }
                }
            }else if (e.Url.Equals("http://sugang.donga.ac.kr/main.aspx"))
            {
                webBrowser1.Navigate("http://sugang.donga.ac.kr/SUGANGLECTIME.aspx");
            }else if (e.Url.Equals("http://sugang.donga.ac.kr/SUGANGLECTIME.aspx"))
            {
                if (!Posted)
                {
                    Posted = true;
                } else {
                    if (File.Exists(Const.dbName))
                    {

                        HtmlDocument doc = webBrowser1.Document;
                        HtmlElement cm = doc.GetElementById("reglisthead");
                        if (cm == null) return;
                        HtmlElementCollection trs = cm.GetElementsByTagName("TR");

                        if (MessageBox.Show("해당 페이지의 정보를 DB화 시키겠습니까?", "확인 사항", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;

                        conn = new SQLiteConnection("Data Source=" + Const.dbName + ";Version=3;");
                        conn.Open();
                        int 대상학년 = 0, 분반 = 0, 학점 = 0, 최대수강인원 = 0;
                        string 분류 = null, 과목코드 = null, 과목명 = null, 교수 = null, 시간 = null, 교실 = null, 캠퍼스 = null, 비고 = null;
                        
                        String sql;
                        SQLiteCommand command;
                        int result;
                        if (MessageBox.Show("기존 DB데이터를 초기화 후 재 등록하시겠습니까?", "확인 사항", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            sql = "DELETE FROM `course`";
                            command = new SQLiteCommand(sql, conn);
                            result = command.ExecuteNonQuery();
                        }
                        int total = 0, count = 0, noroom = 0;
                        for(int i = 1; i<trs.Count; i++)
                        {
                            HtmlElementCollection tds = trs[i].GetElementsByTagName("TD");
                            대상학년 = Convert.ToInt32(tds[1].InnerHtml);
                            과목코드 = tds[3].InnerHtml;
                            분반 = Convert.ToInt32(tds[4].InnerHtml);
                            과목명 = tds[5].GetElementsByTagName("A")[0].InnerHtml;
                            학점 = Convert.ToInt32(tds[7].InnerHtml);
                            교수 = tds[9].InnerHtml;
                            최대수강인원 = Convert.ToInt32(tds[17].InnerHtml);

                            string tmp_timeetc = tds[20].InnerHtml;
                            if(String.IsNullOrEmpty(tmp_timeetc))
                            {
                                count++;
                                continue;
                            }
                            if (tmp_timeetc.Contains("ZZZZ"))
                            {
                                시간 = tmp_timeetc.Substring(0, tmp_timeetc.IndexOf('('));
                                noroom++;
                                교실 = "";
                                캠퍼스 = "";
                                if (tmp_timeetc.Contains(" "))
                                {
                                    캠퍼스 = tmp_timeetc.Substring(tmp_timeetc.LastIndexOf(' ') + 1, (tmp_timeetc.LastIndexOf(')') - tmp_timeetc.LastIndexOf(' ')));
                                }
                            }else if(tmp_timeetc.Contains("월") ||
                                tmp_timeetc.Contains("화") ||
                                tmp_timeetc.Contains("수") ||
                                tmp_timeetc.Contains("목") ||
                                tmp_timeetc.Contains("금") ||
                                tmp_timeetc.Contains("토"))
                            {
                                시간 = tmp_timeetc.Substring(0, tmp_timeetc.IndexOf('('));
                                교실 = tmp_timeetc.Substring(tmp_timeetc.IndexOf('(') + 1, (tmp_timeetc.LastIndexOf(' ') - tmp_timeetc.IndexOf('(')));
                                캠퍼스 = tmp_timeetc.Substring(tmp_timeetc.LastIndexOf(' ') + 1, (tmp_timeetc.LastIndexOf(')') - tmp_timeetc.LastIndexOf(' ')) - 1);
                            }
                            else
                            {
                                count++;
                                continue;
                            }
                            분류 = tds[2].InnerHtml;
                            비고 = tds[21].InnerHtml;
                            sql = String.Format("Insert Into `course` Values(Null, {0}, \"{1}\", \"{2}\", {3}, \"{4}\", {5}, \"{6}\", {7}, \"{8}\", \"{9}\", \"{10}\", \"{11}\");", 대상학년, 분류, 과목코드, 분반, 과목명, 학점, 교수, 최대수강인원, 시간, 교실, 캠퍼스, 비고);

                            command = new SQLiteCommand(sql, conn);
                            result = command.ExecuteNonQuery();
                            total++;
                        }

                        conn.Close();
                        webBrowser1.Visible = false;
                        MessageBox.Show("총 " + total + "개의 정보를 등록하였고\n교실 정보가 없는 데이터가 " + noroom +"개 있었습니다!\n시간 정보가 없는 데이터가 " + count + "개 있었습니다!", "수행 결과", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TableMaker.LoadTimeTable();
                    }
                }

            }

        }
    }
}
