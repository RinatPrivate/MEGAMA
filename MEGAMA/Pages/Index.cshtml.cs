using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenHouseQuestions.Models;
using OpenHouseQuestions.Services;
using System.Collections.Generic;

namespace OpenHouseQuestions.Pages
{
    public class IndexModel : PageModel
    {
        private readonly QuestionService _service;

        public IndexModel(QuestionService service)
        {
            _service = service;
        }

        public List<Question> QuestionsList { get; set; }

        [BindProperty]
        public string NewQuestionContent { get; set; }

        public void OnGet()
        {
            QuestionsList = _service.GetQuestions();
        }

        public IActionResult OnPost()
        {
            _service.AddQuestion(NewQuestionContent);
            return RedirectToPage();
        }

        public IActionResult OnPostClear(string code)
        {
            if (code == "OPEN2026")
            {
                _service.ClearQuestions();
            }

            return RedirectToPage();
        }
    }
}
