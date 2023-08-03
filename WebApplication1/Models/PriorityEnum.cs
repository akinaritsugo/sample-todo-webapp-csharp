using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    //public struct Priority
    //{
    //    public const string Low = "低";
    //    public const string Medium = "中";
    //    public const string High = "高";

    //    public static implicit operator string(Priority value)
    //    {
    //        switch (value)
    //        {
    //            case Priority.Low:
    //                return Priority.Low;
    //            case Priority.Medium:
    //                return Priority.Medium;
    //            case Priority.High:
    //                return Priority.High;
    //            default:
    //                return Priority.Low;
    //        }
    //    }

    //    public static implicit operator Priority(string value)
    //    {
    //        switch (value)
    //        {
    //            case "低":
    //                return Priority.Low;
    //            case "中":
    //                return Priority.Medium;
    //            case "高":
    //                return Priority.High;
    //            default:
    //                return Priority.Low;
    //        }
    //    }
    //}

    public enum PriorityEnum
    {
        [Display(Name = "低")]
        Low,

        [Display(Name = "中")]
        Medium,

        [Display(Name = "高")]
        High
    }

    //public static implicit operator PriorityEnum(string value)
    //{
    //    switch (value)
    //    {
    //        case "Low":
    //            return PriorityEnum.Low;
    //        case "Medium":
    //            return PriorityEnum.Medium;
    //        case "High":
    //            return PriorityEnum.High;
    //        default:
    //            return PriorityEnum.Low;
    //    }
    //}
}
