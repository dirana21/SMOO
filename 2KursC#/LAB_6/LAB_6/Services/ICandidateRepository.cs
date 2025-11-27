using System.Collections.Generic;

public interface ICandidateRepository
{
    IEnumerable<Candidate> GetAll();
    void Add(Candidate candidate);
    void Remove(Candidate candidate);
    void Update(Candidate candidate);
}
