public class UpdateCandidateExperienceDto
{
    public required string Company { get; set; }
    public required string Job { get; set; }
    public required string Description { get; set; }
    public required decimal Salary { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime ModifyDate { get; set; }
}