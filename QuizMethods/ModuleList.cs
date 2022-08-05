using System;
using QuizDbContext;
using QuizModels;

namespace QuizMethods
{
    public static class ModuleList
    {
        public static readonly QuizContext _db;
        public static IList<Module> Modules { get; set; }

        public static IList<Module>  GetAllModules()
        {
            Modules = _db.Module!.Select(q => q).ToList();
            return Modules;
        }

    }
}

