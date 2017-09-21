using System.ComponentModel.DataAnnotations;
using Globalization_CustomWebHelper.Resource;

namespace Globalization_CustomWebHelper.Models.WebHelperSampleEnums
{
    public enum WebHelperSampleEnum
    {
        [Display(ResourceType = typeof(Resources), Description = "ComboAdvert")]
        Advert = 1,
        [Display(ResourceType = typeof(Resources), Description = "ComboWordOfMouth")]
        WordOfMouth = 2,
        [Display(ResourceType = typeof(Resources), Description = "ComboOther")]
        Other = 3
    }
}


