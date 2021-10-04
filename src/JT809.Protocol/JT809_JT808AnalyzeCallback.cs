using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT809.Protocol
{
   public delegate void JT808AnalyzeCallback(byte[] bytes, Utf8JsonWriter writer,IJT809Config jT809Config);
}
