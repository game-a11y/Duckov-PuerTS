namespace Puerts.ThirdParty
{
    // TODO: CommonJS 在文档中已经启用
    public class CommonJS
    {
        public static void InjectSupportForCJS(Puerts.JsEnv env)
        {
            env.ExecuteModule("puer-commonjs/load.mjs");
            env.ExecuteModule("puer-commonjs/modular.mjs");
        }
    }
}