using System.ComponentModel;

namespace DevbridgeSquares.Core.Enums
{
    public enum PointAddingState
    {
        [Description("point successfully added to the list")] Added,
        [Description("this point already exists")] Duplicate,
        [Description("coordinates out of range")] OutOfRange,
        [Description("point list is full")] OutOfSpace,
    }
}
