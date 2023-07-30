using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity;

public class HashGenerator
{
    private static Random r = new Random();
    private static HMAC? Algorighm { get; set; }

    private string? ClearPassword { get; set; }

    public byte[] HashingSalt { get; private set; }
    public byte[] CreatePassword() => Algorighm!.ComputeHash(Encoding.UTF8.GetBytes(ClearPassword ?? ""));

    public byte[] CreateRandomID(byte[]? Buffer = null)
    {
        Buffer = Buffer ?? new byte[16];
        r.Next();
        r.NextBytes(Buffer);
        return Buffer.CloneByteArray();
    }
    public HashGenerator(string? clearPassword, HMAC hashingAlgorithm)
    {
        ClearPassword = clearPassword;
        Algorighm = hashingAlgorithm;
        HashingSalt = hashingAlgorithm.Key;
    }
}