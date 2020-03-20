//
//  Synuit.Scripting - Script Engine Plugin Framework
//  Copyright © 2018 Synuit Software.  All Rights Reserved.
//
//  This work contains trade secrets and confidential material of
//  Synuit, and its use or disclosure in whole or in part
//  without the express written permission of Synuit is prohibited.
//
using System;
using RDotNet;
using Synuit.Scripting.Types;
//
namespace Synuit.Scripting.R
{
  
   public class ScriptEngine : AbstractScriptEngine
   {
      //$!!$protected ILog _logger = LogManager.GetLogger(typeof(ScriptEngine));


      public ScriptEngine() : base()
      {
         _references.Add(typeof(ScriptEngine).Assembly.Location);
      }

      //
      public override sealed void Execute(string ScriptName, string code = "", string ClassName = "", string MethodName = "", bool forceRecompile = false, bool forceNewInstance = false)
      {
         ////try
         ////{
         ////   IScript script;
         ////   if (!_scripts.TryGetValue(ScriptName, out script))
         ////   {
         ////      //if no source code exists at this point, it's the host's reponsibility to provide it for us
         ////      script = CompileScript(ScriptName, (code != "") ? code : ((IScriptable)_hostObject).LoadScript(ScriptName));
         ////      //if compile, recompile, new instance necessary
         ////      forceNewInstance = true;
         ////   }
         ////   else
         ////   {
         ////      if (forceRecompile == true && code != "")
         ////      {
         ////         //if no source code exists at this point, it's the host's reponsibility to get it for us
         ////         script = CompileScript(ScriptName, (code != "") ? code : ((IScriptable)_hostObject).LoadScript(ScriptName));
         ////         _scripts[ScriptName] = script;
         ////         //if compile, recompile, new instance necessary
         ////         forceNewInstance = true;
         ////      }
         ////   }
         ////   //
         ////   script.ClassName = (ClassName != "") ? ClassName : (script.ClassName == "") ? "Process" : script.ClassName;
         ////   script.MethodName = (MethodName != "") ? MethodName : (script.MethodName == "") ? "Execute" : script.MethodName;
         ////   if (forceNewInstance == true)
         ////   {
         ////      Script oscript = ((Script)script);
         ////      oscript.Instance = this.CreateInstance(script, new[] { _hostObject });//  oscript.Assembly.CreateInstance(oscript.ClassName, true, BindingFlags.Default, null, args: new[] { _hostObject }, culture: null, activationAttributes: null);
         ////   }
         ////   this.Execute(script);
         ////}
         ////catch (Exception e)
         ////{
         ////   //$!!$_logger.Info(m => m(string.Format("Error Executing Script: {0} | ClassName: {1} | MethodName: {2} | error = {3}", ScriptName, ClassName, MethodName, e)));
         ////   throw;
         ////}
         //
         //REngine.SetEnvironmentVariables(); // <-- May be omitted; the next line would call it.
         REngine engine = REngine.GetInstance();
         // A somewhat contrived but customary Hello World:
         CharacterVector charVec = engine.CreateCharacterVector(new[] { "Hello, R world!, .NET speaking" });
         engine.SetSymbol("greetings", charVec);
         engine.Evaluate("str(greetings)"); // print out in the console
         string[] a = engine.Evaluate("'Hi there .NET, from the R engine'").AsCharacter().ToArray();
         Console.WriteLine("R answered: '{0}'", a[0]);
         Console.WriteLine("Press any key to exit the program");
         Console.ReadKey();
         engine.Dispose();

      }

      public override sealed void Execute(IScript script, object[] args = null)
         {
            ////try
            ////{
            ////   Script oscript = ((Script)script);
            ////   //
            ////   Type type = oscript.Assembly.GetType(oscript.ClassName);
            ////   MethodInfo method = type.GetMethod(oscript.MethodName);
            ////   //
            ////   method.Invoke(oscript.Instance, args); //string answer = method.Invoke(oscript.Instance, args);
            ////}
            ////catch (Exception e)
            ////{
            ////   //$!!$_logger.Info(m => m(string.Format("Error Executing Script: {0} | error = {1}", script, e)));
            ////   throw;
            ////}
         }

         public override sealed object CreateInstance(IScript script, object[] args = null)
         {
         ////try
         ////{
         ////   Script oscript = (Script)script;
         ////   Assembly asm = oscript.Assembly;
         ////   Type tClass = asm.GetType(script.ClassName);
         ////   //Type tHost = _hostObject.GetType();
         ////   Type[] parameterTypes = new Type[args.Length];
         ////   //
         ////   for (var i = 0; i < args.Length; i++)
         ////   {
         ////      parameterTypes[i] = args[i].GetType();
         ////   }
         ////   ConstructorInfo ci = tClass.GetConstructor(parameterTypes);
         ////   //
         ////   return ci.Invoke(args);
         ////}
         ////catch (Exception e)
         ////{
         ////   //$!!$_logger.Info(m => m(string.Format("Error Creating Instance: ClassName: {{{0}}} | error = {1}", script.ClassName, e)));
         ////   throw;
         ////}
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
   }
   }