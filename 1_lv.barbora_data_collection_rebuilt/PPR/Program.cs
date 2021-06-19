using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;


namespace PPR
{
    public static class MyFunkyExtensions
    {
        public static IEnumerable<TResult> ZipTen <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this IEnumerable<T1> source,
            IEnumerable<T2> second,
            IEnumerable<T3> third,
            IEnumerable<T4> fourth,
            IEnumerable<T5> fift,
            IEnumerable<T6> sixt,
            IEnumerable<T7> seventh,
            IEnumerable<T8> eight,
            IEnumerable<T9> ninth,
            IEnumerable<T10> tenth,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
        {
            using (var e1 = source.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            using (var e3 = third.GetEnumerator())
            using (var e4 = fourth.GetEnumerator())
            using (var e5 = fift.GetEnumerator())
            using (var e6 = sixt.GetEnumerator())
            using (var e7 = seventh.GetEnumerator())
            using (var e8 = eight.GetEnumerator())
            using (var e9 = ninth.GetEnumerator())
            using (var e10 = tenth.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext() && e4.MoveNext() && e5.MoveNext() && e6.MoveNext() && e7.MoveNext() && e8.MoveNext() && e9.MoveNext() && e10.MoveNext())
                    yield return func(e1.Current, e2.Current, e3.Current, e4.Current, e5.Current, e6.Current, e7.Current, e8.Current, e9.Current, e10.Current);
            }



        }
    }

    public static class MyFunkyExtensions2
    {
        public static IEnumerable<TResult> ZipThree<T1, T2, T3, TResult>(
            this IEnumerable<T1> source,
            IEnumerable<T2> second,
            IEnumerable<T3> third,
            Func<T1, T2, T3, TResult> func)
        {
            using (var e1 = source.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            using (var e3 = third.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                    yield return func(e1.Current, e2.Current, e3.Current);
            }
        }

    }


    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Barbora());

            HtmlWeb web = new HtmlWeb();



        }


    }
}
