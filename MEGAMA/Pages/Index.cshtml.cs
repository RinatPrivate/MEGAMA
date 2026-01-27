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

        // המשתנה שיחזיק את רשימת השאלות להצגה
        public List<Question> QuestionsList { get; set; }

        [BindProperty]
        public string NewQuestionContent { get; set; }

        public void OnGet()
        {
            // טעינת השאלות בעת כניסה לדף
            QuestionsList = _service.GetQuestions();
        }

        public IActionResult OnPost()
        {
            // שליחת שאלה חדשה
            _service.AddQuestion(NewQuestionContent);
            return RedirectToPage(); // רענון הדף כדי לראות את השאלה החדשה
        }
    }
}