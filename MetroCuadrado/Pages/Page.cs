using System;

namespace MetroCuadrado.Pages
{
    public class Page
    {
        [ThreadStatic]
        public static HomePage Home;

        public static void Init()
        {
            Home = new HomePage();
        }
    }
}
