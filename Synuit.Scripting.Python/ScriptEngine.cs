//
//  Synuit.Scripting - Script Engine Plugin Framework
//  Copyright © 2018 Synuit Software.  All Rights Reserved.
//
//  This work contains trade secrets and confidential material of
//  Synuit, and its use or disclosure in whole or in part
//  without the express written permission of Synuit is prohibited.
//
using System;

using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
//using Microsoft.Scripting.Hosting;
using Synuit.Scripting.Types;
using Microsoft.Scripting.Hosting;
//
namespace Synuit.Scripting.Python
{
  
   public class ScriptEngine : AbstractScriptEngine
   {
      //$!!$protected ILog _logger = LogManager.GetLogger(typeof(ScriptEngine));
      Microsoft.Scripting.Hosting.ScriptEngine _engine = IronPython.Hosting.Python.CreateEngine();

      public ScriptEngine() : base()
      {
         _references.Add(typeof(ScriptEngine).Assembly.Location);
      }

      //
      public override sealed void Execute(string ScriptName, string code = "", string ClassName = "", string MethodName = "", bool forceRecompile = false, bool forceNewInstance = false)
      {
      }

      public override sealed void Execute(IScript script, object[] args = null)
      {

      }

      public override sealed object CreateInstance(IScript script, object[] args = null)
      {
         throw new NotImplementedException();
      }
      //$!!$
      public override sealed T CreateInstance<T>(string filename, string className, object[] args = null)
      {
         throw new NotImplementedException();
      }

      public override IScript CompileScript(string name, string code)
      {
         throw new NotImplementedException();
      }

      public override object Execute(string code)
      {
         return _engine.Execute(code);
      }

      public override T Execute<T>(string code)
      {
         return _engine.Execute(code);
      }
   }

   class MainClass
   {
      const string program = @"
a = 3
b = 4
a = b*2
";
      public static void Main(string[] args)
      {
         Microsoft.Scripting.Hosting.ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();

         // create a ScriptSource to encapsulate our program and a scope to run it
         ScriptSource source = engine.CreateScriptSourceFromString(program);
         ScriptScope scope = engine.CreateScope();

         // Execute the script in 'scope'
         source.Execute(scope);

         // access the variables from the 'scope'
         var varA = scope.GetVariable("a");
         var varB = scope.GetVariable("b");

         Console.WriteLine("a: {0}, b: {1}", varA, varB);
      }
   }


}