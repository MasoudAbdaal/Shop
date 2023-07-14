using System.Collections.ObjectModel;
using Domain;
using Domain.Entities.Address;

namespace Contracts.Constants;

public static class Countries
{
    //TODO: Overwrite This Class with RegionID and ParentID Fields
    public static Region USA = new Region
    {
        Name = "USA",
        SubRegions = new Collection<Region>
  {
    new Region{ Name = "California",

    SubRegions = new Collection<Region> {
      new Region{Name="SUB_STATE"},}
      ,},

    new Region{
      Name="Hawaii",
      SubRegions = new Collection<Region> {
    new Region{ Name = "SU_STATE",

    SubRegions = new Collection<Region> {
      new Region{Name="SU_STATE_2"},}, },
      }
      }


  }

    };
    public static Region IRAN = new Region
    {
        Name = "IRAN",
        SubRegions = new Collection<Region> {
    new Region{
       Name = "TEHRAN",

    SubRegions = new Collection<Region> {
      new Region{
        Name="Karaj"},
    },
    },
    new Region{
      SubRegions = new Collection<Region> {
    new Region{ Name = "MAZANDARAN",
    SubRegions = new Collection<Region> {
      new Region{Name="RaamSar"},
      new Region{Name="Babol"}
    },
    },
      }}
  }
    };

}