class FileUtils
{
    #region VARIABLES
    private const int OFFSET_CHECKSUM = 0x12;
    #endregion

    #region METHODS
    public static ushort GetCheckSum(string fileName)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException("Invalid fileName");
        return GetCheckSum(File.ReadAllBytes(fileName));
    }
    public static ushort GetCheckSum(byte[] fileData)
    {
        if (fileData.Length < OFFSET_CHECKSUM + 1)
            throw new ArgumentException("Invalid fileData");
        return BitConverter.ToUInt16(fileData, OFFSET_CHECKSUM);
    }
    public static void WriteCheckSum(string sourceFile, string destFile, ushort checkSum)
    {
        if (!File.Exists(sourceFile))
            throw new FileNotFoundException("Invalid fileName");
        WriteCheckSum(File.ReadAllBytes(sourceFile), destFile, checkSum);
    }
    public static void WriteCheckSum(byte[] data, string destFile, ushort checkSum)
    {
        byte[] checkSumData = BitConverter.GetBytes(checkSum);
        checkSumData.CopyTo(data, OFFSET_CHECKSUM);
        File.WriteAllBytes(destFile, data);
    }
    #endregion
}


using (var md5 = MD5.Create())
    {
        using (var stream = File.OpenRead(textBox1.Text))
        {
            MessageBox.Show(BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", ""));
        }
    }
    using (var sha256 = SHA256.Create())
    {
        using (var stream = File.OpenRead(textBox1.Text))
        {
            MessageBox.Show(BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", ""));
        }
    }

	
FileUtils.WriteCheckSum(sourceFile, destFile1, 1);
FileUtils.WriteCheckSum(sourceFile, destFile2, 2);