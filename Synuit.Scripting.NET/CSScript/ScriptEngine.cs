//
//  Synuit.Scripting - Script Engine Plugin Framework
//  Copyright © 2018 Synuit Software.  All Rights Reserved.
//
//  This work contains trade secrets and confidential material of
//  Synuit, and its use or disclosure in whole or in part
//  without the express written permission of Synuit is prohibited.
//
using System;
//
using Synuit.Scripting.Types;
//
namespace Synuit.Scripting.NET.CSScript
{
   public class ScriptEngine : NET.ScriptEngine
   {
      //protected ILog _logger = LogManager.GetCurrentClassLogger();

      public ScriptEngine() : base()
      {
         _references.Add(typeof(ScriptEngine).Assembly.Location);
      }

      public override IScript CompileScript(string ScriptName, string code)
      {
         throw new NotImplementedException();
         ////////try
         ////////{
         ////////   _logger.Debug(m => m(string.Format("Compiling program {0} into: {1}", ScriptName, ScriptName + ".dll...")));
         ////////   //
         ////////   _logger.Debug(m => m(string.Format("Parsing source code for program {0}...", ScriptName)));
         ////////   //
         ////////   _logger.Debug(m => m(string.Format("Building metadata references for program {0}...", ScriptName)));
         ////////   //
         ////////   _logger.Debug(m => m(string.Format("Building program {0}...", ScriptName)));
         ////////   //
         ////////   Assembly compiledAssembly = CSScriptLibrary.CSScript.LoadCode(code, _references.ToArray());
         ////////   //
         ////////   _logger.Debug(m => m(string.Format("Compile complete, adding script to cache...")));
         ////////   //
         ////////   IScript script = _container.Resolve<IScript>();
         ////////   script.Name = ScriptName;
         ////////   script.FileName = ScriptName + ".dll";
         ////////   script.Compiled = true;
         ////////   script.Code = code;
         ////////   ((Script)script).Assembly = compiledAssembly;
         ////////   //
         ////////   this._scripts.Add(ScriptName, script);
         ////////   //
         ////////   _logger.Debug(m => m(string.Format("Script successfully added to script cache.")));
         ////////   return script;
         ////////}
         ////////catch (Exception e)
         ////////{
         ////////   _logger.Info(m => m(string.Format("Error compiling program {0}: {1}", ScriptName, e)));
         ////////   throw;
         ////////}
      }
   }
}