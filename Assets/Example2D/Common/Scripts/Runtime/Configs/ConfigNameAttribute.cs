using System;

namespace Example2D.Common.Runtime.Configs {
    public class ConfigNameAttribute : Attribute {
        public string Name { get; }
        public ConfigNameAttribute(string name) {
            Name = name;
        }
    }
}