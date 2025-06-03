using Microsoft.AspNetCore.Mvc.RazorPages;
using RecruitmentApp.Frontend.Services;
using RecruitmentApp.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace RecruitmentApp.Pages.Candidates
{
    public class IndexModel : PageModel
    {
        private readonly CandidateApiClient _apiClient;

        public IndexModel(CandidateApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public List<CandidateItemDto> Candidates { get; set; } = new();

        public async Task OnGetAsync()
        {
            Candidates = await _apiClient.GetAllCandidatesAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            try
            {
                if (id == null)
                {
                    ModelState.AddModelError("", "ID no recibido.");
                    Candidates = await _apiClient.GetAllCandidatesAsync();
                    return Page();
                }

                var deleted = await _apiClient.DeleteCandidateAsync(id.Value);

                if (!deleted)
                {
                    ModelState.AddModelError("", "No se pudo eliminar.");
                }

                Candidates = await _apiClient.GetAllCandidatesAsync();
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al eliminar: {ex.Message}");
                Candidates = await _apiClient.GetAllCandidatesAsync();
                return Page();
            }
        }
    }
}
