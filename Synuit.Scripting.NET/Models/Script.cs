//
//  Synuit.Scripting - Script Engine Plugin Framework
//  Copyright © 2018 Synuit Software.  All Rights Reserved.
//
//  This work contains trade secrets and confidential material of
//  Synuit, and its use or disclosure in whole or in part
//  without the express written permission of Synuit is prohibited.
//
using System.Reflection;

//
namespace Synuit.Scripting.NET.Models
{
   public class Script : Scripting.Models.Script
   {
      public Assembly Assembly { get; set; } = null;
   }
}