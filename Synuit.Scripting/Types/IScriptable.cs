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
   /// <summary>
   /// Interface implemented by objects that are intended to be scriptable.
   /// </summary>
   /// <remarks>Declares members common to all scriptable objects.</remarks>
   public interface IScriptable
   {
      string LoadScript(string name);
   }
}