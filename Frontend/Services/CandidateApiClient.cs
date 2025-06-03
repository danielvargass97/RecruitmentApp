using RecruitmentApp.Application.Commands;
using RecruitmentApp.Application.DTOs;

namespace RecruitmentApp.Frontend.Services
{
    public class CandidateApiClient
    {
        private readonly HttpClient _httpClient;

        public CandidateApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CandidateItemDto>> GetAllCandidatesAsync()
        {
            var response = await _httpClient.GetAsync("api/candidates");
            response.EnsureSuccessStatusCode();

            var candidates = await response.Content.ReadFromJsonAsync<List<CandidateItemDto>>();
            return candidates ?? [];
        }

        public async Task<bool> DeleteCandidateAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/candidates/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<CandidateItemDto?> GetCandidateByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CandidateItemDto>($"api/candidates/{id}");
        }

        public async Task<bool> UpdateCandidateAsync(int id, CandidateItemDto candidate)
        {
            var command = new UpdateCandidateCommand(
                        candidate.Id,
                        candidate.Name,
                        candidate.Surname,
                        candidate.BirthDate,
                        candidate.Email,
                        [.. candidate.CandidateExperiences.Select(e => new CandidateExperienceDto
                        {
                            Company = e.Company,
                            Job = e.Job,
                            Description = e.Description,
                            Salary = e.Salary,
                            BeginDate = e.BeginDate,
                            EndDate = e.EndDate
                        })]
                    );

            var response = await _httpClient.PutAsJsonAsync($"api/candidates/{id}", command);
            return response.IsSuccessStatusCode;
        }
        
        public async Task<bool> CreateCandidateAsync(CandidateItemDto candidate)
        {
            var command = new CreateCandidateCommand(
                candidate.Name,
                candidate.Surname,
                candidate.BirthDate,
                candidate.Email,
                [.. candidate.CandidateExperiences.Select(e => new CandidateExperienceDto
                {
                    Company = e.Company,
                    Job = e.Job,
                    Description = e.Description,
                    Salary = e.Salary,
                    BeginDate = e.BeginDate,
                    EndDate = e.EndDate
                })]
            );

            var response = await _httpClient.PostAsJsonAsync("api/candidates", command);
            return response.IsSuccessStatusCode;
        }

    }
}
