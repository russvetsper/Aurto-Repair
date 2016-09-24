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
        List<Mechanic> AllMechanic = Mechanic.GetAll();
        return View["index.cshtml", AllMechanic];
      };

      Get["/mechanic"] = _ => {
            List<Mechanic> AllMechanic = Mechanic.GetAll();
            return View["mechanic.cshtml", AllMechanic];
      };

      Get["/mechanic/new"] = _ => {
        return View["mechanic_form.cshtml"];
      };

      Post["/mechanic/new"] = _ => {
        Mechanic newMechanic = new Mechanic(Request.Form["mechanic-name"]);
        newMechanic.Save();
        return View["mechanic.cshtml"];
      };


    }
  }
}
