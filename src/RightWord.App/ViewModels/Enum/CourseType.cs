using System.ComponentModel;

namespace RightWord.App.ViewModels
{
    public enum CourseType
    {
        [Description("General English")]
        GeneralEnglish,
        [Description("General English - 25 Weeks Academic Year")]
        GeneralEnglish25Weeks,
        [Description("General English - Online Classes")]
        GeneralEnglishOnline,
        IELTS,
        OTHER
    }
}
