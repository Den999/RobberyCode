using UnityEngine;
using UnityEngine.Rendering;

namespace D2D
{
    public class PostProcessingProfileHub : SwitchableHub<Volume>
    {
        protected override void SwitchMember(Volume member, bool state)
        {
            member.priority = state ? 100 : 0;
        }
    }
}