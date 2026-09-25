using System;
using System.Collections.Generic;
using System.Text;

namespace MuleThis
{
    enum MuleTargetType
    {
        AutomaticTarget,
        ManualTarget
    }

    class MuleTarget
    {
        public MuleTargetType Type;
        public int Id;
        public string Name;

        public MuleTarget()
        {
            Type = MuleTargetType.AutomaticTarget;
            Id = 0;
            Name = PluginCore.NOTARGET;
        }

        public MuleTarget(MuleTargetType type)
        {
            Type = type;
            Id = 0;
            Name = PluginCore.NOTARGET;
        }
                
        public MuleTarget(MuleTargetType type, int id, string name)
        {
            Type = type;
            Id = id;
            Name = name;
        }

        public bool Equals(MuleTarget other)
        {
            return other != null && other.Id == Id && Type.Equals(other.Type);
        }
    }
}
