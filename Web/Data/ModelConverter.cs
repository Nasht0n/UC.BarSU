using Web.ViewModels;
using Common.Entities;

namespace Web.Data
{
    public static class Converter
    {
        public static class FeedbackModel
        {
            public static AppFeedback GetFeedback(FeedbackViewModel model)
            {
                return new AppFeedback { Name = model.Name, Email = model.Email, Title = model.Title, Message = model.Message };
            }
        }
    }
}