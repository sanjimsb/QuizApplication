using QuizDbContext;
using QuizModels;

namespace QuizMethods;

public static class QuizList
{
    public static readonly QuizContext _db;

    public static IList<Quiz> Quizes;


    public static IList<Quiz> GetAllQuiz()
    {
        Quizes = _db.Quiz!.Select(q => q).ToList();
        return Quizes;
    }

    public static IList<Quiz> GetQuizeByModule(int ModuleId)
    {
        Quizes = _db.Quiz!.Where(q => q.ModuleId == ModuleId).ToList();
        return Quizes;
    }
}

