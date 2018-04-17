
//
using Synuit.Scripting.NET.Roslyn;
using Synuit.Scripting.Types;
using Synuit.Toolkit.Platform.DI;
using Synuit.Toolkit.Types.Platform.DI;

namespace Synuit.Scripting.Testing
{
   /*
   Dependency injection container that is responsible for resolving
   all of the requested dependencies at run time.
   */

   public class Container : AbstractContainer
   {
      private static readonly IContainer Instance = new Container();
      // $!!$private static readonly IObjectStore Repository = new ObjectStore<IDataModel>();

      //protected Container() : base() { /*Setup();*/  }

      // --> Responsible for configuring the container and prepare it to resolve dependency requests
      override protected void Setup()
      {
         RegisterType<IScriptEngine, ScriptEngine>();
         RegisterType<IScript, NET.Script>();
      }
      // --> Get reference to the static container instance
      public static IContainer Get { get { return Instance; } }
      //
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            //////// free managed resources
            //////if (Repository != null)
            //////{
            //////   Repository.Dispose();
            //////   //_unityContainer = null;
            //////}
            base.Dispose(disposing);
         }
      }
   }
}