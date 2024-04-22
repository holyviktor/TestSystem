namespace TestSystem.WebApi.Models
{
    public class AiRequest
    {
        public string Material { get; set; }
        public List<QuestionTypeCount> QuestionTypeCounts { get; set; }
        public string Token { get; set; }
    }
}
