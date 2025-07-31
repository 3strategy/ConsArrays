using System.Reflection.Metadata;
//קישור לפתרון: https://docs.google.com/document/d/1BV4tA68PYnwoWDvuK9vQ6A2j1U624phN98D7_YkeEhM/edit?usp=sharing

namespace ConsArrays
{
    public class Program
    {

        /// <summary>
        /// 9.1.1
        ///    יש לכתוב תוכנית הקולטת 10 ציונים של תלמיד ומכניסה למערך.
        ///                                   על התוכנית לחשב ולהדפיס:
        ///    א.ממוצע ציונים עם בדיוק 2 ספרות אחרי הנקודה.למשל 90.50 
        ///                 ב.רשימת הציונים בהם הציונים הם מעל הממוצע
        ///               ג. רשימת הציונים בהם הציון קטן או שווה ל-60
        ///   Excellent ד.אם ממוצע הציונים מעל 90 יש להדפיס את ההודעה
        ///                  דוגמא לפלט:
        ///                  Average: 93.50 
        ///                  Above Average: 95, 95, 95, 100, 100, 100, 100, 100, 100,
        ///                  Below 60:  50,  // שורה זו תודפס רק אם היו ציונים נמוכים מ-60!!!
        ///                  Excellent                                               
        /// </summary>
        public static void Q911()
        {
            //כתבו את הפתרון שלכם כאן
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Nothing to see here at === Q911 === till you write your code");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(string.Concat("תמחקו את הקוד הזה ותכתבו את הפתרון שלכם במקומו".Reverse()));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Concat("إحذفوا هذا الكود واكتبوا حلكم مكانه".Reverse()));
            Console.WriteLine("Delete this code and put in yours");
            Console.ForegroundColor = ConsoleColor.White;
        }


        /// <summary>
        /// יש לכתוב תוכנית הקולטת 8 שמות של תלמידים 
        /// Console.WriteLine("Enter a name:"); // יש להשתמש בדיוק בבקשת הקלט הבאה
        /// ומוסיפה אותם לרשימת תלמידי הכיתה באופן הבא:
        /// יש לקלוט שם של תלמיד חדש הרוצה להצטרף לכיתה יש לבדוק
        /// אם שם זה כבר מופיע בכיתה. במידה ששם זה לא קיים
        /// יש להוסיף שם זה לכיתה. במידה שכבר קיים תלמיד עם שם זהה
        /// יש להדפיס הודעה:
        /// We cannot assign you to this class
        /// string[] names = new string[8]; התכנית תשתמש במערך שמות בכיתה 
        /// ובו תשים את התלמידים שהתקבלו לכיתה נמצאים בכיתה
        /// אין צורך להדפיס את השמות. תוכנית הבדיקה תאשר שהפתרון נכון
        /// </summary>
        public static void Q912()
        {
            //כתבו את הפתרון שלכם כאן
            Console.WriteLine("Nothing to see here at Q912 till you write your code");

        }


        //Q2 = מעקב
        public static void MainQ2()
        {
            int m = 0;
            int x, a;
            x = int.Parse(Console.ReadLine());
            for (int i = 1; i <= x; i++)
            {
                a = int.Parse(Console.ReadLine());
                if (a < 10 || a > 99)
                    m++;
                else
                    Console.WriteLine(a / 10);
            }
            Console.WriteLine(m);
        }

        static void Main(string[] args)
        {
            Q911(); // באפשרותכם להריץ את השאלות ולבדוק גם באופן ידני
        }
    }
}
