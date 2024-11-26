class Reader
{
    string filePath;

    public string[] ReadFile(string filePath)
    {
    
        string[] lines = File.ReadAllLines(filePath);

        return lines;
    }
}