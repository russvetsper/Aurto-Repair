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

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
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
        int MechanicId = rdr.GetInt32(0);
        string MechanicName = rdr.GetString(1);
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
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO mechanics (name) OUTPUT INSERTED.id VALUES (@MechanicName);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@MechanicName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Mechanic Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      string statement = "SELECT * FROM mechanics WHERE id = @MechanicId;";
      SqlCommand cmd = new SqlCommand(statement, conn);
      SqlParameter MechanicIdParameter = new SqlParameter();
      MechanicIdParameter.ParameterName = "@MechanicId";
      MechanicIdParameter.Value = id.ToString();
      cmd.Parameters.Add(MechanicIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundMechanicId = 0;
      string foundMechanicName = null;

      while(rdr.Read() )
      {
        foundMechanicId = rdr.GetInt32(0);
        foundMechanicName = rdr.GetString(1);
      }
      Mechanic foundMechanic = new Mechanic(foundMechanicName, foundMechanicId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundMechanic;
    }


    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE mechanics SET name = @NewName OUTPUT INSERTED.name WHERE id = @MechanicId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);


      SqlParameter MechanicIdParameter = new SqlParameter();
      MechanicIdParameter.ParameterName = "@MechanicId";
      MechanicIdParameter.Value = this.GetId();
      cmd.Parameters.Add(MechanicIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
      }

      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM mechanics;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public List<Clients> GetClients()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE mechanic_id = @MechanicId;", conn);
      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@MechanicId";
      stylistIdParameter.Value = this.GetId();
      cmd.Parameters.Add(stylistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Clients> clients = new List<Clients> {};
      while(rdr.Read())
      {
        int clientsId = rdr.GetInt32(0);
        string clientsName = rdr.GetString(1);
        int clientsMechanicId = rdr.GetInt32(2);
        Clients newClients = new Clients(clientsName, clientsMechanicId, clientsId);
        clients.Add(newClients);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return clients;
    }
  }
}
