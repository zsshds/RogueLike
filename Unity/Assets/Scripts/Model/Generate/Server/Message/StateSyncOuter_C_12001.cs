using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(StateSyncOuter.OperateInfo)]
    public partial class OperateInfo : MessageObject
    {
        public static OperateInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(OperateInfo), isFromPool) as OperateInfo;
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        [MemoryPackOrder(0)]
        public int OperateType { get; set; }

        /// <summary>
        /// 输入类型，按下/抬起
        /// </summary>
        [MemoryPackOrder(1)]
        public int InputType { get; set; }

        /// <summary>
        /// v3参数
        /// </summary>
        [MemoryPackOrder(2)]
        public Unity.Mathematics.float3 Vec3 { get; set; }

        [MemoryPackOrder(3)]
        public long Value1 { get; set; }

        [MemoryPackOrder(4)]
        public long Value2 { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.OperateType = default;
            this.InputType = default;
            this.Vec3 = default;
            this.Value1 = default;
            this.Value2 = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static class StateSyncOuter
    {
        public const ushort OperateInfo = 12002;
    }
}