using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecruitmentApp.Application.DTOs;
using RecruitmentApp.Frontend.Services;

namespace RecruitmentApp.Pages.Candidates
{
    public class CreateModel : PageModel
    {
        private readonly CandidateApiClient _apiClient;

        public CreateModel(CandidateApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public CandidateItemDto Candidate { get; set; } = new CandidateItemDto
        {
            Name = string.Empty,
            Surname = string.Empty,
            BirthDate = DateTime.Now,
            Email = string.Empty,
            CandidateExperiences = new List<CandidateExperienceDto>()
        };

        public void OnGet()
        {
            if (Candidate.CandidateExperiences == null)
            {
                Candidate.CandidateExperiences = [];
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var success = await _apiClient.CreateCandidateAsync(Candidate);

            if (!success)
            {
                ModelState.AddModelError("", "No se pudo guardar el candidato.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
