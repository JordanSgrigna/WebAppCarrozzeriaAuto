using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.AspNetCore.
using Microsoft.AspNetCore.Identity;

namespace WebAppCarrozzeriaAuto.Models.ModelsPerViews
{
    public class ModelloAcquisizioneAutoPresente
    {
        public Auto Auto { get; set; }
        public AcquistoAuto AcquistoAuto { get; set; }

    }
}
