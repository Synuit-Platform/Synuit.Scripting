//
//  Synuit.Scripting - Script Engine Plugin Framework
//  Copyright © 2018 Synuit Software. All Rights Reserved.
//
//  This work contains trade secrets and confidential material of
//  Synuit, and its use or disclosure in whole or in part
//  without the express written permission of Synuit is prohibited.
//
using System.Collections.Generic;
//
using Synuit.Toolkit.Types.Platform.DI;

namespace Synuit.Scripting.Types
{
   public interface IScriptEngine
   {
      IDictionary<string, IScript> Scripts { get; }
      IList<string> References { get; }
      //
      void SetContainer(IContainer container);
      //
      void RegisterObject<THostObject>(THostObject hostObject) where THostObject : class;
      //
      void Execute(IScript script, object[] args = null);
      //
      void Execute(string name, string code = "", string className = "", string methodName = "", bool forceRecompile = false, bool forceNewInstance = false);
      //
      IScript CompileScript(string name, string code);
      //
      object CreateInstance(IScript script, object[] args = null);
      //
      T CreateInstance<T>(string filename, string className, object[] args = null);

      //
      // Summary:
      //     Adds a reference to specified assembly.
      //
      // Parameters:
      //   assemblyDisplayNameOrPath:
      //     Assembly display name or path.
      //
      // Exceptions:
      //   System.ArgumentNullException:
      //     assemblyDisplayNameOrPath is null.
      //
      //   System.ArgumentException:
      //     assemblyDisplayNameOrPath is empty.
      //
      //   System.IO.FileNotFoundException:
      //     Assembly file can't be found.
      void AddReference(string path);
   }
}