namespace RecruitmentApp.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public ICollection<CandidateExperience> CandidateExperiences { get; set; } = [];
    }
}