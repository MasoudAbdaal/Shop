using System.Collections.ObjectModel;
using Domain;
using Domain.Entities.Address;

namespace Contracts.Constants;

public static class Countries
{

    public static Region USA = new Region
    {
        Name = "USA",
        SubRegion = new Collection<Region>
  {
    new Region{ Name = "California",

    SubRegion = new Collection<Region> {
      new Region{Name="SUB_STATE"},}
      ,},

    new Region{
      Name="Hawaii",
      SubRegion = new Collection<Region> {
    new Region{ Name = "SU_STATE",

    SubRegion = new Collection<Region> {
      new Region{Name="SU_STATE_2"},}, },
      }
      }


  }

    };
    public static Region IRAN = new Region
    {
        Name = "IRAN",
        SubRegion = new Collection<Region> {
    new Region{
       Name = "TEHRAN",

    SubRegion = new Collection<Region> {
      new Region{
        Name="Karaj"},
    },
    },
    new Region{
      SubRegion = new Collection<Region> {
    new Region{ Name = "MAZANDARAN",
    SubRegion = new Collection<Region> {
      new Region{Name="RaamSar"},
      new Region{Name="Babol"}
    },
    },
      }}
  }
    };

}