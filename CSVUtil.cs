using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Running_game
{
    public static class CSVUtil //정적 클래스 CSVUil 클래스 정의
    {
        public static List<ListViewItem> LoadCSV() //LoadCSV 메서드 정의, CSV파일을 읽어서 데이터를 ListViewItem 형태로 반환한다. 
        {
            ListViewItem item; //ListViewItem 객체 선언

            List<ListViewItem> list = new List<ListViewItem>(); //제네릭: Objects는 제네릭 List로, GameObject 형식의 객체들을 저장하는데 사용된다. ListViewItem 저장할 리스트 선언.

            string[] buff = File.ReadAllLines("test.csv", Encoding.UTF8); //test.csv 파일에서 모든 행을 읽어와서 문자열 배열에 저장한다.


            foreach (string d in buff) //buff 배열에 있는 각각의 문자열(d)에 대해 반복함. buff는 CSV파일의 각 행을 포함하는 문자열 배열이다. 
            {
                string[] split = d.Split(','); //현재 행을 쉼표 , 로 분리해서 문자열 배열로 저장. CSV 파일에서 각 열의 값을 나타냄.

                if (split.Length > 0) //분리된 배열의 길이가 0보다 클때
                {
                    if (split[0] != "닉네임") //첫번째 열이 닉네임이 아닌경우에만 실행한다.
                    {
                        item = new ListViewItem(split); //ListViewItem을 생성함.
                        list.Add(item);  //리스트에 추가한다.
                    }
                }
            }
            return list; //읽어온 데이터를 담은 리스트를 반환함.
        }
        public static bool SaveCSV(List<ListViewItem> items) //SaveCSV 메서드 정의. ListViewItem 리스트를 CSV 파일에 저장함.
        {
            List<string> buff = new List<string>(); //CSV파일에 저장할 문자열을 담을 리스트 선언

            buff.Add("닉네임,점수"); //CSV파일 첫번째 행에는 닉네임, 점수 열이름을 추가한다.

            foreach (ListViewItem item in items) //items 리스트에 있는 각각의 ListViewItem에 대해 반복하는 foreach 루프를 시작함.
            {
                buff.Add(item.SubItems[0].Text + "," + item.SubItems[1].Text); //반복중인 ListViewItem의 각 열에 접근해서 그 값을 문자열로 변환하고, 쉼표 , 로 구분해서 buff 리스트에 추가한다.
            }

            File.WriteAllLines("test.csv", buff.ToArray(), Encoding.UTF8);//문자열 리스트를 문자열 배열로 변환해서 test.csv 파일에 저장한다.


            return true; //파일 저장이 성공했음을 나타내는 true를 반환.
        }
    }
}
