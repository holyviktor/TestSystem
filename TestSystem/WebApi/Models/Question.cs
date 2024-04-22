namespace TestSystem.WebApi.Models
{
    public class Question
    {
        public string Title { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<Option> Options { get; set; }
    }
}
