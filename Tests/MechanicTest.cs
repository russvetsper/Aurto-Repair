using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoRepair;
using AutoRepair.Objects;

namespace AutoRepair
{
  public class MechanicTest : IDisposable
  {
    public MechanicTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=auto_repair_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test1_DatabaseEmpty_true()
    {
      int table = Mechanic.GetAll().Count;

      Assert.Equal(0, table);
    }

    [Fact]
      public void Test2_CheckEqualsOverride()
      {
        Mechanic firstMechanic = new Mechanic ("Joe");
        Mechanic secondMechanic = new Mechanic ("Joe");
        Assert.Equal(firstMechanic, secondMechanic);
      }

    [Fact]
    public void Test3_Save()
    {
    //Arrange
    Mechanic testMechanic = new Mechanic("Russ");

    //Act
    testMechanic.Save();
    Mechanic savedMechanic = Mechanic.GetAll()[0];

    int result = savedMechanic.GetId();
    int testId = testMechanic.GetId();

    //Assert
    Assert.Equal(testId, result);
    }

     [Fact]
      public void Test4_DeleteAll_true()
      {
        //Arrange
        Mechanic newMechanicOne = new Mechanic ("Joe");
        Mechanic newMechanicTwo = new Mechanic ("Mike");
        newMechanicOne.Save();
        newMechanicTwo.Save();
        //Act
        Mechanic.DeleteAll();
        List<Mechanic> result = Mechanic.GetAll();
        //Assert
        Assert.Equal(0 , result.Count);
      }

      [Fact]
    public void Test5_UpdateMechanic()
    {
      //Arrange
      string name = "Mike";
      Mechanic testMechanic = new Mechanic(name);
      testMechanic.Save();
      string newName = "Joe";

      //Act
      testMechanic.Update(newName);

      string result = testMechanic.GetName();

      //Assert
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test6_Delete()
    {
      Mechanic firstMechanic = new Mechanic("Russ");
      firstMechanic.Save();

      Mechanic secondMechanic = new Mechanic("Rouz");
      secondMechanic.Save();

      firstMechanic.Delete();
      List<Mechanic> allMechanics = Mechanic.GetAll();
      List<Mechanic> afterDeleteFristMechanic = new List<Mechanic> {secondMechanic};

      Assert.Equal(afterDeleteFristMechanic, allMechanics);
    }

    [Fact]
   public void Test7_GetMechanicAndMechanic()
   {
     Mechanic testMechanic = new Mechanic("Russ");
     testMechanic.Save();

     Clients firstClients = new Clients("Joe", testMechanic.GetId());
     firstClients.Save();
     Clients secondClients = new Clients("Rouz", testMechanic.GetId());
     secondClients.Save();


     List<Clients> testClientsList = new List<Clients> {firstClients, secondClients};
     List<Clients> resultClientsList = testMechanic.GetClients();

     Assert.Equal(testClientsList, resultClientsList);
   }



     public void Dispose()
     {
       Mechanic.DeleteAll();
     }

  }
}
