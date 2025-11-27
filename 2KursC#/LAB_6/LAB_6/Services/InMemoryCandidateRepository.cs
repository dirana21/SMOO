using System.Collections.Generic;
using System.Linq;

public class InMemoryCandidateRepository : ICandidateRepository
{
    private readonly List<Candidate> _candidates = new List<Candidate>();

    public IEnumerable<Candidate> GetAll()
    {
        return _candidates.ToList();
    }

    public void Add(Candidate candidate)
    {
        _candidates.Add(candidate);
    }

    public void Remove(Candidate candidate)
    {
        _candidates.Remove(candidate);
    }

    public void Update(Candidate candidate)
    {
        
    }
}
