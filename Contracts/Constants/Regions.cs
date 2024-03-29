using Domain.Entities.Address;

namespace Contracts.Constants;

public static class Countries
{

    public static Region USA = new Region("USA")
    {
        RegionID = 1,
        ParentID = null
    };

    public static Region California = new Region("California")
    {
        RegionID = 11,
        ParentID = 1
    };

    public static Region Jefferson = new Region("Jefferson")
    {
        RegionID = 111,
        ParentID = 11
    };

    public static Region Hawaii = new Region("Hawaii")
    {
        RegionID = 12,
        ParentID = 1
    };

    public static Region SubState2 = new Region("SU_STATE")
    {
        RegionID = 121,
        ParentID = 12
    };

    public static Region SubState3 = new Region("SU_STATE_2")
    {
        RegionID = 1211,
        ParentID = 121
    };

    public static Region Iran = new Region("IRAN")
    {
        RegionID = 2,
        ParentID = null
    };

    public static Region Tehran = new Region("TEHRAN")
    {
        RegionID = 21,
        ParentID = 2
    };

    public static Region Karaj = new Region("Karaj")
    {
        RegionID = 211,
        ParentID = 21
    };

    public static Region Mazandaran = new Region("MAZANDARAN")
    {
        RegionID = 22,
        ParentID = 2
    };

    public static Region RaamSar = new Region("RaamSar")
    {
        RegionID = 221,
        ParentID = 22
    };

    public static Region Babol = new Region("Babol")
    {
        RegionID = 222,
        ParentID = 22
    };



    //     public static Region USA = new Region
    //     {
    //         RegionID = 1,
    //         Name = "USA",
    //         ParentID = null,
    //         SubRegions = new Collection<Region>
    //   {
    //     new Region{
    //       RegionID = 2,
    //       Name = "California",
    //       ParentID = 1,

    //       SubRegions = new Collection<Region> {
    //         new Region{
    //           RegionID = 3,
    //           Name="SUB_STATE",
    //           ParentID = 2,
    //         },
    //       },
    //     },

    //     new Region{
    //       RegionID = 4,
    //       Name="Hawaii",
    //       ParentID = 1,

    //       SubRegions = new Collection<Region> {
    //         new Region{
    //           RegionID = 5,
    //           Name = "SU_STATE",
    //           ParentID = 4,

    //           SubRegions = new Collection<Region> {
    //             new Region{
    //               RegionID = 6,
    //               Name="SU_STATE_2",
    //               ParentID = 5,
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
    //         SubRegions = new Collection<Region> {
    //     new Region{
    //        RegionID = 8,
    //        Name = "TEHRAN",
    //        ParentID = 7,
    //        SubRegions = new Collection<Region> {
    //          new Region{
    //            RegionID = 9,
    //            Name="Karaj",
    //            ParentID = 8,
    //          },
    //        },
    //     },
    //     new Region{
    //       RegionID=10,
    //       Name="MAZANDARAN",
    //       ParentID=7,
    //       SubRegions=new Collection<Region>{
    //         new Region{
    //           RegionID=11,
    //           Name="RaamSar",
    //           ParentID=10,
    //         },
    //         new Region{
    //           RegionID=12,
    //           Name="Babol",
    //           ParentID=10,
    //         }
    //       }}}
    //     };

    //     public static Region USA = new Region
    //     {
    //         RegionID = 1,
    //         Name = "USA",
    //         ParentID = null,
    //         SubRegions = new Collection<Region>
    //   {
    //     new Region{
    //       RegionID = 2,
    //       Name = "California",
    //       ParentID = 1,

    //       SubRegions = new Collection<Region> {
    //         new Region{
    //           RegionID = 3,
    //           Name="SUB_STATE",
    //           ParentID = 2
    //         },
    //       },
    //     },

    //     new Region{
    //       RegionID = 4,
    //       Name="Hawaii",
    //       ParentID = 1,

    //       SubRegions = new Collection<Region> {
    //         new Region{
    //           RegionID = 5,
    //           Name = "SU_STATE",
    //           ParentID = 4,

    //           SubRegions = new Collection<Region> {
    //             new Region{
    //               RegionID = 6,
    //               Name="SU_STATE_2",
    //               ParentID = 5
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
    //         SubRegions = new Collection<Region> {
    //     new Region{
    //        RegionID = 8,
    //        Name = "TEHRAN",
    //        ParentID = 7,

    //        SubRegions = new Collection<Region> {
    //          new Region{
    //            RegionID = 9,
    //            Name="Karaj",
    //            ParentID = 8
    //          },
    //        },
    //     },
    //     new Region{
    //       RegionID=10,
    //       Name="MAZANDARAN",
    //       ParentID=7,

    //       SubRegions=new Collection<Region>{
    //         new Region{
    //           RegionID=11,
    //           Name="RaamSar",
    //           ParentID=10
    //         },
    //         new Region{
    //           RegionID=12,
    //           Name="Babol",
    //           ParentID=10
    //         }
    //       }
    //     }
    //   }
};



