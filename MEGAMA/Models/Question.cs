using System;

namespace OpenHouseQuestions.Models
{
    public class Question
    {
        public string Content { get; set; } // תוכן השאלה
        public DateTime SubmittedAt { get; set; } // מתי נשאלה
    }
}