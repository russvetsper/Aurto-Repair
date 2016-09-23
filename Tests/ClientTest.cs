using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoRepair;
using AutoRepair.Objects;

namespace AutoRepair
{
  public class ClientTest
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=auto_repair_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test6_DatabaseEmpty_true()
    {
      int table = Clients.GetAll().Count;

      Assert.Equal(0, table);
    }

    [Fact]
      public void Test2_CheckEqualsOverride()
      {
        Clients firstClients = new Clients ("Joe");
        Clients secondClients = new Clients ("Joe");
        Assert.Equal(firstClients, secondClients);
      }

  }
}
