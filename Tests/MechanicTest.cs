using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoRepair;
using AutoRepair.Objects;

namespace AutoRepair
{
  public class MechanicTest// : IDisposable
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

    //  [Fact]
    //   public void Test4_DeleteAll_true()
    //   {
    //     //Arrange
    //     Mechanic newMechanicOne = new Mechanic ("Joe");
    //     Mechanic newMechanicTwo = new Mechanic ("Mike");
    //     newMechanicOne.Save();
    //     newMechanicTwo.Save();
    //     //Act
    //     Mechanic.DeleteAll();
    //     List<Mechanic> result = Mechanic.GetAll();
    //     //Assert
    //     Assert.Equal(0 , result.Count);
    //   }

    //  public void Dispose()
    //  {
    //    Mechanic.DeleteAll();
    //  }

  }
}
