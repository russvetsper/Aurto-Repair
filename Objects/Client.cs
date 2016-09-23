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

    public Clients(string name, int id = 0)
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
        Clients newClients = new Clients(ClientsName, ClientsId);
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
        return (idEquality && nameEquality);
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

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name) OUTPUT INSERTED.id VALUES (@ClientsName);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientsName";
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

    public static Clients Find(int id)
   {
     SqlConnection conn = DB.Connection();
     conn.Open();
     string statement = "SELECT * FROM clients WHERE id = @ClientsId;";
     SqlCommand cmd = new SqlCommand(statement, conn);
     SqlParameter ClientsIdParameter = new SqlParameter();
     ClientsIdParameter.ParameterName = "@ClientsId";
     ClientsIdParameter.Value = id.ToString();
     cmd.Parameters.Add(ClientsIdParameter);
     SqlDataReader rdr = cmd.ExecuteReader();

     int foundClientsId = 0;
     string foundClientsName = null;

     while(rdr.Read() )
     {
       foundClientsId = rdr.GetInt32(0);
       foundClientsName = rdr.GetString(1);
     }
     Clients foundClients = new Clients(foundClientsName, foundClientsId);

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
