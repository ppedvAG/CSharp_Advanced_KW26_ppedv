using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloAsync
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitPara(string mmmmmm);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate meinDele = EinfacheMethode;
            EinfacherDelegate meineAno = delegate () { Console.WriteLine("Hallo"); };

            Action meinDeleAlsActionAno = () => { Console.WriteLine("Hallo"); };
            Action meinDeleAlsActionAno2 = () => Console.WriteLine("Hallo");

            Action meinDeleAlsAction = EinfacheMethode;


            DelegateMitPara deleMitPara = MethodeMitPara;
            DelegateMitPara deleMitParaAno = delegate (string mmm) { Console.WriteLine(mmm); };
            Action<string> deleMitParaAction = MethodeMitPara;
            DelegateMitPara deleMitParaAno2 = (x) => { Console.WriteLine(x); };
            Action<string> deleMitParaAno3 = (x) => Console.WriteLine(x);
            DelegateMitPara deleMitParaAno4 = x => Console.WriteLine(x);

            CalcDelegate calcDele = Minus;
            Func<int, int, long> calcAlsFunc = Minus;
            CalcDelegate calcDeleFunc = (x, y) => { return x + y; };
            CalcDelegate calcDeleFunc2 = (x, y) => x + y;

            var lll = new List<string>();
            lll.Where(x => x.StartsWith("B"));
            lll.Where(Filter);
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("B"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void MethodeMitPara(string txt)
        {
            Console.WriteLine($"Hallo {txt}");
        }

        public void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }
    }
}
