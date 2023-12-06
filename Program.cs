using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Running_game
{
    internal static class Program
    {
        static public string userName; //정적으로 선언된 공용 문자열 변수 userName을 선언함.
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); //시각적스타일 활성화
            Application.SetCompatibleTextRenderingDefault(false); //기본값으로 텍스트 렌더링 설정
            Application.Run(new StartForm()); //StartForm을 프로그램 초기폼으로 나타냄.
        }
    }
}
