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
    #region -- ���� --

    /// <summary>��ʾ��</summary>
    public override String DisplayName
    {
      get { return "Net Rewards Auction Agent Service"; }
    }

    /// <summary>����</summary>
    public override String Description
    {
      get { return "Net Rewards Auction Agent Service"; }
    }

    /// <summary>�߳���</summary>
    public override Int32 ThreadCount
    {
      get { return 2; }
    }

    #endregion

    #region -- ���캯�� --

    /// <summary>ʵ����һ���������</summary>
    public AuctionAgent()
    {
      // һ���ڹ��캯������ָ��������
      ServiceName = "NRAuctionAgentSvc";
    }

    #endregion

    #region -- ���� --

    private EntityList<member> m_virtualMembers = null;
    private Boolean m_canDoWork = false;
    private Object m_lock = new Object();
    private Random m_random = new Random(DateTime.Now.Second);

    /// <summary>���Ĺ��������������̻߳ᶨ�ڵ��ø÷���</summary>
    /// <param name="index">�߳����</param>
    /// <returns>�Ƿ�������ʼ��һ��������ĳЩ�����ܴﵽ�����ɣ��߳̿��Բ����ȴ�</returns>
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
          HmTrace.WriteLine("��ʼ���������Ա��Ϣ");
          m_virtualMembers = member.FindAll(member._.isVirtualMember.Equal(true), null, null, 0, 0);
          m_canDoWork = (m_virtualMembers != null && m_virtualMembers.Count > 0);
          if (m_canDoWork)
          {
            HmTrace.WriteLine("����{0}�������Ա", m_virtualMembers.Count);
          }
          else
          {
            HmTrace.WriteLine("���������Ա��Ϣʧ�ܣ�");
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
                HmTrace.WriteLine("��{0}����Ͷ��Ʒ��Ҫ����", auctionList.Count);
                member virtualMember = new member();
                foreach (var item in auctionList)
                {
                  #region ��Ͷ״̬
                  //��Ͷ����,��ֵ��Ͷ״̬�����㾺Ͷ�ɹ��߾�Ͷ����
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
                        HmTrace.WriteDebug(item.ProductName + "��Ͷ�Ѿ�����");
                      }
                    }
                    catch (Exception ex) { HmTrace.WriteDebug(ex.Message); }
                  }
                  //��Ͷ����,��ֵ��Ͷ״̬�����㾺Ͷ�ɹ��߾�Ͷ����
                  // HmTrace.WriteWarn("EndTime:" + item.EndTime + "BiddingPriceNow:" + item.BiddingPriceNow + "MinPrice:" + item.MinPrice + "AuctionSatus:" + item.AuctionSatus);
                  if (item.StarTime <= DateTime.Now && item.EndTime > DateTime.Now && item.BiddingPriceNow < item.MinPrice && item.AuctionSatus == 1)
                  {
                    try
                    {
                        item.AuctionSatus = 2;
                        item.Save();
                        HmTrace.WriteDebug(item.ProductName + "��Ͷ���ڿ�ʼ");
                    }
                    catch (Exception ex) { HmTrace.WriteDebug(ex.Message); }
                  }
                  #endregion
                  ///���ȡ�����Ա
                  for (; ; )
                  {
                    Int32 idx = m_random.Next(0, m_virtualMembers.Count - 1);
                    virtualMember = m_virtualMembers[idx];
                    if (item.member != null)
                    {
                      ///�˻�Ա�Ƿ����б���
                      if (item.member.nickName != virtualMember.nickName) { break; }
                    }
                    else { break; }
                  }

                  HmTrace.WriteLine("{0}���뾺Ͷ��", virtualMember.nickName);
                  if (item.BiddingPriceNow < item.MinPrice)
                  {
                    HmTrace.WriteLine("��ʼ��Ͷ��");
                    if (item.EndTime < DateTime.Now)
                    {
                      item.EndTime = DateTime.Now.AddSeconds(2);
                    }
                    Double seconds = (Double)DateTimeHelper.DateDiff(DateTime.Now, item.EndTime, DateTimeHelper.BackType.GetSeconds);
                    //HmTrace.WriteLine("Index: {0} Intervals: {1} endtime: {2}", index, Intervals[index], item.end_time);
                    var addtime = m_random.Next(0, 25);
                    if (seconds > Intervals[index] + addtime)
                    {
                      HmTrace.WriteLine("��Ͷ��Ʒ[��ţ�{0} ���ƣ�{1} ��ʼʱ�䣺{2:yyyy-MM-dd HH:mm:ss} ��Ͷ����Сʱ��{3}] ����{4}���Ӳſ��Խ��л����˾�Ͷ��",
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

                      HmTrace.WriteLine("�������Զ�����[��ƷID��{0} ��Ʒ��ţ�{1} ��Ʒ���ƣ�{2} ������ID��{3} �������˺�{4} ���ۣ�{5}]��",
                        item.ID, item.ProductNo, item.ProductName, virtualMember.ID, virtualMember.nickName, historyInfo.BidEyuan);

                      //String setValue = "[bidding_eyuan] = {0}, [bid_count] = {1}, [winning_bidder] = '{2}',[update_date] = #{3}#".FormatWith(
                      //    historyInfo.bid_eyuan, item.bid_count + 1, virtualMember.NickName, DateTime.Now);
                      //String sql = String.Format("UPDATE {0} SET {1} WHERE {2} = '{3}' ", "[db_e_auction]", setValue, "id", item.id.ToString());
                      //HmTrace.WriteSQL(sql);
                      //Database db = DatabaseFactory.CreateDatabase();
                      //DbCommand command = db.GetSqlStringCommand(sql);
                      //Boolean result = (db.ExecuteNonQuery(command) > 0);
                      HmTrace.WriteLine("�Զ��ӳپ�����Ʒ[ID��{0} ��ţ�{1} ���ƣ�{2}]����ʱ��{3}�롣", item.ID, item.ProductNo, item.ProductName, addTimeValue);
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