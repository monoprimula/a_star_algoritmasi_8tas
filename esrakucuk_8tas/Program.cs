using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarAlgoritmasi8TasBulmacasi
{
    // Bu sınıf, uygulamanın başlangıç noktasını içerir.
    static class Program
    {
        // Main metodu, programın ilk çalıştırıldığında yapılacak işlemleri başlatır.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();


            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new AStar8Bulmaca());
        }
    }
}
