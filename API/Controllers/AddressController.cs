using AutoMapper;
using Contracts.DbContexts;
using Contracts.DTOs.Address;
using Domain.Entities.Address;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAddressDbContext _addressDbContext;

    public AddressController(IMapper mapper, IAddressDbContext addressDbContext)
    {
        _mapper = mapper;
        _addressDbContext = addressDbContext;
    }

    [HttpPost, Route("new")]
    public async Task<ActionResult<Address?>> New(AddressCreateDTO request)
    {
        /*
        CODES FROM AUTHController.cs related to Address Model:

        HashGenerator HashGenerator = new HashGenerator(request.Password!, new HMACSHA512(), new byte[0]);
        byte[] AddressID_1 = HashGenerator.CreateRandomID(new byte[4]);
        byte[] AddressID_2 = HashGenerator.CreateRandomID(new byte[4]);

         var userAddress = new Collection<UserAddress> {new UserAddress
        {
            AddressID =AddressID_1,
            UserID = UserID_Random,
            Address = new Address
            {
                ID=AddressID_1,
                AddressLine = "Address1",
                RegionID=Countries.USA.RegionID,
                PostalCode= "1",
                LocationAddress="Location1",
                UnitNumber=0xcc1
            }
        }
     };
        userAddress.Add(new UserAddress
        {
            AddressID = AddressID_2,
            UserID = UserID_Random,
            Address = new Address
            {
                ID = AddressID_2,
                AddressLine = "Address2",
                RegionID = Countries.USA.RegionID,
                PostalCode = "2",
                LocationAddress = "Location2",
                UnitNumber = 0xcc1
            }
        }
                );

        */

        // byte[]? uid = _addressDbContext.GetUserID(request.Mail);
        // uint? RegionID = _addressDbContext.CheckRegionExist(request.RegionName);

        // if (uid is null)
        // return NotFound("User doesn't exist");

        // if (RegionID is null)
        // return NotFound("Region doesn't exist!");

        Random r = new Random();
        byte[] AddressID = new byte[4];
        r.NextBytes(AddressID);

        Address Address = _mapper.Map<AddressCreateDTO, Address>(request);
        Address.ID = AddressID;
        // Address.RegionID = (uint)RegionID;

        // Address? Result = await _addressDbContext.AddAddress(Address, uid);

        // if (Result is not null)
        return Ok();
        // return Ok(_mapper.Map<Address, AddressPresentationDTO>(Result));

        // return StatusCode(504);

    }

    [HttpPost, Route("modify")]
    public async Task<ActionResult<AddressPresentationDTO>> Modify(AddressPresentationDTO request)
    {
        Address? Address = await _addressDbContext.GetAddressByID(request.AddressID);
        if (Address is null)
            return NotFound("Wrong addressID");

        var z = _mapper.Map<AddressPresentationDTO, Address>(request);


        await _addressDbContext.ModifyAddress(z, Address);

        return Ok();
    }

    [HttpGet, Route("all")]
    public async Task<ActionResult<IEnumerable<AddressPresentationDTO>>> GetAll(string email)
    {
        // byte[]? uid = _addressDbContext.GetUserID(email);
        // if (uid is null)
        //     return NotFound();

        // IEnumerable<Address>? addressList = await _addressDbContext.GetUserAddresses(uid!);

        // return Ok(_mapper.Map<IEnumerable<Address>, IEnumerable<AddressPresentationDTO>>(addressList!));
        return Ok(new { });
    }

    [HttpGet, Route("regions")]
    public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
    {
        return Ok(await _addressDbContext.GetRegions());
    }

    [HttpPost, Route("delete")]
    public async Task<ActionResult> Delete(AddressDeleteDTO request)
    {
        Address? Address = await _addressDbContext.GetAddressByID(request.AddressID);
        if (Address is null)
            return NotFound("Invalid AddressID!!");

        if (await _addressDbContext.DeleteAddress(request.AddressID, request.UserID))
            return Ok();

        return StatusCode(StatusCodes.Status502BadGateway);
    }
}