using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Jetso.Data
{
  public enum AuctionStatusEnum : int
  {
    /// <summary>未开始</summary>
    [Description("未开始")]
    NotStarted = 1,

    /// <summary>进行中</summary>
    [Description("进行中")]
    Starting = 2,

    /// <summary>已结束</summary>
    [Description("已结束")]
    TheEnd = 3,
  }
}
