using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AutoRepair.Objects
{
  public class Clients
  {
    private string _name;
    private int _id;
    private int _mechanicId;

    public Clients(string name, int mechanicId, int id = 0)
    {
      _id = id;
      _name = name;
      _mechanicId = mechanicId;

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
    public int GetMechanicId()
     {
       return _mechanicId;
     }
     public void SetMechanicId(int mechanicId)
     {
       _mechanicId = mechanicId;
     }

    public static List<Clients> GetAll()
    {
      List<Clients> allClients = new List<Clients> {};

      SqlConnection conn = DB.Connection();
      conn.Open();

      string statement = "SELECT * FROM clients;";
      SqlCommand cmd = new SqlCommand(statement, conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int ClientsId = rdr.GetInt32(0);
        string ClientsName = rdr.GetString(1);
        int ClientsMechanicId = rdr.GetInt32(2);
        Clients newClients = new Clients(ClientsName, ClientsMechanicId, ClientsId);
        allClients.Add(newClients);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allClients;
    }

    public override bool Equals(System.Object otherClients)
    {
      if (!(otherClients is Clients))
      {
        return false;
      }
      else
      {
        Clients newClients = (Clients) otherClients;
        bool idEquality = (this.GetId() == newClients.GetId());
        bool nameEquality = (this.GetName() == newClients.GetName());
        bool mechanicEquality = this.GetMechanicId() == newClients.GetMechanicId();
        return (idEquality && nameEquality && mechanicEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }


    public void Save()
 {
   SqlConnection conn = DB.Connection();
   conn.Open();

   SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, mechanic_id) OUTPUT INSERTED.id VALUES (@ClientName, @ClientMechanicId);", conn);

   SqlParameter nameParameter = new SqlParameter();
   nameParameter.ParameterName = "@ClientName";
   nameParameter.Value = this.GetName();
   cmd.Parameters.Add(nameParameter);

   SqlParameter mechanicIdParameter = new SqlParameter();
   mechanicIdParameter.ParameterName = "@ClientMechanicId";
   mechanicIdParameter.Value = this.GetMechanicId();
   cmd.Parameters.Add(mechanicIdParameter);


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

    public static Clients Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string statement = "SELECT * FROM clients WHERE id = @ClientsId;";
      SqlCommand cmd = new SqlCommand(statement, conn);
      SqlParameter mechanicIdParameter = new SqlParameter();
      mechanicIdParameter.ParameterName = "@ClientsId";
      mechanicIdParameter.Value = id.ToString();
      cmd.Parameters.Add(mechanicIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundClientsId = 0;
      string foundClientsName = null;
      int foundClientMechanicId = 0;

      while(rdr.Read() )
      {
        foundClientsId = rdr.GetInt32(0);
        foundClientsName = rdr.GetString(1);
        foundClientMechanicId = rdr.GetInt32(2);
      }
      Clients foundClients = new Clients(foundClientsName, foundClientMechanicId, foundClientsId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundClients;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }


  }
}
