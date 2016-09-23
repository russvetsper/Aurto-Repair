using System;
using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoRepair;
using AutoRepair.Objects;

namespace AutoRepair
{
  public class MechanicTest
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

  }
}
