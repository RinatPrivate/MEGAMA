using OpenHouseQuestions.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpenHouseQuestions.Services
{
    public class QuestionService
    {
        // רשימה שתשמור את השאלות בזיכרון כל עוד האתר רץ
        private readonly List<Question> _questions = new List<Question>();

        public void AddQuestion(string content)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                _questions.Add(new Question
                {
                    Content = content,
                    SubmittedAt = DateTime.Now
                });
            }
        }

        public List<Question> GetQuestions()
        {
            // מחזיר את השאלות מהחדשה לישנה
            return _questions.OrderByDescending(q => q.SubmittedAt).ToList();
        }
    }
}