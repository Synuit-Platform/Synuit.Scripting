//
//  Synuit.Scripting - Script Engine Plugin Framework
//  Copyright © 2018 Synuit Software.  All Rights Reserved.
//
//  This work contains trade secrets and confidential material of
//  Synuit, and its use or disclosure in whole or in part
//  without the express written permission of Synuit is prohibited.
//
namespace Synuit.Scripting.Types
{
   public interface IScript
   {
      string Name { get; set; }

      //
      string FileName { get; set; }

      //
      bool Compiled { get; set; }

      //
      string Code { get; set; }

      //
      string ClassName { get; set; }

      //
      string MethodName { get; set; }

      //
      object Instance { get; set; }

      string Template { get; set; }

      IScriptParts ScriptParts { get; set; }

   }
}