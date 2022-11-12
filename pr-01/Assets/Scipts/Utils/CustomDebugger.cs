using UnityEngine;

namespace _517pm.Debugger
{
    public static class CustomDebugger
    {
        public static void HelloWorld(bool needTime = false)
            => Debug.Log("Hello World" + (!needTime ? " " : " => " + Time.time));

        public static void ItWorks(bool needTime = false)
            => Debug.Log("It Works!" + (!needTime ? " " : " => " + Time.time));

        public static void PrintContextWithTime(string text, bool needTime = false)
            => Debug.Log(text + (!needTime ? " " : " => " + Time.time));

        public static void TheActionIsWorking(bool needTime = false)
            => Debug.Log("The Action works!!!" + (!needTime ? " " : " => " + Time.time));
    }
}
