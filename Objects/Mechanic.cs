using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AutoRepair.Objects
{
  public class Mechanic
  {
    private string _name;
    private int _id;

    public Mechanic(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public void SetName(string name)
    {
      _name = name;
    }
    public void SetId(int id)
    {
      _id = id;
    }

  }
}
