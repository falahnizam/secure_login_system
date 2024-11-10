using System.Security.Cryptography;
using System;

public sealed class PasswordHash
{
    /// <summary>
    /// salt is added to prevent the rainbow attacks bu adding values to the password
    /// setting up lengthing of hash to 20
    /// hashiter defines the number of iteration userd i the pkbd2 algorthim more the iteration lesser the chance for brute force attack
    /// _Salt and _hash these fields that store the salt and the resukting hash of password
    /// </summary>
    const int SaltSize = 16, HashSize = 20, HashIter = 10000;
    readonly byte[] _salt, _hash;

// Creating a constructor
    public PasswordHash(string password)
    {
        // Genrating a random salt using the method which 16 byte long
        // these ensure uniquness in password even if two user have same password
        new RNGCryptoServiceProvider().GetBytes(_salt = new byte[SaltSize]);
        _hash = new Rfc2898DeriveBytes(password, _salt, HashIter).GetBytes(HashSize);
    }

    // Creating constructor
    public PasswordHash(byte[] hashBytes)
    {
        Array.Copy(hashBytes, 0, _salt = new byte[SaltSize], 0, SaltSize);
        Array.Copy(hashBytes, SaltSize, _hash = new byte[HashSize], 0, HashSize);
    }

    public PasswordHash(byte[] salt, byte[] hash)
    {
        Array.Copy(salt, 0, _salt = new byte[SaltSize], 0, SaltSize);
        Array.Copy(hash, 0, _hash = new byte[HashSize], 0, HashSize);
    }

    // method combine both salt and hash into single byte array
    public byte[] ToArray()
    {
        byte[] hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(_salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(_hash, 0, hashBytes, SaltSize, HashSize);
        return hashBytes;
    }

    public byte[] Salt { get { return (byte[])_salt.Clone(); } }
    public byte[] Hash { get { return (byte[])_hash.Clone(); } }

    // method varifies the passoword enterd b the user
    // takes the password as input and re hashes it using the same salt and same number of iteration check if its resulting matches the stored hashes
    public bool Verify(string password)
    {
        byte[] test = new Rfc2898DeriveBytes(password, _salt, HashIter).GetBytes(HashSize);
        for (int i = 0; i < HashSize; i++)
            if (test[i] != _hash[i])
                return false;
        // if all byte matches the method returns true
        return true;
    }
}
