using System;
using Xunit;
//
using Synuit.Scripting.Types;
//
namespace Synuit.Scripting.Testing
{
   public class RoslynTestFixture : IScriptable
   {
      public bool RegisterHostTestPassed = false;
      public bool ExecuteTestPassed = false;

      [Fact]
      public bool CreateInstanceAndRegisterHostWithScriptTest()
      {
         RegisterHostTestPassed = false;
         IScriptEngine se = Container.Get.Resolve<IScriptEngine>();
         se.SetContainer(Container.Get);

         se.RegisterObject<RoslynTestFixture>(this);

         se.AddReference(typeof(RoslynTestFixture).Assembly.Location);
         se.AddReference(typeof(IScriptable).Assembly.Location);

         IScript script = se.CompileScript("MyProcess", code);
         script.ClassName = "Process"; script.MethodName = "Execute";
         ((Script)script).Instance = se.CreateInstance(script, args: new[] { this });

         Assert.True(RegisterHostTestPassed);

         return RegisterHostTestPassed;
      }
      [Fact]
      public bool CompileBadCode()
      {
         RegisterHostTestPassed = false;
         IScriptEngine se = Container.Get.Resolve<IScriptEngine>();
         se.SetContainer(Container.Get);

         se.RegisterObject<RoslynTestFixture>(this);

         se.AddReference(typeof(RoslynTestFixture).Assembly.Location);
         se.AddReference(typeof(IScriptable).Assembly.Location);

         IScript script = se.CompileScript("MyProcess", bad_code);
         return script.HasErrors;

      }


      [Fact]
      public bool ExecuteScriptTest()
      {
         ExecuteTestPassed = false;
         IScriptEngine se = Container.Get.Resolve<IScriptEngine>();
         se.SetContainer(Container.Get);

         se.RegisterObject<RoslynTestFixture>(this);

         se.AddReference(typeof(RoslynTestFixture).Assembly.Location);
         se.AddReference(typeof(IScriptable).Assembly.Location);
         se.Execute("TestScript", code);

         Assert.True(ExecuteTestPassed);

         return RegisterHostTestPassed;
      }

      private const string code =
@"
using System;
using System.Collections.Generic;
using Synuit.Scripting.Testing;

public class Process
{
   RoslynTestFixture _host;
   public Process( RoslynTestFixture host ):base()
   {
      _host = host;
      _host.RegisterHostTestPassed = true;
   }
   public void Execute()
   {
      _host.ExecuteTestPassed = true;
   }
}
";



      private const string bad_code =
@"
using System;
using System.Collections.Generic;
using Synuit.Scripting.Testing;

public class Process
{
   RoslynTestFixture _host;
   public Process( RoslynTestFixture host ):base()
   {
      _host = host;
      _host.RegisterHostTestPasse = true;
   }
   public void Execute()
   {
      _host.ExecuteTestPassed = true;
   }
}
";

      public string LoadScript(string ScriptName)
      {
         throw new NotImplementedException();
      }
   }
}