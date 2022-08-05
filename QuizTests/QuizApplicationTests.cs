using System.Reflection;
using QuizMethods;
using QuizModels;

namespace QuizTests;

[TestClass]
public class QuizApplicationTests
{
    
    [TestMethod]
    public void QuizListMethodExists()
    {
        MethodInfo info = typeof(QuizList).GetMethod("GetAllQuiz");
        Assert.IsNotNull(info);
    }

    [TestMethod]
    public void ModuleListMethodExists()
    {
        MethodInfo info = typeof(ModuleList).GetMethod("GetAllModules");
        Assert.IsNotNull(info);
    }

    [TestMethod]
    public void GetQuizeByModuleMethodExists()
    {
        MethodInfo info = typeof(QuizList).GetMethod("GetQuizeByModule");
        Assert.IsNotNull(info);
    }

    [TestMethod]
    public void QuizListMethodReturnsListOfQuiz()
    {
        IList<Quiz> quizes = QuizList.GetAllQuiz();
        Assert.IsNotNull(quizes);
    }
}
