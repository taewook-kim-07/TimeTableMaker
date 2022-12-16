using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace TimeTableMaker
{
    class Const
    {
        public static string dbName = "test.db";
    }

    class TimeTable
    {
        public string[,] TimeRow = new string[,]
        {
            { "3교시\n09:00 ~09:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "4교시\n09:30 ~10:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "5교시\n10:00 ~10:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "6교시\n10:30 ~11:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "7교시\n11:00 ~11:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "8교시\n11:30 ~12:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "9교시\n12:00 ~12:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "10교시\n12:30 ~13:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "11교시\n13:00 ~13:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "12교시\n13:30 ~14:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "13교시\n14:00 ~14:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "14교시\n14:30 ~15:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "15교시\n15:00 ~15:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "16교시\n15:30 ~16:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "17교시\n16:00 ~16:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "18교시\n16:30 ~17:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "19교시\n17:00 ~17:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
            { "20교시\n17:30 ~18:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
        };

        public Color[,] ColorRow = new Color[31,6];

        public class Course
        {
            public int 인덱스 { get; set; }
            public class CourseTime
            {
                public int 요일 { get; set; }
                public int 시작 { get; set; }
                public int 종료 { get; set; }
            }
            public string 과목명 { get; set; }
            public string 과목코드 { get; set; }
            public int 분반 { get; set; }
            public string 교수 { get; set; }
            public List<CourseTime> 시간 = new List<CourseTime>();
            public string 교실 { get; set; }
            public string 캠퍼스 { get; set; }
            public bool 유형 { get; set; }
            public string 비고 { get; set; }
            public int 학점 { get; set; }
        }
        public List<Course> CourseList = new List<Course>();
 
        public class CourseGroup
        {
            public int 인덱스 { get; set; }
            public string 과목코드 { get; set; }
            public List<int> 분반 = new List<int>();
        }
        public List<CourseGroup> CompareList = new List<CourseGroup>();
        public List<List<string>> GroupList = new List<List<string>>();
        public int Credits = 0;

        public bool LoadTimeTable()
        {
            CourseList.Clear();
            if (File.Exists(Const.dbName))
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + Const.dbName + ";Version=3;"))
                {
                    string tmpTime, tmpCode = "\n\n\n", cmpCode = "\n\n\n";
                    int tmpDays = 0, tmpClass = 0, cmpClass = 0;

                    conn.Open();
                    string sql = "SELECT * FROM `course`";

                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    SQLiteDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tmpCode = rdr["Code"].ToString();
                        tmpClass = Convert.ToInt32(rdr["Class"]);
                        if (cmpCode != tmpCode ||
                            cmpClass != tmpClass)
                        {
                            cmpCode = tmpCode;
                            cmpClass = tmpClass;

                            string tmp_Code = rdr["Code"].ToString();
                            string Code_Char = Regex.Replace(tmp_Code, @"\d", "");
                            string Code_Num = Regex.Replace(tmp_Code, @"\D", "");

                            StringBuilder builder = new StringBuilder();
                            byte[] ascii = Encoding.ASCII.GetBytes(Code_Char);
                            foreach (byte aaa in ascii)
                                builder.Append(aaa);
                            builder.Append(Code_Num);
                            CourseList.Add(new Course
                            {                                
                                인덱스 = Convert.ToInt32(builder.ToString()),//Convert.ToInt32(rdr["ID"]),
                                과목명 = rdr["Name"].ToString(),
                                과목코드 = rdr["Code"].ToString(),
                                분반 = Convert.ToInt32(rdr["Class"]),
                                교수 = rdr["Professor"].ToString(),
                                교실 = rdr["Classroom"].ToString(),
                                캠퍼스 = rdr["Campus"].ToString(),
                                비고 = rdr["Note"].ToString(),
                                학점 = Convert.ToInt32(rdr["Credit"]),
                            }) ;
                        }
                        tmpTime = rdr["Time"].ToString();

                        tmpDays = 0;
                        switch(tmpTime.Substring(0, 1))
                        {
                            case "월": { tmpDays = 1; break; }
                            case "화": { tmpDays = 2; break; }
                            case "수": { tmpDays = 3; break; }
                            case "목": { tmpDays = 4; break; }
                            case "금": { tmpDays = 5; break; }
                            default  : { tmpDays = 0; break; }
                        }
                        string[] result = tmpTime.Substring(1).Split('-');
                        CourseList[CourseList.Count - 1].시간.Add(new Course.CourseTime { 요일 = tmpDays, 시작 = Convert.ToInt32(result[0]), 종료 = Convert.ToInt32(result[1]) });
                    }
                    rdr.Close();
                    cmd.Dispose();
                    conn.Close();
                }
                return true;
            }
            return false;
        }

        public bool CreateTimeTable(string Data, int Min, int Max, bool[] EmptyDays)
        {
            List<CourseGroup> tmpList = new List<CourseGroup>();
            CompareList.Clear();

            string[] splitData = Data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if(splitData.Count() > 0)
            {
                foreach (string tmpData in splitData)
                {
                    if (tmpData.Contains("-"))
                    {
                        string[] splitData2 = tmpData.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                        if(splitData2.Count() == 2)
                        {
                            List<int> tmp_Class = new List<int>();
                            if(splitData2[1].Contains(","))
                            {
                                string[] splitClass = splitData2[1].Split(',');
                                for(int i=0; i< splitClass.Count(); i++)
                                    tmp_Class.Add(Convert.ToInt32(splitClass[i]));
                            }else
                                tmp_Class.Add(Convert.ToInt32(splitData2[1]));
                            tmpList.Add(new CourseGroup { 과목코드 = splitData2[0], 분반 = tmp_Class });
                        }else
                        {
                            tmpList.Add(new CourseGroup { 과목코드 = splitData2[0], 분반 = new List<int>() }) ;
                        }
                    }
                    else
                    {
                        tmpList.Add(new CourseGroup { 과목코드 = tmpData, 분반 = new List<int>() });
                    }
                }
            }
            for(int i=0; i<tmpList.Count; i++)
            {
                foreach(Course Cmp in CourseList)
                {
                    if (Cmp.과목코드 == tmpList[i].과목코드)
                        tmpList[i].인덱스 = Cmp.인덱스;
                }
            }
            CompareList = tmpList.OrderBy(x => x.인덱스).ToList();
            
            StartCompareTimeTable(CompareList, 0);
            PickupTimeTable(GroupList, Min, Max, EmptyDays);

            if (GroupList.Count == 0) 
                return false;
            else
                return true;
        }

        public bool LoadPage(int page)
        {
            if (page > 0 && page <= GroupList.Count)
            {
                TimeRow = new string[,] {
                    { "3교시\n09:00 ~09:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "4교시\n09:30 ~10:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "5교시\n10:00 ~10:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "6교시\n10:30 ~11:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "7교시\n11:00 ~11:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "8교시\n11:30 ~12:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "9교시\n12:00 ~12:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "10교시\n12:30 ~13:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "11교시\n13:00 ~13:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "12교시\n13:30 ~14:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "13교시\n14:00 ~14:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "14교시\n14:30 ~15:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "15교시\n15:00 ~15:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "16교시\n15:30 ~16:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "17교시\n16:00 ~16:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "18교시\n16:30 ~17:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "19교시\n17:00 ~17:30", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                    { "20교시\n17:30 ~18:00", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n", "\n\n\n" },
                };

                for (int i = 0; i < 31; i++)
                    for (int j = 0; j < 6; j++)
                        ColorRow[i, j] = Color.White;
                
                Credits = 0;

                foreach (String result in GroupList[page - 1])
                {
                    string[] tmp_string = result.Split('-');
                    if(tmp_string.Count() == 2)
                    {
                        foreach (Course AList in CourseList)
                        {
                            if (AList.과목코드 == tmp_string[0] &&
                                AList.분반 == Convert.ToInt32(tmp_string[1]))
                            {
                                Random rm = new Random(AList.인덱스);
                                int _r = rm.Next(256), _g = rm.Next(256), _b = rm.Next(256);
                                foreach (Course.CourseTime BList in AList.시간)
                                {
                                    for (int i = BList.시작; i <= BList.종료; i++)
                                    {
                                        TimeRow[i - 3, BList.요일] = AList.과목명 + "\n" + AList.과목코드 + "-" + AList.분반 + "\n" + AList.교실 + " (" + AList.캠퍼스 + ")\n" + AList.교수 + "\n" + AList.비고;
                                        ColorRow[i - 3, BList.요일] = Color.FromArgb(_r, _g, _b);
                                    }
                                }
                                Credits = Credits + AList.학점;
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }

        #region 조합생성
        Stack<string> stack = new Stack<string>();
        bool[,] checkoverlap = new bool[6, 31];
        int[,] timeoverlap = new int[6, 31];

        public void StartCompareTimeTable(List<CourseGroup> Data, int idx)
        {
            bool flag = false;
            GroupList.Clear();
            stack.Clear();

            CompareTimeTable(Data, idx);
            for (int x = 0; x < GroupList.Count; x++)
            {
                for (int i = 1; i < 6; i++)
                    for (int j = 1; j < 31; j++)
                        checkoverlap[i, j] = false;

                foreach (String BList in GroupList[x])
                {
                    if (flag) break;
                    string[] tmp_Str = BList.Split('-');
                    foreach(Course CList in CourseList)
                    {
                        if (flag) break;
                        if (CList.과목코드 == tmp_Str[0] &&
                            CList.분반 == Convert.ToInt32(tmp_Str[1]))
                        {
                            foreach (Course.CourseTime CTime in CList.시간)
                            {
                                if (flag) break;
                                for (int i = CTime.시작; i <= CTime.종료; i++)
                                {
                                    if (checkoverlap[CTime.요일, i])
                                    {
                                        flag = true;
                                        break;
                                    }
                                    checkoverlap[CTime.요일, i] = true;
                                }
                            }
                        }                        
                    }
                }

                if(flag)
                {
                    GroupList[x].Clear();
                    flag = false;
                }
            }

            for (int i = GroupList.Count - 1; i >= 0; i--)
            {
                if (GroupList[i].Count == 0)
                {
                    GroupList.RemoveAt(i);
                }
            }
        }

        public bool PickupTimeTable(List<List<String>> Data, int Min, int Max, bool[] EmptyDays)
        {
            bool flag = false;
            int min_t = 999, max_t = -1;

            for (int i=0; i<Data.Count; i++)
            {
                for (int k = 1; k < 6; k++)
                    for (int m = 1; m < 31; m++)
                        timeoverlap[k, m] = -1;

                flag = false;
                min_t = 999;
                max_t = -1;

                foreach (String AList in Data[i])
                {
                    if (flag) break;

                    string[] tmp_str = AList.Split('-');
                    foreach (CourseGroup BList in CompareList)
                    {
                        if (flag) break;
                        if(BList.과목코드 == tmp_str[0])
                        {
                            if(BList.분반.Count > 0)
                            {
                                flag = true;
                                foreach (int Class in BList.분반)
                                {
                                    if (Class == Convert.ToInt32(tmp_str[1]))
                                    {
                                        flag = false;
                                    }
                                }
                            }
                        }
                    }

                    foreach (Course CList in CourseList)
                    {
                        if (flag) break;
                        if (CList.과목코드 == tmp_str[0] &&
                            CList.분반 == Convert.ToInt32(tmp_str[1]))
                        {
                            foreach (Course.CourseTime CTime in CList.시간)
                            {
                                if (EmptyDays[CTime.요일 - 1])
                                {
                                    flag = true;
                                    break;
                                }
                                for (int j = CTime.시작; j <= CTime.종료; j++)
                                    timeoverlap[CTime.요일, j] = CList.인덱스;
                            }
                        }
                    }
                }

                if(!flag)
                {
                    int lasttime = -1;
                    for (int k = 1; k < 6; k++)
                    {
                        lasttime = -1;
                        for (int m = 1; m < 31; m++)
                        {
                            if (timeoverlap[k, m] == -1) 
                                continue;

                            for (int x = m; x < 31; x++)
                            {
                                if (timeoverlap[k, x] == -1) 
                                    continue;

                                if (timeoverlap[k, m] == timeoverlap[k, x])
                                {
                                    lasttime = x;
                                }
                                else if (lasttime != -1 && timeoverlap[k, x] >= 0)
                                {
                                    if ((x - lasttime) < min_t)
                                        min_t = (x - lasttime);

                                    if ((x - lasttime) > max_t)
                                        max_t = (x - lasttime);

                                    lasttime = -1;
                                }
                            }                       
                        }
                    }
                    if(Min >= min_t)
                        flag = true;
                    if(Max < max_t - 1)
                        flag = true;
                }

                if(flag)
                {
                    Data[i].Clear();
                }
            }

            for (int i = Data.Count - 1; i >= 0; i--)
            {
                if (Data[i].Count == 0)
                {
                    Data.RemoveAt(i);
                }
            }
            return true;
        }

        public bool CompareTimeTable(List<CourseGroup> Data, int idx)
        {
            if (Data.Count == idx)
            {
                List<String> result = new List<String>();
                foreach (string s in stack)
                    result.Add(s);
                GroupList.Add(result);
                return true;
            }
            List<int> ClassList = FindClassList(Data[idx].과목코드);
            foreach(int Class in ClassList)
            {
                stack.Push(Data[idx].과목코드 + '-' + Class.ToString());
                CompareTimeTable(Data, idx + 1);
                stack.Pop();
            }
            /*
            foreach(Course AList in CourseList)
            {
                if (AList.과목코드 != Data[idx].과목코드)
                    continue;

                for(int x=0; x<ClassList.Count; x++)
                {
                    if (AList.분반 != ClassList[x])
                        continue;

                    if (idx == 0)
                    {
                        for (int i = 1; i < 6; i++)
                            for (int j = 1; j < 31; j++)
                                checkoverlap[i, j] = false;
                    }
                    bool flag = false;
                    for (int i = 1; i < 6; i++)
                        for (int j = 1; j < 31; j++)
                            matchoverlap[i, j] = false;

                    foreach (Course.CourseTime ATime in AList.시간)
                    {
                        for (int i = ATime.시작; i <= ATime.종료; i++)
                            matchoverlap[ATime.요일, i] = true;
                    }

                    for (int i = 1; i < 6; i++)
                    {
                        if (flag) break;
                        for (int j = 1; j < 31; j++)
                        {
                            if (checkoverlap[i, j] && matchoverlap[i, j])
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        StringBuilder builder = new StringBuilder();
                        foreach (string s in stack)
                            builder.Append(s + "  ");

                        Console.WriteLine(Data[idx].과목코드 + '-' + ClassList[x].ToString() + "  " + builder);
                        if ((Data[idx].과목코드 + '-' + ClassList[x].ToString() + "  " + builder) == "DEE311-1  DEE309-2  DEE305-5  DEE207-2  ")
                        {
                            Console.WriteLine(Data[idx].과목코드 + '-' + ClassList[x].ToString() + "  " + builder);
                            for (int i = 1; i < 31; i++)
                            {
                                Console.Write(i + "  ");
                                for (int j = 1; j < 6; j++)
                                {
                                    Console.Write(checkoverlap[j, i] + "  ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    if(flag && idx > 0)
                    {
                        string[] tmp_str = stack.Peek().Split('-');
                        foreach (Course BList in CourseList)
                        {
                            if (BList.과목코드 != tmp_str[0] ||
                                BList.분반 != Convert.ToInt32(tmp_str[1]))
                                continue;

                            foreach (Course.CourseTime BTime in BList.시간)
                            {
                                for (int i = BTime.시작; i <= BTime.종료; i++)
                                    checkoverlap[BTime.요일, i] = false;
                            }
                        }
                    }
                    if (flag) continue;

                    for (int i = 1; i < 6; i++)
                        for (int j = 1; j < 31; j++)
                        {
                            if (!matchoverlap[i, j])
                                continue;
                            checkoverlap[i, j] = true;
                        }
                    stack.Push(Data[idx].과목코드 + '-' + ClassList[x].ToString());
                    CompareTimeTable(Data, idx + 1);
                    stack.Pop();
                }
            }*/
            return false;
        }

        public List<int> FindClassList(String 과목코드)
        {
            List<int> result = new List<int>();

            foreach (Course CList in CourseList)
            {
                if (CList.과목코드 == 과목코드)
                {
                    result.Add(CList.분반);
                }
            }
            return result;
        }
        #endregion
    }
}
