using System;
using System.Collections.Generic;
using DmFramework.Data;
using DmFramework.Log;
using Jetso.Data;
using DmFramework.Utils.Service;

namespace Jetso.AuctionAgent
{
  /// <summary>
  /// Management Server Windows Service.
  /// </summary>
  public class AuctionAgent : HmTaskService<AuctionAgent>
  {
    #region -- 属性 --

    /// <summary>显示名</summary>
    public override String DisplayName
    {
      get { return "Net Rewards Auction Agent Service"; }
    }

    /// <summary>描述</summary>
    public override String Description
    {
      get { return "Net Rewards Auction Agent Service"; }
    }

    /// <summary>线程数</summary>
    public override Int32 ThreadCount
    {
      get { return 2; }
    }

    #endregion

    #region -- 构造函数 --

    /// <summary>实例化一个代理服务</summary>
    public AuctionAgent()
    {
      // 一般在构造函数里面指定服务名
      ServiceName = "NRAuctionAgentSvc";
    }

    #endregion

    #region -- 核心 --

    private EntityList<member> m_virtualMembers = null;
    private Boolean m_canDoWork = false;
    private Object m_lock = new Object();
    private Random m_random = new Random(DateTime.Now.Second);

    /// <summary>核心工作方法。调度线程会定期调用该方法</summary>
    /// <param name="index">线程序号</param>
    /// <returns>是否立即开始下一步工作。某些任务能达到满负荷，线程可以不做等待</returns>
    public override Boolean Work(Int32 index)
    {
      if (index == 0)
      {
        lock (m_lock)
        {
          if (m_virtualMembers != null)
          {
            var temp = m_virtualMembers;
            m_virtualMembers = null;
            temp.Clear();
            temp = null;
          }
          HmTrace.WriteLine("开始载入虚拟会员信息");
          m_virtualMembers = member.FindAll(member._.isVirtualMember.Equal(true), null, null, 0, 0);
          m_canDoWork = (m_virtualMembers != null && m_virtualMembers.Count > 0);
          if (m_canDoWork)
          {
            HmTrace.WriteLine("载入{0}个虚拟会员", m_virtualMembers.Count);
          }
          else
          {
            HmTrace.WriteLine("载入虚拟会员信息失败！");
          }
        }
      }
      else if (index == 1)
      {
        lock (m_lock)
        {
          if (m_canDoWork)
          {
            var eop = Auction.Meta.Factory;
            eop.BeginTransaction();

            try
            {
              ////foreach (var item in m_virtualMembers)
              //{
              //  HmTrace.WriteLine("ID: {0} NickName: {1} Name: {2} Email: {3} WorkIndex: {4} MemberIndex: {5}",item.id, item.NickName, item.Name, item.Email, index, idx);
              //}

              var auction = new Auction(); ;
              var auctionHistory = new AuctionHistory();
              //var auctionList = auction.Find("(DateDiff('s', Now(),CDate(end_time)) >= 0) or (bidding_eyuan < min_eyuan)");
              var exp = Auction._.AuctionSatus != 3;
              //exp &= Auction._.BiddingPriceNow < Auction._.MinPrice;
              var auctionList = Auction.FindAll(exp, null, null, 0, 0);
              if (auctionList != null && auctionList.Count > 0)
              {
                HmTrace.WriteLine("有{0}个竞投产品需要处理！", auctionList.Count);
                member virtualMember = new member();
                foreach (var item in auctionList)
                {
                  #region 竞投状态
                  //竞投结束,赋值竞投状态，计算竞投成功者竞投次数
                  // HmTrace.WriteWarn("EndTime:" + item.EndTime + "BiddingPriceNow:" + item.BiddingPriceNow + "MinPrice:" + item.MinPrice + "AuctionSatus:" + item.AuctionSatus);
                  if (item.EndTime < DateTime.Now && item.BiddingPriceNow >= item.MinPrice && item.AuctionSatus != 3)
                  {
                    try
                    {
                      var list = AuctionHistory.FindAllByAuctionIDandMemberID(item.ID, item.WinningBidder);
                      if (list != null)
                      {
                        item.WinnerBidCount = list.Count;
                        item.AuctionSatus = 3;
                        item.Save();
                        HmTrace.WriteDebug(item.ProductName + "竞投已经结束");
                      }
                    }
                    catch (Exception ex) { HmTrace.WriteDebug(ex.Message); }
                  }
                  //竞投结束,赋值竞投状态，计算竞投成功者竞投次数
                  // HmTrace.WriteWarn("EndTime:" + item.EndTime + "BiddingPriceNow:" + item.BiddingPriceNow + "MinPrice:" + item.MinPrice + "AuctionSatus:" + item.AuctionSatus);
                  if (item.StarTime <= DateTime.Now && item.EndTime > DateTime.Now && item.BiddingPriceNow < item.MinPrice && item.AuctionSatus == 1)
                  {
                    try
                    {
                        item.AuctionSatus = 2;
                        item.Save();
                        HmTrace.WriteDebug(item.ProductName + "竞投现在开始");
                    }
                    catch (Exception ex) { HmTrace.WriteDebug(ex.Message); }
                  }
                  #endregion
                  ///随机取虚拟会员
                  for (; ; )
                  {
                    Int32 idx = m_random.Next(0, m_virtualMembers.Count - 1);
                    virtualMember = m_virtualMembers[idx];
                    if (item.member != null)
                    {
                      ///此会员是否是中标者
                      if (item.member.nickName != virtualMember.nickName) { break; }
                    }
                    else { break; }
                  }

                  HmTrace.WriteLine("{0}参与竞投！", virtualMember.nickName);
                  if (item.BiddingPriceNow < item.MinPrice)
                  {
                    HmTrace.WriteLine("开始竞投！");
                    if (item.EndTime < DateTime.Now)
                    {
                      item.EndTime = DateTime.Now.AddSeconds(2);
                    }
                    Double seconds = (Double)DateTimeHelper.DateDiff(DateTime.Now, item.EndTime, DateTimeHelper.BackType.GetSeconds);
                    //HmTrace.WriteLine("Index: {0} Intervals: {1} endtime: {2}", index, Intervals[index], item.end_time);
                    var addtime = m_random.Next(0, 25);
                    if (seconds > Intervals[index] + addtime)
                    {
                      HmTrace.WriteLine("竞投商品[编号：{0} 名称：{1} 开始时间：{2:yyyy-MM-dd HH:mm:ss} 竞投限期小时：{3}] 还差{4}秒钟才可以进行机器人竞投！",
                        item.ProductNo, item.ProductName, item.StarTime, 0, seconds);
                    }
                    else
                    {
                      var historyInfo = new AuctionHistory();
                      historyInfo.AuctionID = item.ID;
                      historyInfo.MemberID = virtualMember.ID;
                      historyInfo.BidEyuan = item.BiddingPriceNow + item.EveryAddPrice;
                      historyInfo.BidDate = DateTime.Now;
                      historyInfo.Save();

                      var addTimeInfo = item.TimeAddRange;
                      Int32 addTimeMin;
                      Int32 addTimeMax;
                      Int32 addTimeValue;
                      if (addTimeInfo.Contains("-"))
                      {
                        var timeValues = addTimeInfo.Split('-');
                        Boolean result = Int32.TryParse(timeValues[0], out addTimeMin);
                        if (!result) { addTimeMin = 40; }
                        result = Int32.TryParse(timeValues[1], out addTimeMax);
                        if (!result) { addTimeMax = 70; }
                        addTimeValue = m_random.Next(addTimeMin, addTimeMax);
                      }
                      else
                      {
                        Boolean result = Int32.TryParse(addTimeInfo, out addTimeValue);
                        if (!result)
                        {
                          addTimeValue = 40;
                        }
                      }

                      HmTrace.WriteLine("机器人自动竞价[商品ID：{0} 商品编号：{1} 商品名称：{2} 机器人ID：{3} 机器人账号{4} 竞价：{5}]！",
                        item.ID, item.ProductNo, item.ProductName, virtualMember.ID, virtualMember.nickName, historyInfo.BidEyuan);

                      //String setValue = "[bidding_eyuan] = {0}, [bid_count] = {1}, [winning_bidder] = '{2}',[update_date] = #{3}#".FormatWith(
                      //    historyInfo.bid_eyuan, item.bid_count + 1, virtualMember.NickName, DateTime.Now);
                      //String sql = String.Format("UPDATE {0} SET {1} WHERE {2} = '{3}' ", "[db_e_auction]", setValue, "id", item.id.ToString());
                      //HmTrace.WriteSQL(sql);
                      //Database db = DatabaseFactory.CreateDatabase();
                      //DbCommand command = db.GetSqlStringCommand(sql);
                      //Boolean result = (db.ExecuteNonQuery(command) > 0);
                      HmTrace.WriteLine("自动延迟竞价商品[ID：{0} 编号：{1} 名称：{2}]结束时间{3}秒。", item.ID, item.ProductNo, item.ProductName, addTimeValue);
                      var endTime = item.EndTime;
                      item.EndTime = endTime.AddSeconds((Double)addTimeValue);
                      item.BiddingPriceNow = historyInfo.BidEyuan;
                      item.BidCount += 1;
                      item.WinningBidder = virtualMember.ID;
                      item.UpdateTime = DateTime.Now;
                      item.Update();
                    }
                  }
                }
              }
            }
            catch (Exception ex)
            {
              HmTrace.WriteException(ex);
              eop.Rollback();
            }
            finally
            {
              eop.Commit();
            }
          }
        }
      }
      return false;
    }

    #endregion
  }
}