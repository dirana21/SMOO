using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class FileCandidateRepository : ICandidateRepository
{
    private readonly string _filePath;
    private readonly List<Candidate> _candidates;

    public FileCandidateRepository(string filePath)
    {
        _filePath = filePath;
        _candidates = LoadFromFile();
    }

    public IEnumerable<Candidate> GetAll()
    {
        return new List<Candidate>(_candidates);
    }

    public void Add(Candidate candidate)
    {
        _candidates.Add(candidate);
        SaveToFile();
    }

    public void Remove(Candidate candidate)
    {
        _candidates.Remove(candidate);
        SaveToFile();
    }

    public void Update(Candidate candidate)
    {
        SaveToFile();
    }

    private List<Candidate> LoadFromFile()
    {
        if (!File.Exists(_filePath))
            return new List<Candidate>();

        try
        {
            var serializer = new XmlSerializer(typeof(List<Candidate>));
            using (var stream = File.OpenRead(_filePath))
            {
                return (List<Candidate>)serializer.Deserialize(stream);
            }
        }
        catch
        {           
            return new List<Candidate>();
        }
    }

    private void SaveToFile()
    {
        var serializer = new XmlSerializer(typeof(List<Candidate>));
        using (var stream = File.Create(_filePath))
        {
            serializer.Serialize(stream, _candidates);
        }
    }
}
