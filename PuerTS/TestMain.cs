using Puerts;
using System;
using System.Collections.Generic;
using System.Text;
using Puerts;

namespace PuerTS
{
    internal class TestMain
    {
        public static void Main()
        {
            var jsEnv = new JsEnv(new TxtLoader());
            jsEnv.Eval(@"
                CS.System.Console.WriteLine('hello world');
            ");
            jsEnv.Dispose();
        }
    }
}
