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
        return View["confirm.cshtml"];
      };

      Get["mechanic/edit/{id}"] = parameters => {
        Mechanic SelectedMechanic = Mechanic.Find(parameters.id);
        return View["mechanic_edit.cshtml", SelectedMechanic];
      };

      Patch["mechanic/edit/{id}"] = parameters => {
        Mechanic SelectedMechanic = Mechanic.Find(parameters.id);
        SelectedMechanic.Update(Request.Form["mechanic-name"]);
        return View["confirm.cshtml"];
      };

      Get["mechanic/delete/{id}"] = parameters => {
        Mechanic SelectedMechanic = Mechanic.Find(parameters.id);
        return View["mechanic_delete.cshtml", SelectedMechanic];
      };
      Delete["mechanic/delete/{id}"] = parameters => {
        Mechanic SelectedMechanic = Mechanic.Find(parameters.id);
        SelectedMechanic.Delete();
        return View["confirm.cshtml"];
      };

      Get["/clients"] = _ => {
        List<Clients> AllClients = Clients.GetAll();
        return View["clients.cshtml", AllClients];
      };

      Get["/clients/new"] = _ => {
        List<Mechanic> AllMechanics = Mechanic.GetAll();
        return View["clients_form.cshtml", AllMechanics];
      };
      Post["/clients/new"] = _ => {
        Clients newClients = new Clients(Request.Form["clients-name"], Request.Form["Mechanic-id"]);
        newClients.Save();
        return View["confirm.cshtml"];
      };





    }
  }
}
