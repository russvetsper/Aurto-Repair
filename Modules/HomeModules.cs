using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using AutoRepair.Objects;


namespace AutoRepair
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

    }
  }
}
