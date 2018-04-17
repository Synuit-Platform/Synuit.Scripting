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
namespace Synuit.Scripting.Types
{
   public interface IScriptParts : IDictionary<string, IScriptPart> { }
   public interface IScriptPart
   {
      string Name { get; set; }
      string Code { get; set; }
   }
}
