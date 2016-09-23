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
        string ClientsName = rdr.GetString(0);
        int ClientsId = rdr.GetInt32(1);
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
  }
}
