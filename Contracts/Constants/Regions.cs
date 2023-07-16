using System.Collections.ObjectModel;
using Domain;
using Domain.Entities.Address;

namespace Contracts.Constants;

public static class Countries
{
    //     public static Region USA = new Region
    //     {
    //         RegionID = 1,
    //         Name = "USA",
    //         ParentID = null,
    //         // Parent = null,
    //         SubRegions = new Collection<Region>
    //   {
    //     new Region{
    //       RegionID = 2,
    //       Name = "California",
    //       ParentID = 1,
    //       // Parent = USA,

    //       SubRegions = new Collection<Region> {
    //         new Region{
    //           RegionID = 3,
    //           Name="SUB_STATE",
    //           ParentID = 2,
    //           // Parent = USA.SubRegions!.ElementAt(0)
    //         },
    //       },
    //     },

    //     new Region{
    //       RegionID = 4,
    //       Name="Hawaii",
    //       ParentID = 1,
    //       // Parent = USA,

    //       SubRegions = new Collection<Region> {
    //         new Region{
    //           RegionID = 5,
    //           Name = "SU_STATE",
    //           ParentID = 4,
    //           // Parent = USA!.SubRegions!.ElementAt(1),

    //           SubRegions = new Collection<Region> {
    //             new Region{
    //               RegionID = 6,
    //               Name="SU_STATE_2",
    //               ParentID = 5,
    //               // Parent = USA!.SubRegions!.ElementAt(1).SubRegions!.ElementAt(0)
    //             },
    //           },
    //         },
    //       },
    //     },
    //   },
    //     };
    //     public static Region IRAN = new Region
    //     {
    //         RegionID = 7,
    //         Name = "IRAN",
    //         ParentID = null,
    //         // Parent = null,
    //         SubRegions = new Collection<Region> {
    //     new Region{
    //        RegionID = 8,
    //        Name = "TEHRAN",
    //        ParentID = 7,
    //        // Parent = IRAN,

    //        SubRegions = new Collection<Region> {
    //          new Region{
    //            RegionID = 9,
    //            Name="Karaj",
    //            ParentID = 8,
    //         //    Parent= IRAN.SubRegions.ElementAt(0)
    //          },
    //        },
    //     },
    //     new Region{
    //       RegionID=10,
    //       Name="MAZANDARAN",
    //       ParentID=7,
    //       // Parent=IRAN,

    //       SubRegions=new Collection<Region>{
    //         new Region{
    //           RegionID=11,
    //           Name="RaamSar",
    //           ParentID=10,
    //         //   Parent=IRAN.SubRegions!.ElementAt(1)
    //         },
    //         new Region{
    //           RegionID=12,
    //           Name="Babol",
    //           ParentID=10,
    //         //   Parent=IRAN.SubRegions!.ElementAt(1)
    //         }
    //       }}}
    //     };
    public static Region USA = new Region
    {
        RegionID = 1,
        Name = "USA",
        ParentID = null,
        SubRegions = new Collection<Region>
  {
    new Region{
      RegionID = 2,
      Name = "California",
      ParentID = 1,

      SubRegions = new Collection<Region> {
        new Region{
          RegionID = 3,
          Name="SUB_STATE",
          ParentID = 2
        },
      },
    },

    new Region{
      RegionID = 4,
      Name="Hawaii",
      ParentID = 1,

      SubRegions = new Collection<Region> {
        new Region{
          RegionID = 5,
          Name = "SU_STATE",
          ParentID = 4,

          SubRegions = new Collection<Region> {
            new Region{
              RegionID = 6,
              Name="SU_STATE_2",
              ParentID = 5
            },
          },
        },
      },
    },
  },
    };
    public static Region IRAN = new Region
    {
        RegionID = 7,
        Name = "IRAN",
        ParentID = null,
        SubRegions = new Collection<Region> {
    new Region{
       RegionID = 8,
       Name = "TEHRAN",
       ParentID = 7,

       SubRegions = new Collection<Region> {
         new Region{
           RegionID = 9,
           Name="Karaj",
           ParentID = 8
         },
       },
    },
    new Region{
      RegionID=10,
      Name="MAZANDARAN",
      ParentID=7,

      SubRegions=new Collection<Region>{
        new Region{
          RegionID=11,
          Name="RaamSar",
          ParentID=10
        },
        new Region{
          RegionID=12,
          Name="Babol",
          ParentID=10
        }
      }
    }
  }
    };
}


