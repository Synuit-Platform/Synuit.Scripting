//
//  Synuit.Scripting - Script Engine Plugin Framework
//  Copyright © 2018 Synuit Software.  All Rights Reserved.
//
//  This work contains trade secrets and confidential material of
//  Synuit, and its use or disclosure in whole or in part
//  without the express written permission of Synuit is prohibited.
//
using Synuit.Scripting.Types;
using System;

//
namespace Synuit.Scripting
{
   [Serializable]
   public class Script : IScript
   {
      public string Name { get; set; } = "";

      //
      public string FileName { get; set; } = "";

      //
      public bool Compiled { get; set; } = false;

      //
      public string Code { get; set; } = "";

      //
      public string ClassName { get; set; } = "";

      //
      public string MethodName { get; set; } = "";

      //
      public object Instance { get; set; }
      public string Template { get; set; } = "";
      public IScriptParts ScriptParts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

      //
      public override string ToString()
      {
         return string.Format("ScriptName={0}, FileName={1}, Compiled={2}, ClassName={3}, MethodName={4} ", this.Name, this.FileName, this.Compiled, this.ClassName, this.MethodName) + "{" + base.ToString() + "}";
      }
   }
}