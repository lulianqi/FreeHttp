//#define NET4_5UP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService
{
    public class FeedbackService
    {
        public class Feedback
        {
            public string user_mac { get; set; }
            public string contact_infomation { get; set; }
            public string feedback_content { get; set; }

            public Feedback(string mac, string contact, string content)
            {
                user_mac = mac;
                contact_infomation = contact;
                feedback_content = content;
            }
        }

#if NET4_5UP
        public static async Task<int> SubmitFeedbackAsync(string mac, string contact, string content)
        {
            return await SubmitFeedbackAsync(new Feedback(mac, contact, content));
        }

        public static async Task<int> SubmitFeedbackAsync(Feedback feedback)
        {
            if (feedback == null) return -1;
            Func<int> SubmitFeedbackTask = new Func<int>(() =>
            {
                string feedbackBody = String.Format("{{ \"user_mac\":{0},\"feedback_content\":{1},\"contact_infomation\": {2}}}"
                    , Fiddler.WebFormats.JSON.JsonEncode(feedback.user_mac),
                    Fiddler.WebFormats.JSON.JsonEncode(feedback.feedback_content),
                    Fiddler.WebFormats.JSON.JsonEncode(feedback.contact_infomation));
                int responseCode = (new WebService.MyWebTool.MyHttp()).SendHttpRequest("https://api.lulianqi.com/freehttp/Feedback", feedbackBody, "POST", new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Content-Type", "application/json") }, false, null, null).StatusCode;
                return responseCode;
            });
            int code =  await Task.Run(SubmitFeedbackTask);
            return code;
        }
#endif

#if NET4
        //因为.net4.5 以下没有Task.Run，该方法用于低版本编译
        public static void SubmitFeedbackTask(string mac, string contact, string content,Action<int> showResult)
        {
            Task<int> submitFeedback = new Task<int>(() =>
            {
                Feedback feedback = new Feedback(mac, contact, content);
                string feedbackBody = String.Format("{{ \"user_mac\":{0},\"feedback_content\":{1},\"contact_infomation\": {2}}}"
                    , Fiddler.WebFormats.JSON.JsonEncode(feedback.user_mac),
                    Fiddler.WebFormats.JSON.JsonEncode(feedback.feedback_content),
                    Fiddler.WebFormats.JSON.JsonEncode(feedback.contact_infomation));
                int responseCode = (new WebService.MyWebTool.MyHttp()).SendHttpRequest("https://api.lulianqi.com/freehttp/Feedback", feedbackBody, "POST",  new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Content-Type", "application/json") }, false, null, null).StatusCode;
                return responseCode;
            });
            submitFeedback.Start();
            submitFeedback.ContinueWith((task) => { showResult(task.Result); }) ;
        }
#endif

    }
}
