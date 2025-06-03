namespace RecruitmentApp.Application.DTOs
{
    public class CandidateItemDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public List<CandidateExperienceDto> CandidateExperiences { get; set; } = new List<CandidateExperienceDto>();
    }
}