using System;
using System.Collections.Generic;
using System.Data;
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

    public override bool Equals(System.Object otherMechanic)
    {
      if (!(otherMechanic is Mechanic))
      {
        return false;
      }
      else
      {
        Mechanic newMechanic = (Mechanic) otherMechanic;
        bool idEquality = (this.GetId() == newMechanic.GetId());
        bool nameEquality = (this.GetName() == newMechanic.GetName());
        return (idEquality && nameEquality);
      }
    }

    public static List<Mechanic> GetAll()
    {
      List<Mechanic> allMechanic = new List<Mechanic> {};

      SqlConnection conn = DB.Connection();
      conn.Open();

      string statement = "SELECT * FROM mechanics;";
      SqlCommand cmd = new SqlCommand(statement, conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        string MechanicName = rdr.GetString(0);
        int MechanicId = rdr.GetInt32(1);
        Mechanic newMechanic = new Mechanic(MechanicName, MechanicId);
        allMechanic.Add(newMechanic);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allMechanic;
    }
  }
}
