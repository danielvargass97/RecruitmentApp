using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecruitmentApp.Application.DTOs;
using RecruitmentApp.Frontend.Services;

namespace RecruitmentApp.Pages.Candidates
{
    public class EditModel : PageModel
    {
        private readonly CandidateApiClient _apiClient;

        public EditModel(CandidateApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public CandidateItemDto? Candidate { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Candidate = await _apiClient.GetCandidateByIdAsync(id);
            if (Candidate == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Candidate == null)
            {
                ModelState.AddModelError("", "No hay datos del candidato.");
                return Page();
            }

            if (!ModelState.IsValid)
                return Page();

            var updated = await _apiClient.UpdateCandidateAsync(Candidate.Id, Candidate);

            if (!updated)
            {
                ModelState.AddModelError("", "No se pudo actualizar el candidato.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
