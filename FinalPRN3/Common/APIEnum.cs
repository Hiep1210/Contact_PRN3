using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FinalPRN3.Common
{
    public enum APIEnum
    {
        [Description("http://localhost:5000/api")]
        BASE_URL,
        [Description("Contacts")]
        CONTACT,
        [Description("Useractivities")]
        ACTIVITY,
        [Description("Users")]
        USER,
        [Description("Orders")]
        ORDER
    }
}
