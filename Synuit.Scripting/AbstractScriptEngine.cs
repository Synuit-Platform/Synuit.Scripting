//
//  Synuit.Scripting - Script Engine Plugin Framework
//  Copyright © 2018 Synuit Software.  All Rights Reserved.
//
//  This work contains trade secrets and confidential material of
//  Synuit, and its use or disclosure in whole or in part
//  without the express written permission of Synuit is prohibited.
//
using System.Collections.Generic;
//
using Synuit.Toolkit.Types.Platform.DI;
using Synuit.Scripting.Types;
using System.Reflection;
//
namespace Synuit.Scripting
{
   public abstract class AbstractScriptEngine : IScriptEngine
   {
      protected List<string> _references = new List<string>();
      protected Dictionary<string, IScript> _scripts = new Dictionary<string, IScript>();
      protected IContainer _container;

      protected object _hostObject;

      public AbstractScriptEngine()
      {
         _references.Add(typeof(object).GetTypeInfo().Assembly.Location);
         _references.Add(typeof(IScriptEngine).Assembly.Location);
         _references.Add(typeof(AbstractScriptEngine).Assembly.Location);
      }

      public AbstractScriptEngine(IContainer container) : this()
      {
         _container = container;
      }

      //
      public void RegisterObject<THostObject>(THostObject hostObject) where THostObject : class
      {
         _hostObject = hostObject;
      }

      //
      public IDictionary<string, IScript> Scripts { get { return _scripts; } }

      //
      public IList<string> References { get { return _references; } }

      //
      public void SetContainer(IContainer container) { _container = container; }

      //
      public abstract IScript CompileScript(string name, string code);

      //
      public abstract void Execute(string name, string code = "", string className = "", string methodName = "", bool forceRecompile = false, bool forceNewInstance = false);

      //public abstract void Execute( string name, string code );
      public abstract void Execute(IScript script, object[] args = null);

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
      public void AddReference(string path)
      {
         _references.Add(path);
      }
      //
      public abstract object CreateInstance(IScript script, object[] args = null);
      //
      public abstract T CreateInstance<T>(string filename, string className, object[] args = null);

   }
}