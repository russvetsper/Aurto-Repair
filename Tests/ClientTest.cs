using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoRepair;
using AutoRepair.Objects;

namespace AutoRepair
{
  public class ClientTest : IDisposable
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
      public void Test7_CheckEqualsOverride()
      {
        Clients firstClients = new Clients ("Joe");
        Clients secondClients = new Clients ("Joe");
        Assert.Equal(firstClients, secondClients);
      }

      [Fact]
      public void Test8_Save()
      {
      //Arrange
      Clients testClients = new Clients("Russ");

      //Act
      testClients.Save();
      Clients savedClients = Clients.GetAll()[0];

      int result = savedClients.GetId();
      int testId = testClients.GetId();

      //Assert
      Assert.Equal(testId, result);
      }

      [Fact]
       public void Test_DeleteAll_true()
       {
         //Arrange
         Clients newClientsOne = new Clients ("Joe");
         Clients newClientsTwo = new Clients ("Mike");
         newClientsOne.Save();
         newClientsTwo.Save();
         //Act
         Clients.DeleteAll();
         List<Clients> result = Clients.GetAll();
         //Assert
         Assert.Equal(0 , result.Count);
       }



      public void Dispose()
      {
        Clients.DeleteAll();
      }

  }
}
