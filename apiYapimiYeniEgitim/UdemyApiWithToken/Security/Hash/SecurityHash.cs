namespace UdemyApiWithToken.Security.Hash
{
    public class SecurityHash
    {
    public string HashCreate(string value, string salt)
    {
        var valueBytes = Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation.Pbkdf2(
                                 password: value,
                                 salt: System.Text.Encoding.UTF8.GetBytes(salt),
                                 prf: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA512,
                                 iterationCount: 10000,
                                 numBytesRequested: 256 / 8);
 
        return System.Convert.ToBase64String(valueBytes) + "æ" + salt;
    }
 
    public bool ValidateHash(string value, string salt, string hash)
           => HashCreate(value, salt).Split('æ')[0] == hash;
 
    public string HashCreate()
    {
        byte[] randomBytes = new byte[128 / 8];
        using (var generator = System.Security.Cryptography.RandomNumberGenerator.Create())
        {
            generator.GetBytes(randomBytes);
            return System.Convert.ToBase64String(randomBytes);
        }
    }
    }
}