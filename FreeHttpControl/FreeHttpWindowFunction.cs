using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FreeHttp.HttpHelper;
using FreeHttp.FiddlerHelper;
using FreeHttp.MyHelper;

/*******************************************************************************
* Copyright (c) 2018 lulianqi
* All rights reserved.
* 
* 文件名称: 
* 内容摘要: mycllq@hotmail.com
* 
* 历史记录:
* 日	  期:   20181103           创建人: lulianqi [mycllq@hotmail.com]
* 描    述: 创建
*
* 历史记录:
* 日	  期:                      修改:  
* 描    述: 
*******************************************************************************/

namespace FreeHttp.FreeHttpControl
{
    public partial class FreeHttpWindow : UserControl
    {
        #region Inner Function
        /// <summary>
        /// load history rule list
        /// </summary>
        /// <param name="yourRuleCollecttion">RuleCollecttion</param>
        private void LoadFiddlerModificHttpRuleCollection(FiddlerModificHttpRuleCollection yourRuleCollecttion)
        {
            if (yourRuleCollecttion != null)
            {
                if (yourRuleCollecttion.RequestRuleList != null)
                {
                    foreach (var tempRule in yourRuleCollecttion.RequestRuleList)
                    {
                        //tempRule.HttpFilter = new FiddlerHttpFilter(tempRule.UriMatch);
                        AddRuleToListView(lv_requestRuleList, tempRule, false);
                    }
                }
                if (yourRuleCollecttion.ResponseRuleList != null)
                {
                    foreach (var tempRule in yourRuleCollecttion.ResponseRuleList)
                    {
                        //tempRule.HttpFilter = new FiddlerHttpFilter(tempRule.UriMatch);
                        AddRuleToListView(lv_responseRuleList, tempRule, false);
                    }
                }
            }
        }

        private void AddRuleToListView(ListView yourListViews, IFiddlerHttpTamper yourHttpTamper, bool isMark)
        {
            ListViewItem nowRuleItem = new ListViewItem(new string[] { (yourListViews.Items.Count + 1).ToString(), GetFiddlerHttpFilterName(yourHttpTamper.HttpFilter) }, yourHttpTamper.IsRawReplace ? 1 : 0);
            nowRuleItem.Tag = yourHttpTamper;
            nowRuleItem.ToolTipText = yourHttpTamper.HttpFilter.ToString();
            nowRuleItem.Checked = yourHttpTamper.IsEnable;
            yourListViews.Items.Add(nowRuleItem);
            if (isMark)
            {
                MarkRuleItem(nowRuleItem);
                PutWarn(string.Format("Add {0} {1}", yourListViews.Columns[1].Text, nowRuleItem.SubItems[0].Text));
            }
            AdjustRuleListViewIndex(yourListViews);

        }

        private void UpdataRuleToListView(ListViewItem yourListViewItem, IFiddlerHttpTamper yourHttpTamper, bool isMark)
        {
            yourListViewItem.Tag = yourHttpTamper;
            yourListViewItem.SubItems[1].Text = GetFiddlerHttpFilterName(yourHttpTamper.HttpFilter);
            yourListViewItem.ImageIndex = yourHttpTamper.IsRawReplace ? 1 : 0;
            yourListViewItem.ToolTipText = yourHttpTamper.HttpFilter.ToString();
            yourListViewItem.Checked = yourHttpTamper.IsEnable;
            if (isMark)
            {
                MarkRuleItem(yourListViewItem);
                PutWarn(string.Format("Updata {0} {1}", yourListViewItem.ListView.Columns[1].Text, yourListViewItem.SubItems[0].Text));
            }
        }

        private void SyncEnableSateToIFiddlerHttpTamper(ListViewItem yourListViewItem, IFiddlerHttpTamper yourHttpTamper)
        {
            if (yourListViewItem != null && yourHttpTamper != null)
            {
                yourHttpTamper.IsEnable = yourListViewItem.Checked;
            }
        }

        private bool IsRequestReplaceRawMode
        {
            get { return !panel_requestReplace_startLine.Visible; }
        }

        private void ChangeEditRuleMode(RuleEditMode editMode, string mes, ListViewItem yourListViewItem)
        {
            ChangeEditRuleMode(editMode, mes, yourListViewItem, false);
        }
        private void ChangeEditRuleMode(RuleEditMode editMode, string mes, ListViewItem yourListViewItem, bool isSilentChange)
        {
            switch (editMode)
            {
                case RuleEditMode.NewRuleMode:  // new rule
                    lb_editRuleMode.Text = (mes == null ? "New Mode" : mes);
                    pictureBox_editRuleMode.Image = FreeHttp.Resources.MyResource.add_mode;
                    this.toolTip_forMainWindow.SetToolTip(this.pictureBox_editRuleMode, "new a rule");
                    if (EditListViewItem != null && !isSilentChange)
                    {
                        MarkRuleOutEdit(EditListViewItem);
                    }
                    EditListViewItem = null;
                    pictureBox_editHttpFilter.Tag = null;
                    pictureBox_editHttpFilter.Image = Resources.MyResource.filter_off;
                    break;
                case RuleEditMode.EditRequsetRule:  //edit request
                    lb_editRuleMode.Text = (mes == null ? "Edit Mode" : mes);
                    if (EditListViewItem != null && !isSilentChange)
                    {
                        MarkRuleOutEdit(EditListViewItem);
                    }
                    EditListViewItem = yourListViewItem;
                    if (!isSilentChange)
                    {
                        MarkRuleInEdit(EditListViewItem);
                    }
                    pictureBox_editRuleMode.Image = FreeHttp.Resources.MyResource.edit_mode;
                    this.toolTip_forMainWindow.SetToolTip(this.pictureBox_editRuleMode, "save change for your requst rule");
                    break;
                case RuleEditMode.EditResponseRule:  //edit response
                    lb_editRuleMode.Text = (mes == null ? "Edit Mode" : mes);
                    if (EditListViewItem != null && !isSilentChange)
                    {
                        MarkRuleOutEdit(EditListViewItem);
                    }
                    EditListViewItem = yourListViewItem;
                    if(!isSilentChange)
                    {
                        MarkRuleInEdit(EditListViewItem);
                    }
                    pictureBox_editRuleMode.Image = FreeHttp.Resources.MyResource.edit_mode;
                    this.toolTip_forMainWindow.SetToolTip(this.pictureBox_editRuleMode, "save change for your response rule");
                    break;
                default:
                    throw new Exception("get not support mode");
                //break;
            }
            ClearModificInfo();
            NowEditMode = editMode;
        }

        #region MarkControl
        private static void MarkControl(Control yourControl, Color yourColor, int yourShowTick)
        {
            markControlService.MarkControl(yourControl, yourColor, yourShowTick);
        }

        private static void MarkRuleItem(ListViewItem yourItem, Color yourColor, int yourShowTick)
        {
            markControlService.MarkControl(yourItem, yourColor, yourShowTick);
        }

        public static void MarkRuleItem(ListViewItem yourItem)
        {
            MarkRuleItem(yourItem, Color.PowderBlue, 5);
        }

        public static void MarkMatchRule(ListViewItem yourItem)
        {
            MarkRuleItem(yourItem, Color.Khaki, 3);
        }

        public static void MarkWarnControl(Control yourControl)
        {
            MarkControl(yourControl, Color.Plum, 2);
        }


        private void MarkRuleInEdit(ListViewItem yourItem)
        {
            markControlService.SetColor(yourItem, Color.Pink);
            markControlService.MarkControl(lb_editRuleMode, Color.Pink, 2);
        }

        private void MarkRuleOutEdit(ListViewItem yourItem)
        {
            markControlService.SetColor(yourItem, Color.Transparent);
        } 
        #endregion

        private FiddlerUriMatch GetUriMatch()
        {
            FiddlerUriMatchMode matchMode = FiddlerUriMatchMode.AllPass;
            if (!Enum.TryParse<FiddlerUriMatchMode>(cb_macthMode.Text, out matchMode))
            {
                throw new Exception("get error FiddlerUriMatchMode");
            }
            if (matchMode != FiddlerUriMatchMode.AllPass && tb_urlFilter.Text == "")
            {
                return null;
            }
            return new FiddlerUriMatch(matchMode, tb_urlFilter.Text);
        }

        private FiddlerHttpFilter GetHttpFilter()
        {
            if(pictureBox_editHttpFilter.Tag==null)
            {
                return new FiddlerHttpFilter(GetUriMatch());
            }
            else
            {
                FiddlerHttpFilter returnFiddlerHttpFilter = pictureBox_editHttpFilter.Tag as FiddlerHttpFilter;
                if(returnFiddlerHttpFilter==null)
                {
                    throw new Exception("get error in FiddlerHttpFilter");
                }
                returnFiddlerHttpFilter.UriMatch = GetUriMatch();
                return returnFiddlerHttpFilter;
            }
        }

        private int GetResponseLatency()
        {
            return lbl_ResponseLatency.GetLatency();
        }

        private string GetFiddlerHttpFilterName(FiddlerHttpFilter fiddlerHttpFilter)
        {
            if (fiddlerHttpFilter != null)
            {
                if(!String.IsNullOrEmpty(fiddlerHttpFilter.Name))
                {
                    return fiddlerHttpFilter.Name;
                }
                if(fiddlerHttpFilter.UriMatch!=null)
                {
                    return string.Format("【{0}】: {1}", fiddlerHttpFilter.UriMatch.MatchMode.ToString(), fiddlerHttpFilter.UriMatch.MatchUri);
                }
            }
            return "";
        }

        private void SetUriMatch(FiddlerUriMatch fiddlerUriMatch)
        {
            if (fiddlerUriMatch != null)
            {
                cb_macthMode.Text = fiddlerUriMatch.MatchMode.ToString();
                tb_urlFilter.Text = string.IsNullOrEmpty(fiddlerUriMatch.MatchUri) ? "" : fiddlerUriMatch.MatchUri;
            }
        }

        private void SetHttpMatch(FiddlerHttpFilter fiddlerHttpFilter)
        {
            if (fiddlerHttpFilter != null)
            {
                SetUriMatch(fiddlerHttpFilter.UriMatch);
                pictureBox_editHttpFilter.Tag = fiddlerHttpFilter;
                if(fiddlerHttpFilter.HeadMatch!=null || fiddlerHttpFilter.BodyMatch!=null)
                {
                    pictureBox_editHttpFilter.Image = Resources.MyResource.filter_on;
                }
                else
                {
                    pictureBox_editHttpFilter.Image = Resources.MyResource.filter_off;
                }
            }
        }

        private void ChangeSetResponseLatencyMode(int yourLatency)
        {
            if (yourLatency < 0)
            {
                lbl_ResponseLatency.Text = "";
                lbl_ResponseLatency.Visible = false;
                pb_responseLatency.Image = Resources.MyResource.naozhong_off;
                pb_responseLatency.Visible = true;
                isSetResponseLatencyEable = false;
            }
            else if (yourLatency == 0)
            {
                lbl_ResponseLatency.Text = "";
                lbl_ResponseLatency.Visible = false;
                pb_responseLatency.Image = Resources.MyResource.naozhong_on;
                pb_responseLatency.Visible = true;
                isSetResponseLatencyEable = true;
            }
            else
            {
                lbl_ResponseLatency.SetLatency(yourLatency);
                if (lbl_ResponseLatency.Width <= pb_responseLatency.Width)
                {
                    lbl_ResponseLatency.Location = new Point(pb_responseLatency.Location.X, lbl_ResponseLatency.Location.Y);
                }
                else
                {
                    lbl_ResponseLatency.Location = new Point(pb_responseLatency.Location.X - (lbl_ResponseLatency.Width - pb_responseLatency.Width), lbl_ResponseLatency.Location.Y);
                }
                lbl_ResponseLatency.Visible = true;
                pb_responseLatency.Visible = false;
                isSetResponseLatencyEable = true;
            }
        }

        private void SetResponseLatency(int yourLatency)
        {
            ChangeSetResponseLatencyMode(yourLatency);
        }
        private FiddlerRequsetChange GetRequestModificInfo()
        {
            FiddlerRequsetChange requsetChange = new FiddlerRequsetChange();
            requsetChange.HttpRawRequest = null;
            requsetChange.HttpFilter = GetHttpFilter();
            requsetChange.UriModific = new ContentModific(tb_requestModific_uriModificKey.Text, tb_requestModific_uriModificValue.Text);
            if (requestRemoveHeads.ListDataView.Items.Count > 0)
            {
                requsetChange.HeadDelList = new List<string>();
                foreach (ListViewItem tempRequestRemoveHead in requestRemoveHeads.ListDataView.Items)
                {
                    requsetChange.HeadDelList.Add(tempRequestRemoveHead.Text);
                }
            }
            if (requestAddHeads.ListDataView.Items.Count > 0)
            {
                requsetChange.HeadAddList = new List<string>();
                foreach (ListViewItem tempRequestAddHead in requestAddHeads.ListDataView.Items)
                {
                    requsetChange.HeadAddList.Add(tempRequestAddHead.Text);
                }
            }
            requsetChange.BodyModific = new ContentModific(tb_requestModific_body.Text, rtb_requestModific_body.Text);
            return requsetChange;
        }

        private FiddlerRequsetChange GetRequestReplaceInfo()
        {
            FiddlerRequsetChange requsetReplace = new FiddlerRequsetChange();
            requsetReplace.HttpFilter = GetHttpFilter();
            if (IsRequestReplaceRawMode)
            {
                requsetReplace.HttpRawRequest = HttpRequest.GetHttpRequest(rtb_requestRaw.Text.Replace("\n", "\r\n"));
            }
            else
            {
                requsetReplace.HttpRawRequest = new HttpRequest();
                requsetReplace.HttpRawRequest.RequestMethod = cb_editRequestMethod.Text;
                requsetReplace.HttpRawRequest.RequestUri = tb_requestReplace_uri.Text;
                requsetReplace.HttpRawRequest.RequestVersions = cb_editRequestEdition.Text;
                requsetReplace.HttpRawRequest.RequestLine = string.Format("{0} {1} {2}", cb_editRequestMethod.Text, tb_requestReplace_uri.Text, cb_editRequestEdition.Text);

                requsetReplace.HttpRawRequest.RequestHeads = new List<MyKeyValuePair<string, string>>();
                if (elv_requsetReplace.ListDataView.Items.Count > 0)
                {
                    foreach (ListViewItem item in elv_requsetReplace.ListDataView.Items)
                    {
                        string headStr = item.Text;
                        if (headStr.Contains(": "))
                        {
                            string key = headStr.Remove(headStr.IndexOf(": "));
                            string value = headStr.Substring(headStr.IndexOf(": ") + 2);
                            requsetReplace.HttpRawRequest.RequestHeads.Add(new MyKeyValuePair<string, string>(key, value));
                        }
                        else
                        {
                            throw new Exception(string.Format("find eror head with {0}", headStr));
                        }
                    }
                }

                string tempRequstBody = rtb_requsetReplace_body.Text;
                if (tempRequstBody.StartsWith("\n<<replace file path>>"))
                {
                    string tempPath = tempRequstBody.Remove(0, 22);
                    if (File.Exists(tempPath))
                    {
                        using (FileStream fileStream = new FileStream(tempPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            if (fileStream.Length > int.MaxValue)
                            {
                                throw new Exception(string.Format("your file path in  ResponseEntity is too  large with {0}", tempPath));
                            }
                            requsetReplace.HttpRawRequest.RequestEntity = new byte[fileStream.Length];
                            fileStream.Position = 0;
                            fileStream.Read(requsetReplace.HttpRawRequest.RequestEntity, 0, requsetReplace.HttpRawRequest.RequestEntity.Length);
                        }

                    }
                    else
                    {
                        throw new Exception(string.Format("your file path in  ResponseEntity is not Exists with {0}", tempPath));
                    }
                }
                else
                {
                    requsetReplace.HttpRawRequest.RequestEntity = Encoding.UTF8.GetBytes(tempRequstBody);
                }
            }

            if (antoContentLengthToolStripMenuItem.Checked)
            {
                requsetReplace.HttpRawRequest.SetAutoContentLength();
            }
            return requsetReplace;
        }

        private FiddlerResponseChange GetResponseModificInfo()
        {
            FiddlerResponseChange responseChange = new FiddlerResponseChange();
            responseChange.HttpRawResponse = null;
            responseChange.HttpFilter = GetHttpFilter();
            responseChange.LesponseLatency = GetResponseLatency();
            if (responseRemoveHeads.ListDataView.Items.Count > 0)
            {
                responseChange.HeadDelList = new List<string>();
                foreach (ListViewItem tempRequestRemoveHead in responseRemoveHeads.ListDataView.Items)
                {
                    responseChange.HeadDelList.Add(tempRequestRemoveHead.Text);
                }
            }
            if (responseAddHeads.ListDataView.Items.Count > 0)
            {
                responseChange.HeadAddList = new List<string>();
                foreach (ListViewItem tempRequestAddHead in responseAddHeads.ListDataView.Items)
                {
                    responseChange.HeadAddList.Add(tempRequestAddHead.Text);
                }
            }
            responseChange.BodyModific = new ContentModific(tb_responseModific_body.Text, rtb_respenseModific_body.Text);
            return responseChange;
        }

        private FiddlerResponseChange GetResponseReplaceInfo()
        {
            FiddlerResponseChange responseChange = new FiddlerResponseChange();
            responseChange.HttpFilter = GetHttpFilter();
            responseChange.LesponseLatency = GetResponseLatency();
            responseChange.HttpRawResponse = rawResponseEdit.GetHttpResponse(StaticDataCollection);
            responseChange.IsIsDirectRespons = rawResponseEdit.IsDirectRespons;
            return responseChange;
        }

        private void ClearModificInfo()
        {
            cb_macthMode.Text = "";
            tb_urlFilter.Text = "";
            tb_requestModific_uriModificKey.Text = "";
            tb_requestModific_uriModificValue.Text = "";
            tb_requestModific_body.Text = "";
            cb_editRequestMethod.Text = "";
            tb_requestReplace_uri.Text = "";
            cb_editRequestEdition.Text = "";
            tb_responseModific_body.Text = "";
            rawResponseEdit.ClearInfo();
            requestRemoveHeads.ListDataView.Items.Clear();
            requestAddHeads.ListDataView.Items.Clear();
            elv_requsetReplace.ListDataView.Items.Clear();
            responseRemoveHeads.ListDataView.Items.Clear();
            responseAddHeads.ListDataView.Items.Clear();
            rtb_requestModific_body.Clear();
            rtb_requsetReplace_body.Clear();
            rtb_respenseModific_body.Clear();
            rtb_requestRaw.Clear();
            tabControl_Modific_Selecting(this.tabControl_Modific, null);
        }

        private void SetRequestModificInfo(FiddlerRequsetChange fiddlerRequsetChange)
        {
            SetHttpMatch(fiddlerRequsetChange.HttpFilter);
            if (fiddlerRequsetChange.HttpRawRequest == null)
            {
                tabControl_Modific.SelectedIndex = 0;
                if (fiddlerRequsetChange.UriModific != null && fiddlerRequsetChange.UriModific.ModificMode != ContentModificMode.NoChange)
                {
                    tb_requestModific_uriModificKey.Text = fiddlerRequsetChange.UriModific.TargetKey;
                    tb_requestModific_uriModificValue.Text = fiddlerRequsetChange.UriModific.ReplaceContent;
                }
                if (fiddlerRequsetChange.HeadDelList != null)
                {
                    foreach (string tempHead in fiddlerRequsetChange.HeadDelList)
                    {
                        requestRemoveHeads.ListDataView.Items.Add(tempHead);
                    }
                }
                if (fiddlerRequsetChange.HeadAddList != null)
                {
                    foreach (string tempHead in fiddlerRequsetChange.HeadAddList)
                    {
                        requestAddHeads.ListDataView.Items.Add(tempHead);
                    }
                }
                if (fiddlerRequsetChange.BodyModific != null && fiddlerRequsetChange.BodyModific.ModificMode != ContentModificMode.NoChange)
                {
                    tb_requestModific_body.Text = fiddlerRequsetChange.BodyModific.TargetKey;
                    rtb_requestModific_body.AppendText(fiddlerRequsetChange.BodyModific.ReplaceContent);
                }
            }
            else
            {
                tabControl_Modific.SelectedIndex = 1;
                if (IsRequestReplaceRawMode)
                {
                    pb_requestReplace_changeMode_Click(null, null);
                }
                cb_editRequestMethod.Text = fiddlerRequsetChange.HttpRawRequest.RequestMethod;
                tb_requestReplace_uri.Text = fiddlerRequsetChange.HttpRawRequest.RequestUri;
                cb_editRequestEdition.Text = fiddlerRequsetChange.HttpRawRequest.RequestVersions;
                if (fiddlerRequsetChange.HttpRawRequest.RequestHeads != null)
                {
                    foreach (MyKeyValuePair<string, string> tempHead in fiddlerRequsetChange.HttpRawRequest.RequestHeads)
                    {
                        elv_requsetReplace.ListDataView.Items.Add(string.Format("{0}: {1}", tempHead.Key, tempHead.Value));
                    }
                }
                if (fiddlerRequsetChange.HttpRawRequest.RequestEntity != null)
                {
                    rtb_requsetReplace_body.AppendText(Encoding.UTF8.GetString(fiddlerRequsetChange.HttpRawRequest.RequestEntity));
                }
                if (fiddlerRequsetChange.HttpRawRequest.OriginSting != null)
                {
                    rtb_requestRaw.AppendText(fiddlerRequsetChange.HttpRawRequest.OriginSting);
                }

            }
            ChangeSetResponseLatencyMode(-1);
        }

        private void SetResponseModificInfo(FiddlerResponseChange fiddlerResponseChange)
        {
            SetHttpMatch(fiddlerResponseChange.HttpFilter);
            SetResponseLatency(fiddlerResponseChange.LesponseLatency);
            if (fiddlerResponseChange.HttpRawResponse == null)
            {
                tabControl_Modific.SelectedIndex = 2;
                if (fiddlerResponseChange.HeadDelList != null)
                {
                    foreach (string tempHead in fiddlerResponseChange.HeadDelList)
                    {
                        responseRemoveHeads.ListDataView.Items.Add(tempHead);
                    }
                }
                if (fiddlerResponseChange.HeadAddList != null)
                {
                    foreach (string tempHead in fiddlerResponseChange.HeadAddList)
                    {
                        responseAddHeads.ListDataView.Items.Add(tempHead);
                    }
                }
                if (fiddlerResponseChange.BodyModific != null && fiddlerResponseChange.BodyModific.ModificMode != ContentModificMode.NoChange)
                {
                    tb_responseModific_body.Text = fiddlerResponseChange.BodyModific.TargetKey;
                    rtb_respenseModific_body.AppendText(fiddlerResponseChange.BodyModific.ReplaceContent);
                }
            }
            else
            {
                tabControl_Modific.SelectedIndex = 3;
                rawResponseEdit.IsDirectRespons = fiddlerResponseChange.IsIsDirectRespons;
                if (fiddlerResponseChange.HttpRawResponse.OriginSting != null)
                {
                    rawResponseEdit.SetText(fiddlerResponseChange.HttpRawResponse.OriginSting);
                }
            }
        }
        private void AdjustRuleListViewIndex(ListView ruleListView)
        {
            if (ruleListView.Items.Count > 0)
            {
                for (int i = 0; i < ruleListView.Items.Count; i++)
                {
                    ruleListView.Items[i].SubItems[0].Text = (i + 1).ToString();
                }
            }
        }

        #endregion

        #region Public Function

        public void CloseEditRtb()
        {
            tbe_RequestBodyModific.CloseRichTextBox();
            tbe_ResponseBodyModific.CloseRichTextBox();
            tbe_urlFilter.CloseRichTextBox();
            tbe_RequestBodyModific.Visible = tb_requestModific_body.Focused;
            tbe_ResponseBodyModific.Visible = tb_responseModific_body.Focused;
            tbe_urlFilter.Visible = tb_urlFilter.Focused;
        }
        public void SetModificSession(Fiddler.Session session)
        {
            ChangeEditRuleMode(RuleEditMode.NewRuleMode, null, null);
            tb_urlFilter.Text = session.fullUrl;
            cb_macthMode.SelectedIndex = 2;

            pictureBox_editHttpFilter.Tag = GetHttpFilter();
            if (tabControl_Modific.SelectedIndex == 0)
            {
                tabControl_Modific.SelectedIndex = 1;
            }
            else if (tabControl_Modific.SelectedIndex == 2)
            {
                tabControl_Modific.SelectedIndex = 3;
            }

            //Request Replace
            tb_requestReplace_uri.Text = session.fullUrl;
            cb_editRequestEdition.Text = ((Fiddler.HTTPHeaders)(session.oRequest.headers)).HTTPVersion;
            cb_editRequestMethod.Text = session.RequestMethod;
            elv_requsetReplace.ListDataView.Items.Clear();
            foreach (var tempHead in session.RequestHeaders)
            {
                elv_requsetReplace.ListDataView.Items.Add(String.Format("{0}: {1}", tempHead.Name, tempHead.Value));
            }
            rtb_requsetReplace_body.Clear();
            if (session.requestBodyBytes != null)
            {
                if (session.requestBodyBytes.Length > 0)
                {
                    //Encoding tempRequestEncoding = session.GetRequestBodyEncoding() == null ? Encoding.UTF8 : session.GetRequestBodyEncoding();
                    //rtb_requsetReplace_body.Text = tempRequestEncoding.GetString(session.requestBodyBytes);
                    rtb_requsetReplace_body.Text = session.GetRequestBodyAsString();
                }
            }
            MemoryStream tempRequestStream = new MemoryStream();
            if (session.WriteRequestToStream(false, true, true, tempRequestStream))
            {
                byte[] tempRequestBytes = new byte[tempRequestStream.Length];
                tempRequestBytes = tempRequestStream.ToArray();
                //tempRequestStream.ReadAsync(tempRequestBytes, 0, (int)tempRequestStream.Length);
                //tempRequestStream.Position=0;
                //tempRequestStream.Read(tempRequestBytes, 0, (int)tempRequestStream.Length);
                rtb_requestRaw.Clear();
                rtb_requestRaw.Text = Encoding.UTF8.GetString(tempRequestBytes);
            }
            else
            {
                rtb_requestRaw.Clear();
                rtb_requestRaw.Text = "read RequestStream fail";
            }
            tempRequestStream.Close();

            //Response Replace

            MemoryStream tempReponseStream = new MemoryStream();
            if (session.WriteResponseToStream(tempReponseStream, false))
            {
                byte[] tempResponseBytes = new byte[tempReponseStream.Length];
                tempResponseBytes = tempReponseStream.ToArray();
                rawResponseEdit.SetText(Encoding.UTF8.GetString(tempResponseBytes));
            }
            else
            {
                rawResponseEdit.SetText("read ResponseStream fail");
            }
            tempReponseStream.Close();


        }

        public void SetClientCookies(string yourCookieString)
        {
            if (string.IsNullOrEmpty(yourCookieString))
            {
                MessageBox.Show("can not find any cookies in you selected session \r\nselect session again", "select session again");
                if(Fiddler.FiddlerApplication.UI.lvSessions.SelectedItems!=null&&Fiddler.FiddlerApplication.UI.lvSessions.SelectedItems.Count>0)
                {
                    MarkRuleItem(Fiddler.FiddlerApplication.UI.lvSessions.SelectedItems[0], Color.Plum, 2);
                }
                else
                {
                    MarkWarnControl(Fiddler.FiddlerApplication.UI.lvSessions);
                }
            }
           
            string[] tempCS = yourCookieString.Split(';');
            if (tempCS.Length > 0)
            {
                List<KeyValuePair<string, string>> tempCL = null;
                tempCL = new List<KeyValuePair<string, string>>();
                foreach (string eachCookies in tempCS)
                {
                    string cookieKey = null;
                    string cookieVaule = null;
                    int splitIndex = eachCookies.IndexOf('=');
                    if (splitIndex < 0)
                    {
                        PutWarn(string.Format("find illegal cookie with {0}", eachCookies));
                        continue;
                    }
                    cookieKey = eachCookies.Remove(splitIndex).Trim();
                    cookieVaule = eachCookies.Substring(splitIndex + 1);
                    tempCL.Add(new KeyValuePair<string, string>(cookieKey, cookieVaule));
                }

                foreach(var formatedCooke in tempCL)
                {
                    responseAddHeads.ListDataView.Items.Add(string.Format("Set-Cookie: {0}={1};{2}", formatedCooke.Key, formatedCooke.Value,"Path=/" ));
                }
            }
            else
            {
                MessageBox.Show("the cookies in selected session is illegal\r\nplease check again");
            }
        }

        public void ShowOwnerWindow(string name,string info)
        {
            ShowTextForm f = new ShowTextForm(name,info);
            f.Owner = Fiddler.FiddlerApplication.UI;
            f.StartPosition = FormStartPosition.CenterParent;
            f.Show();
        }

        public void PutInfo(string info)
        {
            rtb_MesInfo.SelectionColor = Color.Black;
            rtb_MesInfo.AppendText(string.Format("【{0}】:{1}", DateTime.Now.ToString(), info));
            rtb_MesInfo.AppendText("\r\n");
            rtb_MesInfo.SelectionColor = Color.Black;
        }

        public void PutWarn(string info)
        {
            rtb_MesInfo.SelectionColor = Color.Indigo;
            rtb_MesInfo.AppendText(string.Format("【{0}】:{1}", DateTime.Now.ToString(), info));
            rtb_MesInfo.AppendText("\r\n");
            rtb_MesInfo.SelectionColor = Color.Black;
        }

        public void PutError(string info)
        {
            rtb_MesInfo.SelectionColor = Color.Red;
            rtb_MesInfo.AppendText(string.Format("【{0}】:{1}", DateTime.Now.ToString(), info));
            rtb_MesInfo.AppendText("\r\n");
            rtb_MesInfo.SelectionColor = Color.Black;
        }

        #endregion
    }
}
