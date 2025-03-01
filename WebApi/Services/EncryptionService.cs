using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;

namespace WebApi.Services;

public class EncryptionService
{
    private readonly byte[] _key;

    public EncryptionService(IOptions<EncryptionKey> options)
    {
        _key = SHA256.HashData(Encoding.UTF8.GetBytes(options.Value.Key));
    }

    public string Encrypt(string textData)
    {
        using var aes = Aes.Create();
        aes.Key = _key;

        aes.GenerateIV();

        using var msEncrypt = new MemoryStream();
        msEncrypt.Write(aes.IV, 0, aes.IV.Length);

        using var encryptor = aes.CreateEncryptor();

        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

        byte[] byteText = Encoding.UTF8.GetBytes(textData);
        csEncrypt.Write(byteText, 0, byteText.Length);
        csEncrypt.FlushFinalBlock();

        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decrypt(string cipherTextData)
    {
        byte[] combinedBytes = Encoding.UTF8.GetBytes(cipherTextData);

        if (combinedBytes.Length < 16) throw new ArgumentException("cipher text length invalid");

        using var aes = Aes.Create();
        aes.Key = _key;

        byte[] iv = new byte[16];
        Array.Copy(combinedBytes, 0, iv, 0, 16);
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor();

        using var msDecrypt = new MemoryStream(combinedBytes, 16, combinedBytes.Length - 16);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);

        return srDecrypt.ReadToEnd();
    }

}