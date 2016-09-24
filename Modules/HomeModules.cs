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
        List<Mechanic> AllMechanics = Mechanic.GetAll();
        return View["index.cshtml", AllMechanics];
      };

      Get["/mechanic"] = _ => {
            List<Mechanic> AllMechanics = Mechanic.GetAll();
            return View["mechanic.cshtml", AllMechanics];
      };

    

    }
  }
}
