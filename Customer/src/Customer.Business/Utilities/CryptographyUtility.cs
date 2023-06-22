using Customer.Domain.Interfaces.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace Customer.Business.Utilities;

/// <summary>Cryptography Utility</summary>
public class CryptographyUtility : ICryptographyUtility
{
    /// <summary>Compares the specified text value.</summary>
    /// <param name="textValue">The text value.</param>
    /// <param name="salt">The salt.</param>
    /// <param name="encryptedValue">The encrypted value.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    public bool Compare(string textValue, string salt, string encryptedValue)
    {
        if (textValue == string.Empty || salt == string.Empty || encryptedValue == string.Empty)
        {
            return false;
        }

        string encryptedTextValue = EncryptWithSalt(textValue, salt);

        return encryptedTextValue == encryptedValue;
    }

    /// <summary>Creates the salt.</summary>
    /// <returns>
    ///   <br />
    /// </returns>
    public string CreateSalt()
    {
        var rng = RandomNumberGenerator.Create();
        byte[] buff = new byte[32];
        rng.GetBytes(buff);

        return Convert.ToBase64String(buff);
    }

    /// <summary>Encrypts the specified text value.</summary>
    /// <param name="textValue">The text value.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    public string Encrypt(string textValue)
    {
        if (textValue == string.Empty)
        {
            return string.Empty;
        }

        SHA512 sha512 = SHA512.Create();
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        byte[] textValueAsByte = Encoding.GetEncoding(1254).GetBytes(textValue);
        byte[] hash = sha512.ComputeHash(textValueAsByte);
        sha512.Clear();

        return Convert.ToBase64String(hash);
    }

    /// <summary>Encrypts the with salt.</summary>
    /// <param name="textValue">The text value.</param>
    /// <param name="salt">The salt.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    public string EncryptWithSalt(string textValue, string salt)
    {
        if (textValue == string.Empty || salt == string.Empty)
        {
            return string.Empty;
        }

        SHA512 sha512 = SHA512.Create();
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        byte[] textValueAsByte = Encoding.GetEncoding(1254).GetBytes(string.Concat(textValue,salt));
        byte[] hash = sha512.ComputeHash(textValueAsByte);
        sha512.Clear();

        return Convert.ToBase64String(hash);
    }
}
