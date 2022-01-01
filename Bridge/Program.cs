using System;
using System.Linq;

namespace Bridge
{
    class Program
    {
        public abstract class ReaderApp
        {
            public string Text { get; set; }

            protected IDisplayFormatter _displayFormatter;
            public ReaderApp(IDisplayFormatter displayFormatter){
                _displayFormatter = displayFormatter;
            }

            public abstract void Display();
        }

        public class Windows7: ReaderApp
        {
            public Windows7(IDisplayFormatter displayFormatter) : base(displayFormatter)
            {
            }

            public override void Display()
            {
                _displayFormatter.Display("Aplicación utilizada desde Windows 7 \n" + Text);
            }
        }

        public interface IDisplayFormatter
        {
            void Display(string text);
        }

        public class NormalDisplay : IDisplayFormatter
        {
            public void Display(string text)
            {
                Console.WriteLine(text);
            }
        }

        public class ReverseDisplay : IDisplayFormatter
        {
            public void Display(string text)
            {
                Console.WriteLine(text.Reverse().ToArray());
            }
        }

        public class Windows10 : ReaderApp
        {
            public Windows10(IDisplayFormatter displayFormatter) : base(displayFormatter)
            {
            }

            public override void Display()
            {
                _displayFormatter.Display("Aplicación utilizada desde Windows 10 \n" + Text);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("BRIDGE" + '\n');
            Console.WriteLine("Para desacoplar las abstracciones de su implementacion." + '\n');

            ReaderApp appWindows7 = new Windows7(new NormalDisplay()) { Text = "Aprendiendo Bridge" };
            appWindows7.Display();
            ReaderApp appWindows10 = new Windows10(new NormalDisplay()) { Text = "Aprendiendo Bridge" };
            appWindows10.Display();
          
            ReaderApp appWindowsReverse7 = new Windows7(new ReverseDisplay()) { Text = "Aprendiendo Bridge" };
            appWindowsReverse7.Display();
            ReaderApp appWindowsReverse10 = new Windows10(new ReverseDisplay()) { Text = "Aprendiendo Bridge" };
            appWindowsReverse10.Display();

            Console.ReadLine();
        }
    }
}
