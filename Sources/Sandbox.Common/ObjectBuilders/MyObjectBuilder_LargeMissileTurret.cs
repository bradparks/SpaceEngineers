﻿using System.Collections.Generic;
using ProtoBuf;
using VRageMath;
using System.Xml.Serialization;


namespace Sandbox.Common.ObjectBuilders
{
    [ProtoContract]
    [MyObjectBuilderDefinition]
    public class MyObjectBuilder_LargeMissileTurret : MyObjectBuilder_ConveyorTurretBase
    {
    }
}
