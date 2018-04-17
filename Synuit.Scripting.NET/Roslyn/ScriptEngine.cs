//
//  Synuit.Scripting - Script Engine Plugin Framework
//  Copyright © 2018 Synuit Software.  All Rights Reserved.
//
//  This work contains trade secrets and confidential material of
//  Synuit, and its use or disclosure in whole or in part
//  without the express written permission of Synuit is prohibited.
//
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
//
using Synuit.Scripting.Types;
//
namespace Synuit.Scripting.NET.Roslyn
{
   public class ScriptEngine : NET.ScriptEngine
   {
      //protected ILog _logger = LogManager.GetCurrentClassLogger();
      //private readonly Precept.Architecture.IContainer _container = Container.Get;

      public ScriptEngine() : base()
      {
         _references.Add(typeof(ScriptEngine).Assembly.Location);
      }

      //
      public override IScript CompileScript(string ScriptName, string code)
      {
         try
         {
            //$!!$_logger.Debug(m => m(string.Format("Compiling program {0} into: {1}", ScriptName, ScriptName + ".dll...")));
            //
            //$!!$_logger.Debug(m => m(string.Format("Parsing source code for program {0}...", ScriptName)));
            //
            //var tree = CSharpSyntaxTree.ParseText(code);
            var tree = SyntaxFactory.ParseSyntaxTree(code);
            //
            //$!!$_logger.Debug(m => m(string.Format("Building metadata references for program {0}...", ScriptName)));
            //
            // --> build metadata references to support "using's" in code.
            //$--$ MetadataFileReference [] refs = new MetadataFileReference[_references.Count];
            //$!!$ AssemblyMetadata
            MetadataReference [] references = new MetadataReference[_references.Count];
            for (int i = 0; i < _references.Count; i++)
            {
               references[i] = MetadataReference.CreateFromFile( _references[i] );
            }
            //$!!$_logger.Debug(m => m(string.Format("Building program {0}...", ScriptName)));
            //////var compilation = CSharpCompilation.Create
            //////(
            //////   ScriptName + ".dll",
            //////   options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary),
            //////   syntaxTrees: new[] { tree },
            //////   references: references
            //////);
            var compilation = CSharpCompilation.Create(ScriptName + ".dll")
               .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
               .AddReferences(references)
               .AddSyntaxTrees(tree);
            //
            Assembly compiledAssembly;
            //////using (var stream = new MemoryStream())
            //////{
            //////   EmitResult compileResult = compilation.Emit(stream);
            //////   compiledAssembly = Assembly.Load(stream.GetBuffer());
            //////}

            using (var dllStream = new MemoryStream())
            using (var pdbStream = new MemoryStream())
            {
               //string path = Path.Combine(Directory.GetCurrentDirectory(), compilation.AssemblyName);
               //var emitResult = compilation.Emit(path);
               var emitResult = compilation.Emit(dllStream, pdbStream);

               if (!emitResult.Success)
               {
                  foreach (var diagnostic in emitResult.Diagnostics)
                  {
                     var debug = diagnostic.ToString();
                     Console.WriteLine(debug);
                  }
                  return null;
               }
               //
               compiledAssembly = Assembly.Load(dllStream.GetBuffer());

               //compiledAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);

               // emitResult.Diagnostics
               //
               //$!!$_logger.Debug(m => m(string.Format("Compile complete, adding script to cache...")));
               //
               IScript script = _container.Resolve<IScript>();
               script.Name = ScriptName;
               script.FileName = ScriptName + ".dll";
               script.Compiled = true;
               script.Code = code;
               ((Script)script).Assembly = compiledAssembly;
               //
               this._scripts.Add(ScriptName, script);
               //$!!$_logger.Debug(m => m(string.Format("Script successfully added to script cache.")));
               return script;
            
            }


           
            //
            
            
         }
         catch (Exception e)
         {
            //$!!$_logger.Info(m => m(string.Format("Error compiling program {0}: {1}", ScriptName, e)));
            throw;
         }
      }
   }
}